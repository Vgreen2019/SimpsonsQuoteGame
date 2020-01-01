using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.Models;
using TheSimpsonsQuoteGame.SimpsonsServices; //might have to change location

namespace TheSimpsonsQuoteGame.Services.Simpsons
{
    public interface ISimpsonsService
    {
        Task<QuestionViewModel> PullRandomQuote();

    }
}
