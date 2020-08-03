using System;
using System.IO;
using System.Threading.Tasks;
using Flutterwave.Inheritance;
using Flutterwave.Model;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Test
{
    public class FlutterwaveStandardIntegration
    {
        private Flutterwave.Flutterwave flutterwave;
        private FlutterwaveReqPara val;

        [SetUp]
        public void Setup()
        {
            var env = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            var appSecret = File.ReadAllText(
                Path.Join(env.FullName, @".microsoft/usersecrets/eda8ad3e-643c-49b4-b611-f1a54a0739ef/secrets.json"));

            var key = JObject.Parse(appSecret)["secKey"].ToString();

            flutterwave = new Flutterwave.Flutterwave(key);

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
                customization = new FlutterCustomization
                {
                    description = "Crediting wallet",
                    logo = "https://dashboard.flutterwave.com/static/img/avatar@3x.png",
                    title = "Help"
                },
                payment_option = PaymentOptions.card,
                redirect_url = "https://google.com",
                tx_ref = "dsj278378198712"
            };
        }

        [Test]
        public void CheckKey()
        {
            Assert.False(string.IsNullOrEmpty(flutterwave.Sec_Key));
            Assert.True(!string.IsNullOrEmpty(flutterwave.Sec_Key));
        }

        [Test]
        public async Task StandardReturn()
        {
            var d = await flutterwave.Standard(val);

            Assert.True(d.GetType() == typeof(FlutterwaveStanRes));
        }
    }
}