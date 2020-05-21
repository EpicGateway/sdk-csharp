using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class SuspendSubscriptionResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public SuspendSubscriptionResult Result { get; set; }
    }
    [DataContract]
    public class SuspendSubscriptionResult
    {
        [DataMember(Name = "subscription", IsRequired = true)]
        public SuspendedSubscription Subscription { get; set; }
    }
    [DataContract]
    public class SuspendedSubscription
    {
        [DataMember(Name = "id", IsRequired = true)]
        public string ID { get; set; }
        [DataMember(Name = "status", IsRequired = true)]
        public string Status { get; set; }
    }
    [DataContract]
    public class SubscriptionResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public SubscriptionResult Result { get; set; }
    }

    [DataContract]
    public class SubscriptionResult
    {
        [DataMember(Name = "subscription", EmitDefaultValue = false)]
        public Subscription Subscription { get; set; }
    }

    [DataContract]
    public class Subscription
    {
        [DataMember(Name = "subscription_id", IsRequired= true)]
        public string SubscriptionID { get; set; }

        [DataMember(Name = "customer_id", EmitDefaultValue = false)]
        public string CustomerID { get; set; }

        [DataMember(Name = "wallet_id", EmitDefaultValue = false)]
        public string WalletID { get; set; }

        //[DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        //public string ClientTransactionID { get; set; }

        //[DataMember(Name = "customer_address", EmitDefaultValue = false)]
        //public CustomerAddress CustomerAddress { get; set; }

        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public int Amount { get; set; }

        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        [DataMember(Name = "next_payment_date", EmitDefaultValue = false)]
        public string NextPaymentDate { get; set; }

        [DataMember(Name = "frequency", EmitDefaultValue = false)]
        public string Frequency { get; set; }

        [DataMember(Name = "period", EmitDefaultValue = false)]
        public int Period { get; set; }

        [DataMember(Name = "date_of_month_1", EmitDefaultValue = false)]
        public int FirstPaymentDayOfMonth { get; set; }

        [DataMember(Name = "date_of_month_2", EmitDefaultValue = false)]
        public int SecondPaymentDayOfMonth { get; set; }
        
       [DataMember(Name = "total_payments", IsRequired = false, EmitDefaultValue = false)]
        public int TotalPayments { get; set; }

        [DataMember(Name = "last_payment_date", IsRequired = false, EmitDefaultValue = false)]
        public string LastPaymentDate { get; set; }

        [DataMember(Name = "last_amount", IsRequired = false, EmitDefaultValue = false)]
        public int LastAmount { get; set; }

        [DataMember(Name = "client_order_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientOrderID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "alert_after", IsRequired = false, EmitDefaultValue = false)]
        public bool Alert { get; set; }

        [DataMember(Name = "sec_code", EmitDefaultValue = true)]
        public string EntryClass { get; set; }
        [DataMember(Name = "entry_description", EmitDefaultValue = false)]
        public string EntryDescription { get; set; }
    }
}
