using System.Collections.Generic;
using System.Security.Cryptography;
using Bracketcore.Flutterwave.Core;
using Bracketcore.Flutterwave.Model;

namespace Bracketcore.Flutterwave.Standard
{
    public class FlutterwaveReqPara
    {
        public string tx_ref { get; set; }
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