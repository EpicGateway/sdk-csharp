using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Authentication;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class EpicToken
    {
        public EpicToken() { }
        public EpicToken(Wallet wallet)
        {
            TokenType = "wallet_token";
            TokenData = wallet.WalletID;
        }
        public EpicToken(Token token)
        {
            TokenData = token.TokenNumber;
            AccountHolderName = token.AccountHolderName;

            if (token.ExpYear != null && token.ExpMonth != null)
            {
                TokenType = "card_token";
                ExpMonth = token.ExpMonth;
                ExpYear = token.ExpYear;
            }
            else
            {
                TokenType = "echeck_token";
            }
        }

        // Valid types: "card_token", "echeck_token", "wallet_token", "checkout_token", "apple_pay"
        [DataMember(Name = "token_type", EmitDefaultValue = false)]
        public string TokenType { get; set; }

        // For card_token and echeck_token, TokenData is the token number
        // For wallet_token, TokenData is the wallet id
        // For checkout_token, TokenData is the encrypted json payload of the checkout object
        [DataMember(Name = "token_data")]
        public string TokenData { get; set; }

        // Optional: required for credit card and echeck token
        [DataMember(Name = "account_holder_name", EmitDefaultValue = false)]
        public string AccountHolderName { get; set; }

        // Optional: required for credit card token
        [DataMember(Name = "exp_month", EmitDefaultValue = false)]
        public string ExpMonth { get; set; }

        // Optional: required for credit card token
        [DataMember(Name = "exp_year", EmitDefaultValue = false)]
        public string ExpYear { get; set; }

        // Optional: applicable to card_token or card wallet
        [DataMember(Name = "cvv", EmitDefaultValue = false)]
        public string Cvv { get; set; }
    }

    [DataContract]
    public class Contact
    {
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "address_line_1", EmitDefaultValue = false)]
        public string Address { get; set; }
        [DataMember(Name = "address_line_2", EmitDefaultValue = false)]
        public string Address2 { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "company_name", EmitDefaultValue = false)]
        public string CompanyName { get; set; }
        [DataMember(Name = "state_province")]
        public string StateProvince { get; set; }
        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; }
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public Phone Phone { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }

    [DataContract]
    public class BillingAddress : Contact
    {
    }

    [DataContract]
    public class ShipppingAddress : Contact
    {
    }

    [DataContract]
    public class Phone
    {
        [DataMember(Name = "number", IsRequired = true)]
        public string Number { get; set; }
        [DataMember(Name = "type", IsRequired = true)]
        public string Type { get; set; }
    }

    [DataContract]
    public class CustomerAddress
    {
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "address_line_1", EmitDefaultValue = false)]
        public string Address { get; set; }
        [DataMember(Name = "address_line_2", EmitDefaultValue = false)]
        public string Address2 { get; set; }
        [DataMember(Name = "company_name", EmitDefaultValue = false)]
        public string CompanyName { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "state_province")]
        public string StateProvince { get; set; }
        [DataMember(Name = "postal_code")]
        public string PostalCode { get; set; }
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public Phone Phone { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }

    [DataContract]
    public class CreditCard
    {
        // Keyed card info: mutually exlusive with swiped card info
        [DataMember(Name = "card_number")]
        public string CardNumber { get; set; }
        [DataMember(Name = "card_holder_name")]
        public string CardHolderName { get; set; }
        [DataMember(Name = "exp_month")]
        public string ExpMonth { get; set; }
        [DataMember(Name = "exp_year")]
        public string ExpYear { get; set; }

        // Swiped card info: mutually exclusive with Keyed card info
        [DataMember(Name = "card_track")]
        public string CardTrack { get; set; }

        [DataMember(Name = "cvv", EmitDefaultValue = false)]
        public string CVV { get; set; }

        [DataMember(Name = "card_type", EmitDefaultValue = false)]
        public string CardType { get; set; }

        // 3DS Authentication Information
        [DataMember(Name = "authentication", EmitDefaultValue = false)]
        public Authentication3DS Authentication { get; set; }
    }

    [DataContract]
    public class BankAccount
    {
        [DataMember(Name = "account_type", IsRequired = true)]
        public string AccountType { get; set; }
        [DataMember(Name = "routing_number", IsRequired = true)]
        public string RoutingNumber { get; set; }
        [DataMember(Name = "account_number", IsRequired = true)]
        public string AccountNumber { get; set; }
        [DataMember(Name = "account_holder_name", IsRequired = true)]
        public string AccountHolderName { get; set; }
    }

    [DataContract]
    public class Token
    {
        [DataMember(Name = "token_type", IsRequired = true)]
        public string TokenType { get; set; }

        [DataMember(Name = "token_number", IsRequired = true)]
        public string TokenNumber { get; set; }

        [DataMember(Name = "account_holder_name", IsRequired = true)]
        public string AccountHolderName { get; set; }

        // Optional: require for credit card token
        [DataMember(Name = "exp_month", EmitDefaultValue = false)]
        public string ExpMonth { get; set; }

        // Optional: require for credit card token
        [DataMember(Name = "exp_year", EmitDefaultValue = false)]
        public string ExpYear { get; set; }
    }

    [DataContract]
    public class Wallet
    {
        [DataMember(Name = "wallet_id", IsRequired = true)]
        public string WalletID { get; set; }

        [DataMember(Name = "cvv", EmitDefaultValue = false)]
        public string CVV { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "customer_id", EmitDefaultValue = false)]
        public int CustomerId { get; set; }
    }

    [DataContract]
    public class OrderDetails
    {
        [DataMember(Name = "order_number")]
        public string OrderNumber { get; set; }

        [DataMember(Name = "discount_amount")]
        public int DiscountAmount { get; set; }

        [DataMember(Name = "shipping_amount")]
        public int ShippingAmount { get; set; }

        [DataMember(Name = "duty_amount")]
        public int DutyAmount { get; set; }

        [DataMember(Name = "is_tax_exempt")]
        public string IsTaxExempt { get; set; }

        [DataMember(Name = "ship_from_postal_code")]
        public string ShipFromPostalCode { get; set; }

        [DataMember(Name = "invoice_number")]
        public string InvoiceNumber { get; set; }

        [DataMember(Name = "order_date")]
        public string OrderDate { get; set; }

        [DataMember(Name = "line_items")]
        public List<LineItem> LineItems { get; set; }

        [DataMember(Name = "tax_items", IsRequired = true)]
        public List<TaxItem> TaxItems { get; set; }
    }

    [DataContract]
    public class LineItem
    {
        [DataMember(Name = "description", IsRequired = true)]
        public string Description { get; set; }

        [DataMember(Name = "commodity_code", IsRequired = true)]
        public string CommodityCode { get; set; }

        [DataMember(Name = "product_code", IsRequired = true)]
        public string ProductCode { get; set; }

        [DataMember(Name = "discount_amount", IsRequired = true)]
        public int DiscountAmount { get; set; }

        [DataMember(Name = "total_amount", IsRequired = true)]
        public int TotalAmount { get; set; }

        [DataMember(Name = "quantity", IsRequired = true)]
        public decimal Quantity { get; set; }

        [DataMember(Name = "unit_cost", IsRequired = true)]
        public int UnitCost { get; set; }

        [DataMember(Name = "unit_of_measure", IsRequired = true)]
        public string UnitOfMeasure { get; set; }

        [DataMember(Name = "tax_items", IsRequired = true)]
        public List<TaxItem> TaxItems { get; set; }
    }

    [DataContract]
    public class TaxItem
    {
        [DataMember(Name = "tax_type")]
        public string TaxType { get; set; }

        [DataMember(Name = "tax_id", IsRequired = true)]
        public string TaxId { get; set; }

        [DataMember(Name = "tax_amount", IsRequired = true)]
        public int TaxAmount { get; set; }

        [DataMember(Name = "tax_rate")]
        public decimal TaxRate { get; set; }
    }

    [DataContract]
    public class Authentication3DS
    {
        [DataMember(Name = "cryptogram")]
        public string Cryptogram { get; set; }

        // AKA: XID
        [DataMember(Name = "authentication_id")]
        public string AuthenticationId { get; set; }

        [DataMember(Name = "eci_indicator")]
        public string ECIIndicator { get; set; }

        // Values: "network_3ds_v1", "apple_pay", "google_pay"
        [DataMember(Name = "source")]
        public string CryptogramSource { get; set; }
    }
}
