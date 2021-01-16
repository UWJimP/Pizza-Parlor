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
        public IActionResult Home()
        {
            var customer = new CustomerViewModel();

            customer.Order = new OrderViewModel()
            {
                Stores = _context.GetAll<Store>().ToList()
            };

            return View("Home", customer);
        }
    }
}
