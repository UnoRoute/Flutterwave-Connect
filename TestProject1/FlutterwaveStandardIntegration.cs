using System;
using System.IO;
using System.Threading.Tasks;
using Bracketcore.Flutterwave;
using Bracketcore.Flutterwave.Core;
using Bracketcore.Flutterwave.Model;
using Bracketcore.Flutterwave.Standard;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Test
{
    public class FlutterwaveStandardIntegration
    {
        private FLW FLW;
        private string key;
        private FlutterwaveReqPara val;

        [SetUp]
        public void Setup()
        {
            var env = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            bool exist;
            string loc;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                loc = Path.Join(env.FullName,
                    @"/Roaming/microsoft/usersecrets/eda8ad3e-643c-49b4-b611-f1a54a0739ef/secrets.json");
                exist = File.Exists(loc);
            }
            else
            {
                loc = Path.Join(env.FullName,
                    @".microsoft/usersecrets/eda8ad3e-643c-49b4-b611-f1a54a0739ef/secrets.json");
                exist = File.Exists(loc);
            }


            if (exist)
            {
                var appSecret = File.ReadAllText(loc);
                key = JObject.Parse(appSecret)["secKey"]?.ToString();
            }
            else
            {
                key = Environment.GetEnvironmentVariable("Flutterwave");
            }


            FLW = new FLW(key);

            val = new FlutterwaveReqPara
            {
                amount = 3000,
                customer = new Customer
                {
                    email = "ehigiepaul@gmail.com",
                    name = "Paul Ehigie",
                    phonenumber = "07062238586",
                    username = "Ehigiepaul",
                    CustomerId = "sk28o2092309932823",
                    FirstName = "Paul",
                    LastName = "Paul"
                },
                customization = new FlutterwaveCustomization
                {
                    description = "Crediting wallet",
                    logo = "https://dashboard.flutterwave.com/static/img/avatar@3x.png",
                    title = "Help"
                },
                payment_option = FlutterwavePaymentOptions.card,
                redirect_url = "https://google.com",
                tx_ref = "dsj278378198712"
            };
        }

        [Test]
        public void CheckKey()
        {
            Assert.False(string.IsNullOrEmpty(FLW.Sec_Key));
            Assert.True(!string.IsNullOrEmpty(FLW.Sec_Key));
        }

        [Test]
        public async Task StandardReturn()
        {
            var d = await FLW.Standard(val);

            Assert.True(d.GetType() == typeof(FlutterwaveResponse<FlutterwaveStandardDataResponse>));
        }

        [Test]
        public async Task StandardReturnStatic()
        {
            var d = await FLW.Standard(key, val);

            Assert.True(d.GetType() == typeof(FlutterwaveResponse<FlutterwaveStandardDataResponse>));
        }

        [Test]
        public async Task StandardVerifyTransaction()
        {
            var d = await FLW.VerifyTransaction("1447069");
            Assert.True(d.GetType() == typeof(FlutterwaveResponse<FlutterwaveTransactionVerifyReponse>));
        }

        [Test]
        public async Task StandardVerifyTransactionStatic()
        {
            var d = await FLW.VerifyTransaction(key, "1447069");
            Assert.True(d.GetType() == typeof(FlutterwaveResponse<FlutterwaveTransactionVerifyReponse>));
        }
    }
}