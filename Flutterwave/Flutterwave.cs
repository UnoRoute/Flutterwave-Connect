using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bracketcore.Flutterwave.Core;
using Bracketcore.Flutterwave.Standard;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bracketcore.Flutterwave
{
    public class FLW
    {
        public FLW(string SecKey)
        {
            Sec_Key = SecKey;
        }

        /// <summary>
        ///     Security Key
        /// </summary>
        public string Sec_Key { get; set; }


        /// <summary>
        ///     Accept payment quickly and securely using the standard method by calling flutterwave /payments endpoint.
        /// </summary>
        /// <param name="para">
        ///     Collect the customers' details, add it to your request object and call our standard payment
        ///     endpoint.
        /// </param>
        /// <param name="Seckey">Optional</param>
        /// <returns></returns>
        public async Task<FlutterwaveResponse<FlutterwaveStandardDataResponse>> Standard(FlutterwaveReqPara para)
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

            return JsonConvert.DeserializeObject<FlutterwaveResponse<FlutterwaveStandardDataResponse>>(result);
        }

        /// <summary>
        ///     Accept payment quickly and securely using the standard method by calling flutterwave /payments endpoint.
        /// </summary>
        /// <param name="Sec_Key">Your Flutterwave security key</param>
        /// <param name="para">
        ///     Collect the customers' details, add it to your request object and call our standard payment
        ///     endpoint.
        /// </param>
        /// <returns></returns>
        public static async Task<FlutterwaveResponse<FlutterwaveStandardDataResponse>> Standard(string Sec_Key,
            FlutterwaveReqPara para)
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

            return JsonConvert.DeserializeObject<FlutterwaveResponse<FlutterwaveStandardDataResponse>>(result);
        }

        /// <summary>
        ///     Verify transaction
        /// </summary>
        /// <param name="TransactionId">The Transactional Id for successful transaction</param>
        /// <returns></returns>
        public async Task<FlutterwaveResponse<FlutterwaveTransactionVerifyReponse>> VerifyTransaction(
            string TransactionId)
        {
            var Api = Sec_Key;

            using var fetch = new HttpClient();
            fetch.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            fetch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Api);

            var response =
                await fetch.GetAsync(new Uri($"https://api.flutterwave.com/v3/transactions/{TransactionId}/verify"));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            // var json = JObject.Parse(result);

            return JsonConvert.DeserializeObject<FlutterwaveResponse<FlutterwaveTransactionVerifyReponse>>(result,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    Culture = CultureInfo.InvariantCulture,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

        /// <summary>
        ///     Verify transaction
        /// </summary>
        /// <param name="Sec_Key">Your Security Key</param>
        /// <param name="TransactionId">The Transactional Id for successful transaction</param>
        /// <returns></returns>
        public static async Task<FlutterwaveResponse<FlutterwaveTransactionVerifyReponse>> VerifyTransaction(
            string Sec_Key,
            string TransactionId)
        {
            var Api = Sec_Key;

            using var fetch = new HttpClient();
            fetch.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            fetch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Api);

            var response =
                await fetch.GetAsync(new Uri($"https://api.flutterwave.com/v3/transactions/{TransactionId}/verify"));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            // var json = JObject.Parse(result);

            return JsonConvert.DeserializeObject<FlutterwaveResponse<FlutterwaveTransactionVerifyReponse>>(result,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    Culture = CultureInfo.InvariantCulture,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}