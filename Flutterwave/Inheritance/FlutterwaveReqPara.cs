using System.Collections.Generic;
using System.Security.Cryptography;
using Flutterwave.Model;

namespace Flutterwave.Inheritance
{
    public class FlutterwaveReqPara
    {
        public string tx_ref { get; set; }
        public double amount { get; set; }
        public SHA256? integrity_hash { get; set; }
        public PaymentOptions? payment_option { get; set; }
        public string? payment_plan { get; set; }
        public string redirect_url { get; set; }
        public Customer customer { get; set; }
        public List<SubAccounts>? subaccounts { get; set; }
        public object? meta { get; set; }
        public FlutterCustomization customization { get; set; }
    }
}