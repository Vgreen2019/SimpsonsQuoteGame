using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.Services.Simpsons;

namespace TheSimpsonsQuoteGame.Services
{
    public interface ICheckAnswer
    {
       string GetAnswer(string answer);
        string GetQuestion(string question);
    }
}
