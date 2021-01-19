using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly UnitOfWork _context;
        
        public AdminController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("/admin")]
        public IActionResult AdminHome()
        {
            return View("AdminMenu");
        }

        [HttpGet("/adminmenu")]
        public IActionResult AdminMenu(string button)
        {
            switch(button)
            {
                case "order":
                    AdminHistoryViewModel history = new AdminHistoryViewModel();
                    history.Customer = "";
                    return View("UserOrders", history);
                case "revenue":
                    return View("Revenue", null);
                default:
                    return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("/searchuser")]
        [ValidateAntiForgeryToken]
        public IActionResult SearchUser(string name)
        {
            AdminHistoryViewModel history = new AdminHistoryViewModel();
            var user = _context.GetUserByName(name.Trim());
            if(user == null)
            {
                return View("UserOrders", null);
            }

            history.Customer = user.Name;
            var orders = _context.GetUserOrders(user).ToList();
            foreach(var order in orders)
            {
                var historyItem = new HistoryViewModel();

                historyItem.Customer = user.Name;
                historyItem.Store = _context.GetStoreByID(order.StoreEntityID).Name;
                historyItem.Order = order;

                history.Orders.Add(historyItem);
            }

            return View("UserOrders", history);
        }

        [HttpPost("/searchrevenue")]
        [ValidateAntiForgeryToken]
        public IActionResult SearchRevenue(int days)
        {
            if(days < 7)
            {
                return View("AdminMenu");
            }
            var model = new RevenueViewModel();
            var orders = _context.GetOrdersByDateRange(model.Today, days);
            
            foreach(var order in orders)
            {
                var customer = _context.Get<User>(order.UserEntityID);
                var store = _context.GetStoreByID(order.StoreEntityID);
                var history = new HistoryViewModel();

                history.Customer = customer.Name;
                history.Store = store.Name;
                history.Order = order;

                model.PizzaAmount += order.Pizzas.Count;
                model.SalesTotal += order.GetTotalAmount();
                model.History.Add(history);
            }

            return View("Revenue", model);
        }
    }
}
