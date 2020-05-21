using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK.Models
{

    [DataContract]
    public class EditCustomerRequest
    {
        public string CustomerID { get; set; }

        [DataMember(Name = "customer_address", EmitDefaultValue = false)]
        public CustomerAddress CustomerAddress { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }
    }
}
