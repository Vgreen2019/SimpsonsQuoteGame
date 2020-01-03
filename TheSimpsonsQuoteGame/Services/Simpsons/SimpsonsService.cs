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
        private readonly ICheckAnswer _checkAnswer;
        public string Answer { get; set; }
        public string Question { get; set; }


        public List<string> _characters = new List<string>
        {
             "Marge Simpson",
             "Bart Simpson",
             "Homer Simpson"
        };

        public SimpsonsService(ISimpsonsStore simpsonsStore, ICheckAnswer checkAnswer)
        {
            _simpsonsStore = simpsonsStore;
            _checkAnswer = checkAnswer;
        }

        public async Task<QuestionViewModel> PullRandomQuote()
        {
            var randomQuoteResponse = await _simpsonsStore.GetRandomQuote();

            Answer = randomQuoteResponse[0].Character;
            Question = randomQuoteResponse[0].Quote;

            //Answer = _checkAnswer.GetAnswer(randomQuoteResponse[0].Character);
            //Question = _checkAnswer.GetQuestion(randomQuoteResponse[0].Quote);


            var random = new Random();
            var index = random.Next(_characters.Count);
            var index2 = random.Next(_characters.Count);

            var model = new QuestionViewModel
            {
                Question = randomQuoteResponse[0].Quote,
                PossibleAnswers = new List<string>
                {
                    randomQuoteResponse[0].Character,
                    _characters[index],
                    _characters[index2]
                }                
            };            
            return model;
        }

        public CheckAnswerViewModel CheckAnswer(string answer)
        {

            var checkAnsViewModel = new CheckAnswerViewModel
            {
                Question = Question,
                Answer = Answer
            };

            if(answer == Answer)
            {
                checkAnsViewModel.CheckAnswerMessage = "Correct!";
            }
            else
            {
                checkAnsViewModel.CheckAnswerMessage = "Whoops! Thats not right!";
            }
            return checkAnsViewModel;
        }
    }
}
