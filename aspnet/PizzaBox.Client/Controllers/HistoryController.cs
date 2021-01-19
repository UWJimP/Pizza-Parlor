using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class HistoryController : Controller
    {
        private readonly UnitOfWork _context;

        public HistoryController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("/userhistory")]
        public IActionResult UserHistory(CustomerViewModel model)
        {
            model.History = new List<HistoryViewModel>();
            var user = _context.GetUserByName(model.Name);
            var orders = _context.GetUserOrders(user).ToList();
            foreach(var order in orders)
            {
                var history = new HistoryViewModel()
                {
                    Customer = null,
                    Order = order,
                    Store = _context.Get<Store>(order.StoreEntityID).Name
                };
                model.History.Add(history);
            }

            return View("OrderHistory", model);
        }
    }
}
