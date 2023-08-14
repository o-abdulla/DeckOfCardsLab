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


        
        public IActionResult Index()
        {
            DrawCardsModel result = DrawCardsDAL.Draw5Cards();
            if (result.remaining <= 0)
            {
                DrawCardsDAL.Reshuffle();
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