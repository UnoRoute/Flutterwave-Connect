using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Core;
using Flutterwave.Standard;
using Newtonsoft.Json;

namespace Flutterwave
{
    public class Flutterwave
    {
        public Flutterwave(string SecKey)
        {
            Sec_Key = SecKey;
        }

        /// <summary>
        /// </summary>
        public string Sec_Key { get; set; }
        

        public async Task<FlutterwaveResponse<StandardDataResponse>> Standard(FlutterwaveReqPara para)
        {
            try
            {
                var Api = Sec_Key;
                var json = JsonConvert.SerializeObject(para);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var fetch = new HttpClient();
                fetch.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                fetch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Api);

                var response = await fetch.PostAsync(new Uri("https://api.flutterwave.com/v3/payments"), data);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<FlutterwaveResponse<StandardDataResponse>>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public async Task<FlutterwaveReqPara> Verify(string TransactionId)
        {
           
            var Api = Sec_Key;

            using var fetch = new HttpClient();
            fetch.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            fetch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Api);

            var response = await fetch.GetAsync(new Uri($"https://api.flutterwave.com/v3/transactions/{TransactionId}/verify"));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FlutterwaveReqPara>(result);
        }
    }
}