using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.DAL.Simpsons;
using TheSimpsonsQuoteGame.Models;
using TheSimpsonsQuoteGame.SimpsonsServices;

namespace TheSimpsonsQuoteGame.Services.Simpsons
{
    public class SimpsonsService : ISimpsonsService
    {
        private readonly ISimpsonsStore _simpsonsStore;
        public Character Characters { get; set; }


        public SimpsonsService(ISimpsonsStore simpsonsStore)
        {
            _simpsonsStore = simpsonsStore;
        }

        public async Task<QuestionViewModel> PullRandomQuote()
        {
            var randomQuoteResponse = await _simpsonsStore.GetRandomQuote();

            var model = new QuestionViewModel
            {
                //Question = randomQuoteResponse.QuoteResponse[0].Quote
                Question = randomQuoteResponse[0].Quote

            };

            var random = new Random();
            var index = random.Next(Characters.Characters.Count);
            //model.PossibleAnswers.Add(randomQuoteResponse.QuoteResponse[0].Character);
            model.PossibleAnswers.Add(randomQuoteResponse[0].Character);
            model.PossibleAnswers.Add(Characters.Characters[index]);
            model.PossibleAnswers.Add(Characters.Characters[index]);

            return model;
        }
    }
}
