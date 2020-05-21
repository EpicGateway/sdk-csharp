using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class CustomerResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public CustomerResult Result { get; set; }
    }

    [DataContract]
    public class CustomerResult
    {
        [DataMember(Name = "customer", EmitDefaultValue = false)]
        public Customer Customer { get; set; }
    }

    [DataContract]
    public class Customer
    {
        [DataMember(Name = "customer_id", IsRequired = true)]
        public string CustomerId { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "customer_address", EmitDefaultValue = false)]
        public CustomerAddress CustomerAddress { get; set; }
   }
}
