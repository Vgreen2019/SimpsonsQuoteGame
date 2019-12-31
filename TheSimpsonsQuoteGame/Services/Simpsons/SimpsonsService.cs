using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.DAL.Simpsons;
using TheSimpsonsQuoteGame.SimpsonsServices;

namespace TheSimpsonsQuoteGame.Services.Simpsons
{
    public class SimpsonsService : ISimpsonsService
    {
        private readonly ISimpsonsStore _simpsonsStore;

        public SimpsonsService(ISimpsonsStore simpsonsStore)
        {
            _simpsonsStore = simpsonsStore;
        }

        public async Task<QuoteResponse> PullRandomQuote()
        {
            var randomQuote = await _simpsonsStore.GetRandomQuote();
            return randomQuote;
        }
    }
}
