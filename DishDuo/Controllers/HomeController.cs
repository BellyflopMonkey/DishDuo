using DishDuo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DishDuo.Controllers
{
    //JB this is the home controller
    public class HomeController : Controller
    {
        //JB logger instance
        private readonly ILogger<HomeController> _logger;

        //JB constructor for the home controller
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //JB this action returns the Index view
        public IActionResult Index()
        {
            return View();
        }

        //JB this action returns the privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        //JB this action returns the Error view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
