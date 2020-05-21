using System.Runtime.Serialization;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class JwtTokenResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public JwtTokenResult Result { get; set; }
    }

    [DataContract]
    public class JwtTokenResult
    {
        [DataMember(Name = "jwt", IsRequired = true)]
        public string Jwt { get; set; }
    }
}