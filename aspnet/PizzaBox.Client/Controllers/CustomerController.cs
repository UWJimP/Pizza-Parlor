using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly UnitOfWork _context;
        
        public CustomerController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("home/")]
        public IActionResult Home(CustomerViewModel model)
        {
            if(model == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Check if the user is there. If not, make a new user.
            model.User = _context.GetUserByName(model.Name);
            if(model.User == null)
            {
                var user = new User()
                {
                    Name = model.Name
                };
                _context.Add<User>(user);
                _context.SaveChanges();
            }

            return View("MainMenu", model);
        }

        [HttpGet("/menu")]
        public IActionResult Menu(string button)
        {
            var name = TempData["Name"];
            var model = new CustomerViewModel()
            {
              Name = (string)name,
              User = _context.GetUserByName((string)name)
            };
            switch(button)
            {
                case "order":
                    model.Order = new OrderViewModel
                    {
                        Stores = _context.GetAll<Store>().ToList()
                    };
                    return RedirectToAction("Stores", "Order", model);
                case "history":
                    return View();
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}
