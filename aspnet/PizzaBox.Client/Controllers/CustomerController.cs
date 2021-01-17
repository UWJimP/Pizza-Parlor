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

        [HttpGet]
        public IActionResult Home(CustomerViewModel model)
        {
            if(model == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            model.user = _context.GetUserByName(model.Name);
            if(model.user == null)
            {
                var user = new User()
                {
                    Name = model.Name
                };
                _context.Add<User>(user);
                _context.SaveChanges();
            }

            model.Order = new OrderViewModel()
            {
                Stores = _context.GetAll<Store>().ToList()
            };

            return View("Home", model);
        }
    }
}
