using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class AddWalletRequest
    {

        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "customer_address", EmitDefaultValue = false)]
        public CustomerAddress CustomerAddress { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "customer_id", EmitDefaultValue = false)]
        public string CustomerId { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "billing_address", IsRequired = false, EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }

    }

    [DataContract]
    public class DeleteWalletRequest
    {
        public string WalletID { get; set; }
    }

    [DataContract]
    public class EditWalletRequest
    {
        public string WalletID { get; set; }

        [DataMember(Name = "account_holder_name", IsRequired = true)]
        public string CardHolderName { get; set; }

        [DataMember(Name = "billing_address", EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }


        [DataMember(Name = "exp_month", EmitDefaultValue = false)]
        public string ExpMonth { get; set; }


        [DataMember(Name = "exp_year", EmitDefaultValue = false)]
        public string ExpYear { get; set; }

    }
}
