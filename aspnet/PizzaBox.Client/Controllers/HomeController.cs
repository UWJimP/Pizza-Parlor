using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
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
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string name)
        {
            var trimName = name.Trim();
            if(trimName.ToLower() == "admin")
            {
                //TODO: Implement Admin View here.
                return View("Index"); 
            }
            else if(string.IsNullOrEmpty(trimName))
            {
                return View("Index");
            }
            else
            {
                var model = new CustomerViewModel()
                {
                    Name = trimName
                };
                return RedirectToAction("Home", "Customer", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
