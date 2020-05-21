using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK.Models.Request
{
    [DataContract]
    public class GetTransactionRequest
    {
        [DataMember(Name = "id_source", IsRequired = true)]
        public string IdSource { get; set; }

        public string Id { get; set; }

    }
}
