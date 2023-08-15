using DeckOfCardsLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Index()
        {
            DrawCardsModel result = DrawCardsDAL.Draw5Cards(5);
            if (result.remaining <= 0)
            {
                DrawCardsDAL.Reshuffle();
            }
            return View(result);
            
        }

        [HttpPost]
        public IActionResult Index(string card0, string card1, string card2, string card3, string card4)
        {
            int newCardCount = 5;       // any unselected card becomes null 
            if(card0 != null)
            {
                newCardCount--;
            }
            if (card1 != null)
            {
                newCardCount--;
            }
            if (card2 != null)
            {
                newCardCount--;
            }
            if (card3 != null)
            {
                newCardCount--;
            }
            if (card4 != null)
            {
                newCardCount--;
            }

            DrawCardsModel result = DrawCardsDAL.Draw5Cards(newCardCount);
            if (result.remaining <= 0)
            {
                DrawCardsDAL.Reshuffle();
            }

            if (card0 != null)          // added back cards that were unselected back to hand
            {
                Card c = new Card();
                c.image = card0;
                result.cards.Add(c);
            }
            if (card1 != null)
            {
                Card c = new Card();
                c.image = card1;
                result.cards.Add(c);
            }
            if (card2 != null)
            {
                Card c = new Card();
                c.image = card2;
                result.cards.Add(c);
            }
            if (card3 != null)
            {
                Card c = new Card();
                c.image = card3;
                result.cards.Add(c);
            }
            if (card4 != null)
            {
                Card c = new Card();
                c.image = card4;
                result.cards.Add(c);
            }
            return View(result);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}