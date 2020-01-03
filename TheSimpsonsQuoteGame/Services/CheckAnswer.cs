using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.Services.Simpsons;

namespace TheSimpsonsQuoteGame.Services
{                               
    public class CheckAnswer: ICheckAnswer          //Might not need this class, refactor later
    {
        public string Question { get; set; }
        public string Answer { get; set; }
              
        public string GetAnswer(string answer)
        {
            Answer = answer;
            return Answer;
        }

        public string GetQuestion(string question)
        {
            Question = question;
            return Question;
        }
    }
}
