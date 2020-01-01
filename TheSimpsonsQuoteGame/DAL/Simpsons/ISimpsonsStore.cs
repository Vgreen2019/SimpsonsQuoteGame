using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.SimpsonsServices;

namespace TheSimpsonsQuoteGame.DAL.Simpsons
{
    public interface ISimpsonsStore
    {
        Task<List<QuoteResponse>> GetRandomQuote();
    }
}
