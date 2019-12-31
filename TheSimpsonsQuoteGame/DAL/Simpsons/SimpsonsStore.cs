using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.SimpsonsServices;

namespace TheSimpsonsQuoteGame.DAL.Simpsons
{
    public class SimpsonsStore : ISimpsonsStore
    {
        public async Task<QuoteResponse> GetRandomQuote()
        {
            using (var httpClient = new HttpClient { BaseAddress = new Uri("https://thesimpsonsquoteapi.glitch.me") })
            {
                var apiResult = await httpClient.GetStringAsync("/quotes");

                var randomQuote = JsonConvert.DeserializeObject<QuoteResponse>(apiResult);
                return randomQuote;
            }
        }
    }
}
