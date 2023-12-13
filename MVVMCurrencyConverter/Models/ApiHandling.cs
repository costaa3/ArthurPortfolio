using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMCurrencyConverter.Models
{
    internal class ApiHandling
    {   
        public async Task<ExchangeTypes> GetData(string url)
        {
            ExchangeTypes exchange = new ExchangeTypes();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if(response.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<ExchangeTypes>(responseString);

                        return responseObject;
                    }
                    return exchange;
                }
            }
            catch (Exception)
            {

                return exchange;
            }
        }
    }
}
