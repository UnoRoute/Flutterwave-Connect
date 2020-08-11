using System.Collections.Generic;
using System.Security.Cryptography;
using Flutterwave.Core;
using Flutterwave.Model;

namespace Flutterwave.Standard
{
    public class FlutterwaveTransactionVerifyReponse
    {
        public int id { get; set; }
        public string tx_ref { get; set; }
        public string flw_ref { get; set; }
        public string device_fingerprint { get; set; }
        public string app_fee { get; set; }
        public string merchant_fee { get; set; }
        public string processor_response { get; set; }
        public string auth_model { get; set; }
        public string ip { get; set; }
        public string narration { get; set; }
        public string payment_type { get; set; }
        public string created_at { get; set; }
        public string account_id { get; set; }
        public FlutterwaveCardResponse Card { get; set; }
        public int amount_settled { get; set; }
        
        public double amount { get; set; }
        public string currency { get; set; } = "NGN";
        public SHA256 integrity_hash { get; set; }
        public FlutterwavePaymentOptions payment_option { get; set; }
        public string payment_plan { get; set; }
        public string redirect_url { get; set; }
        public Customer customer { get; set; }
        public List<FlutterwaveSubAccounts> subaccounts { get; set; }
        public object meta { get; set; }
        public FlutterwaveCustomization customization { get; set; }
    }
}