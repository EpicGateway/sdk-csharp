using System.Runtime.Serialization;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class WalletResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public WalletResult Result { get; set; }
    }

    [DataContract]
    public class WalletResult
    {
        [DataMember(Name = "wallet", IsRequired = true)]
        public AddWallet Wallet { get; set; }
    }

    [DataContract]
    public class AddWallet
    {
        [DataMember(Name = "wallet_id", IsRequired = true)]
        public string WalletID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "customer_id", EmitDefaultValue = false)]
        public string CustomerId { get; set; }
    }
}