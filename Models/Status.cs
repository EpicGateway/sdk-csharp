using System.Runtime.Serialization;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class Status
    {
        [DataMember(Name = "response_code", IsRequired = true)]
        public string ResponseCode { get; set; }
        [DataMember(Name = "reason_code", IsRequired = true)]
        public string ReasonCode { get; set; }
        [DataMember(Name = "reason_text", IsRequired = true)]
        public string ReasonText { get; set; }
    }
}