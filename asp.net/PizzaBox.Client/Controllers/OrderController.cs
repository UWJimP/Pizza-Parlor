using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly UnitOfWork _context;

        public OrderController(UnitOfWork context)
        {
            _context = context;
        }

/*         [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(OrderViewModel model)
        {
            if(ModelState.IsValid)
            {
                var order = new Order()
                {
                };
            }
        } */
    }
}
