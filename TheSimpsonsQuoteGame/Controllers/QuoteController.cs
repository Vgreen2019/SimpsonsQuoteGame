using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSimpsonsQuoteGame.Services.Simpsons;

namespace TheSimpsonsQuoteGame.Controllers
{
    public class QuoteController: Controller
    {
        private readonly ISimpsonsService _simpsonsService;

        public QuoteController(ISimpsonsService simpsonsService)
        {
            _simpsonsService = simpsonsService;
        }

        public async Task<IActionResult> GetQuestion()
        {
            var results = await _simpsonsService.PullRandomQuote();
            return View(results);
        }

        public IActionResult CheckAnswer(string answer)
        {
            var results = _simpsonsService.CheckAnswer(answer);
            return View(results);
        }
    }
}
