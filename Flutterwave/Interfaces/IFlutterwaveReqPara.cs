using System.Collections.Generic;
using System.Security.Cryptography;
using Flutterwave.Model;

namespace Flutterwave.Interfaces
{
    public interface IFlutterwaveReqPara
    {
        public string tx_ref { get; set; }
        public double amount { get; set; }
        public SHA256? integrity_hash { get; set; }
        public IPaymentOptions? payment_option { get; set; }
        public string? payment_plan { get; set; }
        public string redirect_url { get; set; }
        public Customer customer { get; set; }
        public List<ISubAccounts>? subaccounts { get; set; }
        public object? meta { get; set; }
        public IFlutterCustomization customization { get; set; }
    }
}