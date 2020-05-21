using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class AddSubscriptionRequest
    {

        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "currency", IsRequired = true)]
        [DefaultValue("usd")]
        public string Currency { get; set; }

        [DataMember(Name = "next_payment_date", IsRequired = true)]
        public string NextPaymentDate { get; set; }

        [DataMember(Name = "frequency", IsRequired = true)]
        public string Frequency { get; set; }

        [DataMember(Name = "period", EmitDefaultValue = false)]
        public int Period { get; set; }

        [DataMember(Name = "date_of_month_1", EmitDefaultValue = false)]
        public int FirstPaymentDayOfMonth { get; set; }

        [DataMember(Name = "date_of_month_2", EmitDefaultValue = false)]
        public int SecondPaymentDayOfMonth { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }


        [DataMember(Name = "alert_days_before", IsRequired = false, EmitDefaultValue = false)]
        public int AlertDaysBefore { get; set; }

        [DataMember(Name = "alert_after", IsRequired = false, EmitDefaultValue = false)]
        public bool Alert { get; set; }

        [DataMember(Name = "client_order_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientOrderID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "total_payments", IsRequired = false, EmitDefaultValue = false)]
        public int TotalPayments { get; set; }

        [DataMember(Name = "last_payment_date", IsRequired = false, EmitDefaultValue = false)]
        public string LastPaymentDate { get; set; }


        [DataMember(Name = "last_amount", IsRequired = false, EmitDefaultValue = false)]
        public int LastAmount { get; set; }

        [DataMember(Name = "sec_code", EmitDefaultValue = true)]
        public string EntryClass { get; set; }
        [DataMember(Name = "entry_description", EmitDefaultValue = false)]
        public string EntryDescription { get; set; }

        [DataMember(Name = "customer_address", IsRequired = false, EmitDefaultValue = false)]
        public CustomerAddress CustomerAddress { get; set; }

        [DataMember(Name = "billing_address", IsRequired = false, EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }
    }

    [DataContract]
    public class EditSubscriptionRequest
    {

        public string SubscriptionID { get; set; }

        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "currency", IsRequired = true)]
        [DefaultValue("usd")]
        public string Currency { get; set; }

        [DataMember(Name = "next_payment_date", IsRequired = true)]
        public string NextPaymentDate { get; set; }

        [DataMember(Name = "frequency", IsRequired = true)]
        public string Frequency { get; set; }

        [DataMember(Name = "period", EmitDefaultValue = false)]
        public int Period { get; set; }

        [DataMember(Name = "date_of_month_1", EmitDefaultValue = false)]
        public int FirstPaymentDayOfMonth { get; set; }

        [DataMember(Name = "date_of_month_2", EmitDefaultValue = false)]
        public int SecondPaymentDayOfMonth { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }

        [DataMember(Name = "alert_days_before", IsRequired = false, EmitDefaultValue = false)]
        public int AlertDaysBefore { get; set; }

        [DataMember(Name = "alert_after", IsRequired = false, EmitDefaultValue = false)]
        public bool Alert { get; set; }

        [DataMember(Name = "client_order_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientOrderID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "total_payments", IsRequired = false, EmitDefaultValue = false)]
        public int TotalPayments { get; set; }

        [DataMember(Name = "last_payment_date", IsRequired = false, EmitDefaultValue = false)]
        public string LastPaymentDate { get; set; }


        [DataMember(Name = "last_amount", IsRequired = false, EmitDefaultValue = false)]
        public int LastAmount { get; set; }

        [DataMember(Name = "sec_code", EmitDefaultValue = true)]
        public string EntryClass { get; set; }
        [DataMember(Name = "entry_description", EmitDefaultValue = false)]
        public string EntryDescription { get; set; }

        [DataMember(Name = "customer_address", IsRequired = false, EmitDefaultValue = false)]
        public CustomerAddress CustomerAddress { get; set; }

        [DataMember(Name = "billing_address", IsRequired = false, EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }
    }

    [DataContract]
    public class DeleteSubscriptionRequest
    {
        public string SubscriptionID { get; set; }
    }
    [DataContract]
    public class SuspendSubscriptionRequest
    {
        public string SubscriptionID { get; set; }
    }
    [DataContract]
    public class UnsuspendSubscriptionRequest
    {
        public string SubscriptionID { get; set; }
    }
}
