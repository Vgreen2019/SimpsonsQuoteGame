using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSimpsonsQuoteGame.Models
{
    public class QuestionViewModel
    {
        public string Question { get; set; }
        public List<string> PossibleAnswers { get; set; }
        public string Answer { get; set; }
    }
}
