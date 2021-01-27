using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK.Models
{
    [DataContract]
    public class PaymentResponse
    {
        [DataMember(Name = "status", IsRequired = true)]
        public Status Status { get; set; }

        [DataMember(Name = "result", IsRequired = false, EmitDefaultValue = false)]
        public AuthResult Result { get; set; }
    }
   

    public class AuthorizationResponse : PaymentResponse { };
    public class SaleResponse : PaymentResponse { };
    public class CaptureResponse : PaymentResponse { };
    public class RefundResponse : PaymentResponse { };
    public class VoidResponse : PaymentResponse { };
    public class EcheckSaleResponse : PaymentResponse { };
    public class EcheckCreditResponse : PaymentResponse { };
    public class EcheckRefundResponse : PaymentResponse { };
   

    [DataContract]
    public class AuthResult
    {
        [DataMember(Name = "payment", EmitDefaultValue = false)]
        public Payment Payment { get; set; }
    }

    [DataContract]
    public class Payment
    {
        [DataMember(Name = "transaction_type", IsRequired = true)]
        public string TransactionType { get; set; }

        [DataMember(Name = "amount", IsRequired = true)]
        public int Amount { get; set; }

        [DataMember(Name = "secondary_amount", IsRequired = false)]
        public int SecondaryAmount { get; set; }

        [DataMember(Name = "currency", IsRequired = false)]
        public string Currency { get; set; }

        [DataMember(Name = "client_transaction_id", IsRequired = false, EmitDefaultValue = false)]
        public string ClientTransactionID { get; set; }

        [DataMember(Name = "transaction_id", IsRequired = true)]
        public string TransactionID { get; set; }

        [DataMember(Name = "method", IsRequired = false)]
        public string Method { get; set; }

        [DataMember(Name = "reference_number", IsRequired = false)]
        public string ReferenceNumber { get; set; }

        [DataMember(Name = "authorization_number", IsRequired = false)]
        public string AuthNumber { get; set; }

        [DataMember(Name = "avs_code", IsRequired = false)]
        public string AVSCode { get; set; }

        [DataMember(Name = "cvv_code", IsRequired = false)]
        public string CvvCode { get; set; }

        [DataMember(Name = "credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard { get; set; }

        [DataMember(Name = "billing_address", EmitDefaultValue = false)]
        public BillingAddress BillingAddress { get; set; }

        [DataMember(Name = "bank_account", EmitDefaultValue = false)]
        public BankAccount BankAccount { get; set; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public Token Token { get; set; }

        [DataMember(Name = "wallet", EmitDefaultValue = false)]
        public Wallet Wallet { get; set; }

        [DataMember(Name = "authentication_response", EmitDefaultValue = false)]
        public string AuthenticationResponse { get; set; }
       }

   

}
