# EpicPay Gateway C# SDK

## Introduction

The EpicPay Gateway C# SDK can help you get a quick start when working with the EpicPay
Gateway Payments API.

This SDK was written against .Net Standard 2.0, and as such should work against
most modern compliant .Net implementations, including .Net Core > 2.0 and .Net
Framework > 4.6.1.

## Creating API Keys

Before starting with the SDK, you will need to create an API key online at 
[https://secure.epicpay.com/merchant/][1]. For up-to-date documentation
on this process, please refer to [our online documentation][2].

[1]: https://secure.epicpay.com/merchant/
[2]: https://developer.epicpay.com/Docs/PaymentAPI#Api_Intro

## Adding the SDK to your project

### Compile to .nupkg and install

Open the EpicGatewaySDK solution in Visual Studio 2017 or newer 
_(also tested in VS2019)_. The solution and project are already configured
to build the SDK into a .nupkg. Before building, consider whether you wish
to build the SDK in debug or release mode. After building the SDK,
(Build->Build Solution or `Ctrl-Shift-B`) the  package should be present in
_SDK root directory_/Epic.GatewaySDK/bin/_Debug or release_/.

To install the .nupkg, place it in a directory on your drive that is defined
as a package source in NuGet. To add a new directory as a package source,
go to Tools->Options->Nuget Package Manager->Package Sources. Once you have
added the source, you should be able to install Epic.GatewaySDK from the
NuGet package manager. (You may have to select your local package source
in the top-right of the package manager GUI).

## Usage

### Getting Started

To start, you'll need to instantiate an instance of the `EpicGateway` class
from the `Epic.GatewaySDK` namespace. The constructor has three parameters:

- APIKey: The API Key ID
- Password: The API Key Password
- BaseURL: The API base URL **with a trailing slash.**

The API base URL will vary depending on whether you are working against the
sandbox or the live production environment.

```C#
using Epic.GatewaySDK;
// ...
    EpicGateway gateway;
    gateway = new EpicGateway("apikey", "apipassword", "https://sandbox-api.epicpay.com/payment/v1/");
// ...
```

All interactions with the API will be handled through the instance of the 
`EpicGateway` object you created here, from authentication to asynchronous
HTTP requests.

All methods and models within the SDK have an analogous relationship to the 
methods and object structures defined by the [EpicPay Gateway API Specification.][2]
If you ever need clarification on how a method works, what parameters it
requires, or what are valid for those parameters, the API specification is the 
best source for that information.

### Differences to the API

Although the SDK mostly mirrors the API's structure, there are a few subtle 
differences in how each are used: 

- The `TransactionType` field does not need to be set manually on any
transactions. Instead, there are dedicated methods to call for each transaction
type.
- `BillingAddress` and `CustomerAddress` fields both have the class
`Address`. This has no functional difference beyond naming.

### General Pattern

Each of the public methods exposed by the `EpicGateway` class corresponds to
one of the methods or transaction types you can send to the Payment API.
You will likely want to reference the [API documentation][2] when crafting
your requests for the first time.

You'll find all the request and response models for this SDK in the namespace
`Epic.GatewaySDK.Models`. Each request takes as input its own request object
type, such as a `SaleRequest`. As such, submitting a request looks something
like this:

```C#
SaleRequest request = new SaleRequest
{
    Amount = 111,
    Currency = "usd",
    Method = "credit_card",
    CreditCard = new CreditCard
    {
        CardNumber = "****1111",
        CardHolderName = "John Smith",
        ExpMonth = "01",
        ExpYear = "22",
        CVV = "456"
    },
    BillingAddress = new BillingAddress()
    {
        FirstName = "Mary",
        LastName = "Smith",
        Address = "1 Main St.",
        Address2 = "Suite 201",
        City = "Burlington",
        CompanyName = "Big Company",
        StateProvince = "MA",
        PostalCode = "01803-3747",
        Email = "person@example.com",
        CountryCode = "US",
        Phone = new Phone { Number = "2015551255", Type = "mobile" }
    }
};
SaleResponse response = await _gw.Sale(request);
```

### Error Handling

The EpicPay Gateway C# SDK only throws exceptions for network-related errors, and does not
throw exceptions for errors returned by the API. Instead, you will need to check
for errors returned by the API by inspecting `Status.ResponseCode` in the
response object itself.

Check the API documentation for info on the different kinds of [Response Codes](https://developer.epicpay.com/Docs/PaymentAPI#Api_Appx_12) and [Reason Codes](https://developer.epicpay.com/Docs/PaymentAPI#Api_Appx_2) you can receive.
  
Check the `ReasonText` field for more information on any errors you encounter.
