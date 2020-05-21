using System.Runtime.Serialization;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class BillingAddress
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
}
