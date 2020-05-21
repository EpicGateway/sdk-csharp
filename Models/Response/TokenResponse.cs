using System.Runtime.Serialization;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class TokenResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public TokenResult Result { get; set; }
    }

    public class MultiUseTokenResponse : TokenResponse{}
    [DataContract]
    public class MultiUseTokenExtResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public TokenExtResult Result { get; set; }
    }

    [DataContract]
    public class ExtCardData
    {
        [DataMember(Name = "card_type")]
        public string CardType { get; set; }
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name ="international")]
        public bool IsInternationalCard { get; set; }
        [DataMember(Name = "check_card")]
        public bool IsCheckCard { get; set; }
        [DataMember(Name = "commercial")]
        public bool IsCommercialCard { get; set; }
        [DataMember(Name = "prepaid")]
        public bool IsPrepaidCard { get; set; }
    }

    [DataContract]
    public class TokenResult
    {
        [DataMember(Name = "token")]
        public OneTimeToken Token { get; set; }
    }
    [DataContract]
    public class TokenExtResult
    {
        [DataMember(Name = "token")]
        public TokenExt Token { get; set; }
    }
    [DataContract]
    public class OneTimeToken
    {
        [DataMember(Name = "token_type", IsRequired = true)]
        public string TokenType { get; set; }

        [DataMember(Name = "token_number", IsRequired = true)]
        public string TokenNumber { get; set; }
    }
    [DataContract]
    public class TokenExt : OneTimeToken
    {
        [DataMember(Name = "card_info")]
        public ExtCardData CardInfo;
    }
}