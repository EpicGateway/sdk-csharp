using Epic.GatewaySDK.Models;
using Epic.GatewaySDK.Models.Request;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Epic.GatewaySDK
{
    public class EpicGateway
    {
        private string _APIKey;
        private string _Password;
        private string _URL;

        public EpicGateway(string APIKey, string Password, string BaseUrl)
        {
            _APIKey = APIKey;
            _Password = Password;
            _URL = BaseUrl;
        }

        private async Task<string> PostRequest(string jsonRequest, string method, string id = "")
        {
            string jsonResponse = string.Empty;
            using (var client = new HttpClient())
            {
                // Force use of TLS 1.2
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string credentials = $"{_APIKey}:{_Password}";
                string modifier = string.IsNullOrEmpty(id) ? "" : $"/{id}";
                Uri theUri = new Uri($"{_URL}{method}{modifier}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BASIC", Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials)));
                client.DefaultRequestHeaders.Host = theUri.Host;
                var response = await client.PostAsync(theUri, content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    jsonResponse = await response.Content.ReadAsStringAsync();
                }
                return jsonResponse;
            }
        }

        private async Task<string> PostRequestUsingBearerAuth(string jsonRequest, string method, string jwt)
        {
            string jsonResponse = string.Empty;
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Uri theUri = new Uri($"{_URL}{method}/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BEARER", jwt);
                client.DefaultRequestHeaders.Host = theUri.Host;
                var response = await client.PostAsync(theUri, content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    jsonResponse = await response.Content.ReadAsStringAsync();
                }
                return jsonResponse;
            }
        }


        // Credit Card Authorization
        public async Task<AuthorizationResponse> Authorize(AuthorizationRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<AuthorizationRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "authorize");
            return CommonService.JsonDeSerializer<AuthorizationResponse>(jsonResponse);
        }

        // Credit Card Sale
        public async Task<SaleResponse> Sale(SaleRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<SaleRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "authorize");
            return CommonService.JsonDeSerializer<SaleResponse>(jsonResponse);
        }

        // Credit Card Capture: Authorization Complete
        public async Task<CaptureResponse> Capture(CaptureRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<CaptureRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "authorize", req.TransactionID);
            return CommonService.JsonDeSerializer<CaptureResponse>(jsonResponse);
        }

        // Refund
        public async Task<RefundResponse> Refund(RefundRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<RefundRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "authorize", req.TransactionID);
            return CommonService.JsonDeSerializer<RefundResponse>(jsonResponse);
        }

        // Void
        public async Task<VoidResponse> Void(VoidRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<VoidRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "authorize", req.TransactionID);
            return CommonService.JsonDeSerializer<VoidResponse>(jsonResponse);
        }

        // Echeck Sale
        public async Task<EcheckSaleResponse> EcheckSale(EcheckSaleRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<EcheckSaleRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "authorize");
            return CommonService.JsonDeSerializer<EcheckSaleResponse>(jsonResponse);
        }

        // Echeck Credit
        public async Task<EcheckCreditResponse> eCheckCredit(EcheckCreditRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<EcheckCreditRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "authorize");
            return CommonService.JsonDeSerializer<EcheckCreditResponse>(jsonResponse);
        }

        // Register Token (For Multi Use)
        public async Task<MultiUseTokenResponse> RegisterToken(MultiUseTokenizationRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<MultiUseTokenizationRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "RegisterToken");
            return CommonService.JsonDeSerializer<MultiUseTokenResponse>(jsonResponse);
        }

        // Register Token (For Multi Use)
        // This version returns some supplemental information about the card.
        public async Task<MultiUseTokenExtResponse> RegisterTokenExt(MultiUseTokenizationRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<MultiUseTokenizationRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "RegisterTokenExt");
            return CommonService.JsonDeSerializer<MultiUseTokenExtResponse>(jsonResponse);
        }

        // JWT Token (For One Time Use)
        public async Task<JwtTokenResponse> RequestJWT(JwtTokenizationRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<JwtTokenizationRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "RequestJWT");
            return CommonService.JsonDeSerializer<JwtTokenResponse>(jsonResponse);
        }

        // One-Time-Token Request (This method should be called from client-side code, but is included in this SDK for completeness.)
        public async Task<TokenResponse> RegisterOneTimeToken(string jwt, OneTimeTokenRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<OneTimeTokenRequest>(req);
            string jsonResponse = await PostRequestUsingBearerAuth(jsonRequest, "RegisterOneTimeToken", jwt);
            return CommonService.JsonDeSerializer<TokenResponse>(jsonResponse);
        }

        // Add wallet 
        public async Task<WalletResponse> AddWalletItem(AddWalletRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<AddWalletRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "AddWalletItem");
            return CommonService.JsonDeSerializer<WalletResponse>(jsonResponse);
        }

        //Edit wallet
        public async Task<WalletResponse> EditWalletItem(EditWalletRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<EditWalletRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "EditWalletItem", req.WalletID);
            return CommonService.JsonDeSerializer<WalletResponse>(jsonResponse);
        }

        //Delete wallet
        public async Task<WalletResponse> DeleteWalletItem(DeleteWalletRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<DeleteWalletRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "DeleteWalletItem", req.WalletID);
            return CommonService.JsonDeSerializer<WalletResponse>(jsonResponse);
        }

        //Edit Customer
        public async Task<CustomerResponse> EditCustomer(EditCustomerRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<EditCustomerRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "EditCustomer", req.CustomerID);
            return CommonService.JsonDeSerializer<CustomerResponse>(jsonResponse);
        }

        //Add Subscription
        public async Task<SubscriptionResponse> AddSubscription(AddSubscriptionRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<AddSubscriptionRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "AddSubscription");
            return CommonService.JsonDeSerializer<SubscriptionResponse>(jsonResponse);
        }

        //Edit Subscription
        public async Task<SubscriptionResponse> EditSubscription(EditSubscriptionRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<EditSubscriptionRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "EditSubscription", req.SubscriptionID);
            return CommonService.JsonDeSerializer<SubscriptionResponse>(jsonResponse);
        }

        //Delete Subscription
        public async Task<SubscriptionResponse> DeleteSubscription(DeleteSubscriptionRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<DeleteSubscriptionRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "DeleteSubscription", req.SubscriptionID);
            return CommonService.JsonDeSerializer<SubscriptionResponse>(jsonResponse);
        }

        //Suspend Subscription
        public async Task<SuspendSubscriptionResponse> SuspendSubscription(SuspendSubscriptionRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<SuspendSubscriptionRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "Subscription/Suspend", req.SubscriptionID);
            return CommonService.JsonDeSerializer<SuspendSubscriptionResponse>(jsonResponse);
        }

        //Unsuspend Subscription
        public async Task<SuspendSubscriptionResponse> UnsuspendSubscription(UnsuspendSubscriptionRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<UnsuspendSubscriptionRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "Subscription/Unsuspend", req.SubscriptionID);
            return CommonService.JsonDeSerializer<SuspendSubscriptionResponse>(jsonResponse);
        }

        //Get Transaction
        public async Task<PaymentResponse> GetTransaction(GetTransactionRequest req)
        {
            string jsonRequest = CommonService.JsonSerializer<GetTransactionRequest>(req);
            string jsonResponse = await PostRequest(jsonRequest, "GetTransaction", req.Id);
            return CommonService.JsonDeSerializer<PaymentResponse>(jsonResponse);
        }

    }

}

