using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Epic.GatewaySDK.Models
{
    
    [DataContract]
    public class AuthorizationRequest
    {
        [DataMember(Name = "transaction_type", IsRequired = true)]
        public readonly string transactionType = "Authorize";

        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "secondary_amount", IsRequired = false)]
        [DefaultValue(0)]
        public int SecondaryAmount { get; set; }

        [DataMember(Name = "currency", IsRequired = false)]
        [DefaultValue("usd")]
        public string Currency { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }

        [DataMember(Name = "client_order_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientOrderID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }

        [DataMember(Name = "billing_address", EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }

        [DataMember(Name = "network_transaction_id", EmitDefaultValue = false)]
        public string NetworkTransactionID { get; set; }

        [DataMember(Name = "cof_processing_type", EmitDefaultValue = false)]
        public string CofProcessingType { get; set; }
    }

    [DataContract]
    public class SaleRequest
    {
        [DataMember(Name = "transaction_type", IsRequired = true)]
        public readonly string transactionType = "sale";
        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "secondary_amount", IsRequired = false)]
        [DefaultValue(0)]
        public int SecondaryAmount { get; set; }

        [DataMember(Name = "currency", IsRequired = false)]
        [DefaultValue("usd")]
        public string Currency { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }

        [DataMember(Name = "client_order_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientOrderID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }

        [DataMember(Name = "billing_address", EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }

        [DataMember(Name = "network_transaction_id", EmitDefaultValue = false)]
        public string NetworkTransactionID { get; set; }

        [DataMember(Name = "cof_processing_type", EmitDefaultValue = false)]
        public string CofProcessingType { get; set; }
    }

    [DataContract]
    public class RefundRequest
    {
        public string TransactionID { get; set; }

        [DataMember(Name = "transaction_type", IsRequired = true)]
        public readonly string transactionType = "credit";

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "secondary_amount", IsRequired = false)]
        [DefaultValue(0)]
        public int SecondaryAmount { get; set; }

        [DataMember(Name = "currency", IsRequired = false)]
        [DefaultValue("usd")]
        public string Currency { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "billing_address", EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }

        [DataMember(Name = "method", EmitDefaultValue = false)]
        public string Method { get; set; }

        [DataMember(Name = "sec_code", EmitDefaultValue = false)]
        public string EntryClass { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }
    }

    [DataContract]
    public class CaptureRequest
    {
        public string TransactionID { get; set; }

        [DataMember(Name = "transaction_type", IsRequired = true)]
        public readonly string TransactionType = "capture";

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        //[DataMember(Name = "secondary_amount", IsRequired = false)]
        //[DefaultValue(0)]
        //public int SecondaryAmount { get; set; }

        [DataMember(Name = "currency", IsRequired = false)]
        [DefaultValue("usd")]
        public string Currency { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }
    }

    [DataContract]
    public class VoidRequest
    {
        public string TransactionID { get; set; }

        [DataMember(Name = "transaction_type", IsRequired = true)]
        public readonly string transactionType = "void";

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "secondary_amount", IsRequired = false)]
        [DefaultValue(0)]
        public int SecondaryAmount { get; set; }

        [DataMember(Name = "currency", IsRequired = false)]
        [DefaultValue("usd")]
        public string Currency { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }
    }
  
    [DataContract]
    public class EcheckSaleRequest
    {
        [DataMember(Name = "transaction_type", IsRequired = true)]
        public readonly string transactionType = "sale";

        [DataMember(Name = "currency", IsRequired = false)]
        public readonly string Currency = "usd";

        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "sec_code", EmitDefaultValue = true)]
        public string EntryClass { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }

        [DataMember(Name = "client_order_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientOrderID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }

        [DataMember(Name = "billing_address", EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }

        [DataMember(Name = "entry_description", EmitDefaultValue = false)]
        public string EntryDescription { get; set; }

    }

    [DataContract]
    public class EcheckCreditRequest
    {
        [DataMember(Name = "transaction_type", IsRequired = true)]
        public readonly string transactionType = "credit";
        [DataMember(Name = "currency", IsRequired = false)]
        public readonly string currency = "usd";

        [DataMember(Name = "method", IsRequired = true)]
        public string Method { get; set; }

        [DataMember(Name = "amount", IsRequired = true)]
        [DefaultValue(0)]
        public int Amount { get; set; }

        [DataMember(Name = "sec_code", EmitDefaultValue = true)]
        public string EntryClass { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }

        [DataMember(Name = "client_order_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientOrderID { get; set; }

        [DataMember(Name = "client_customer_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientCustomerID { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }

        [DataMember(Name = "billing_address", EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }
    }

    
    
   

    

   

   

    
}
