
using System.Runtime.Serialization;


namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class JwtTokenizationRequest
    {

        [DataMember(Name = "ip", IsRequired = true)]
        public string Ip { get; set; }
    }

    [DataContract]
    public class OneTimeTokenRequest
    {
        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "account_number", IsRequired = true)]
        public string AccountNumber { get; set; }

        [DataMember(Name = "bank_account_type", IsRequired = false)]
        public string BankAccountType { get; set; }

        [DataMember(Name = "routing_number", IsRequired = false)]
        public string RoutingNumber { get; set; }
    }

    [DataContract]
    public class MultiUseTokenizationRequest
    {

        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "epic_token", EmitDefaultValue = false)]
        public EpicToken EpicToken { get; set; }
    }
}
