using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly UnitOfWork _context;

        public OrderController(UnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("/stores")]
        public IActionResult Stores(CustomerViewModel model)
        {
            model.Order = new OrderViewModel()
            {
                Stores = _context.GetAll<Store>().ToList()
            };
            return View("Stores", model);
        }

        [HttpGet("/pizza")]
        public IActionResult Pizza(CustomerViewModel model)
        {
            model.Name = (string)TempData["Name"];
            model.Pizza.Crusts = _context.GetAll<Crust>().ToList();
            model.Pizza.Sizes = _context.GetAll<Size>().ToList();

            return View("Order", model);
        }

        [HttpPost("/addpizza")]
        [ValidateAntiForgeryToken]
        public IActionResult AddPizza(CustomerViewModel model)
        {
            model.Name = (string)TempData["Name"];
            model.Order.Store = (string)TempData["Store"];

            var pizza = new Pizza();
            pizza.Name = "custom";
            pizza.Crust = _context.GetAPizzaPartByName<Crust>(model.Pizza.Crust);
            pizza.Size = _context.GetAPizzaPartByName<Size>(model.Pizza.Size);
            foreach(var topping in model.Pizza.Toppings)
            {
                if(topping.Selected)
                {
                    pizza.AddTopping(topping.Topping);
                }
            }
            model.Pizza.Pizzas.Add(pizza);
            model.Pizza.Crusts = _context.GetAll<Crust>().ToList();
            model.Pizza.Sizes = _context.GetAll<Size>().ToList();
            return View("Order", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(OrderViewModel model)
        {
            if(ModelState.IsValid)
            {
                var order = new Order(){};
                return View("OrderPlaced");
            }
            return View("home", model);
        }
    }
}
