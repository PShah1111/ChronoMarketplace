using ChronoMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChronoMarketplace.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult NewArrivals()
        {
            return View();
        }
        public IActionResult AllWatches()
        {
            return View();
        }
        public IActionResult Brands()
        {
            return View();
        }
        public IActionResult Accessories()
        {
            return View();
        }
        public IActionResult SellNow()
        {
            return View();
        }
        public IActionResult SellingForm()
        {
            return View();
        }
        public IActionResult TermsandConditions()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Cart()
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
