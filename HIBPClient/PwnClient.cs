using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIBPClient.Models;
using Newtonsoft.Json;

namespace HIBPClient
{
    /// <summary>
    /// 
    /// </summary>
    /// TODO Add Rate Limiting support, either through a forced 100ms delay, or through dynamically obtaining the Retry-After number and adding that in
    public abstract class PwnClient
    {
        protected readonly HttpClient client = new HttpClient();
        protected readonly string API_URL = $"https://haveibeenpwned.com/api/v2";
        public readonly int RATE_LIMIT = 1500;
        protected DateTime lastCallTime;

        protected void WaitForRateLimit()
        {
            if (lastCallTime == null) lastCallTime = DateTime.Now;
            else while ((DateTime.Now - lastCallTime).Milliseconds < 1500) { }
        }

        public PwnClient(string useragent = "HIBClient.NET", System.Net.SecurityProtocolType tlsTypes = System.Net.SecurityProtocolType.Tls12)
        {
            if (string.IsNullOrEmpty(useragent)) throw new ArgumentNullException("User agent cannot be empty or null!");

            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", useragent);

            System.Net.ServicePointManager.SecurityProtocol = tlsTypes;
        }

        public async Task<bool> IsAccountBreached(string email)
        {
            WaitForRateLimit();
            if (!email.IsValidEmail()) throw new ArgumentException($"{email} is not a valid email address.");
            var response = await this.client.GetAsync($"{API_URL}/breachedaccount/{email}?truncateResponse=true");
            return ((int)response.StatusCode == 200) ? true : false;
        }

        public async Task<IEnumerable<Breach>> GetBreaches(string domainfilter = null)
        {
            WaitForRateLimit();
            var uri = $"{API_URL}/breaches";
            if (!String.IsNullOrEmpty(domainfilter)) uri += $"?domain={domainfilter}";

            var response = await this.client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Breach>>(content);
        }

        public async Task<Breach> GetBreach(string name)
        {
            WaitForRateLimit();
            if (String.IsNullOrEmpty(name)) throw new ArgumentException("A valid breach name must be provided");

            var response = await this.client.GetAsync($"{API_URL}/breach/{name}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Breach>(content);
        }
        
    }
}
