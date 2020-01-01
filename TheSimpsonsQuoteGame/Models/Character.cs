using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSimpsonsQuoteGame.Models
{
    public class Character
    {
        public List<string> Characters { get; set; }

        public Character()
        {
            Characters = new List<string>(new string[] {
             "Marge Simpson", 
             "Bart Simpson", 
             "Homer Simpson"
            });
        }

    }
}
