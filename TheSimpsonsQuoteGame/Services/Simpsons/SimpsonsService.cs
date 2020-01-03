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
        public string Image { get; set; }



        public List<string> _characters = new List<string>
        {
             "Marge Simpson",
             "Bart Simpson",
             "Homer Simpson",
             "Lisa Simpson",
             "Mr. Burns",
             "Apu Nahasepeemapetilon",
             "Ned Flanders",
             "Milhouse Van Houten",
             "Moe Szyslak",
             "Edna Krabappel",
             "Nelson Muntz",
             "Krusty the Clown",
             "Waylon Smithers",
             "Barney Gumble",
             "Principle Skinner",
             "Ralph Wiggum",
             "Grampa Simpson",
             "Comic Book Guy",
             "Fat Tony",
             "Martin Prince",
             "Allison Taylor",
             "Groundskeeper Wille",
             "Troy McClure",
             "Hans Moleman"                                          
        };      //searched through basic google, could be more added

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
            Image = randomQuoteResponse[0].Image;
                    
            var random = new Random();
            var index2 = random.Next(_characters.Count);
            var answers = new List<string>();
            answers.Add(randomQuoteResponse[0].Character);

            for (int i = 0; i < 2; i++)
            {
                var index = random.Next(_characters.Count);

                if (!answers.Contains(_characters[index]))
                {
                    answers.Add(_characters[index]);
                }
                
            }
            //do
            //{

            //}
            //while()


            HashSet<int> hash = new HashSet<int>();          
            do
            {
                var randomAns = random.Next(0,3);

                hash.Add(randomAns);

            } while (hash.Count<3); //This might control the questions per round.
            int[] randomAnsList = hash.ToArray();

            var model = new QuestionViewModel
            {
                Question = randomQuoteResponse[0].Quote,
                PossibleAnswers = new List<string>
                {
                    answers[randomAnsList[0]],
                    answers[randomAnsList[1]],
                    answers[randomAnsList[2]]
                }
            };            
            return model;
        }

        public CheckAnswerViewModel CheckAnswer(string answer)
        {

            var checkAnsViewModel = new CheckAnswerViewModel
            {
                Question = Question,
                Answer = Answer,
                Image = Image
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
