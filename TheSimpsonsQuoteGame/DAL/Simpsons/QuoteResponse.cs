using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSimpsonsQuoteGame.SimpsonsServices
{
    public class QuoteResponse
    {
        public string Quote { get; set; }
        public string Character { get; set; }
        public string Image { get; set; }
        public string ChracterDirection { get; set; }
    }


    public class QuoteObjectResponse
    {
        public QuoteResponse[] QuoteResponse { get; set; }
    }


}
