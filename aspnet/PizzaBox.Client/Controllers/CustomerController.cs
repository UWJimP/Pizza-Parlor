using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Client.PersistData;
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
                model = TempData.Get<CustomerViewModel>("Customer");
                if(model == null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            //Check if the user is there. If not, make a new user.
            User user = _context.GetUserByName(model.Name);
            if(user == null)
            {
                user = new User()
                {
                    Name = model.Name
                };
                _context.Add<User>(user);
                _context.SaveChanges();
                //model.CanOrder = true;
            }
            model.CanOrder = _context.UserCanOrder(user);

            return View("MainMenu", model);
        }

        [HttpGet("/menu")]
        public IActionResult Menu(string button)
        {
            var customer = TempData.Get<CustomerViewModel>("Customer");
            var model = new CustomerViewModel();
            model.Name = customer.Name;
            switch(button)
            {
                case "order":
                    model.Order = new OrderViewModel
                    {
                        Stores = _context.GetAll<Store>().ToList()
                    };
                    return RedirectToAction("Stores", "Order", model);
                case "history":
                    return RedirectToAction("UserHistory", "History", model);
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
    }
}
