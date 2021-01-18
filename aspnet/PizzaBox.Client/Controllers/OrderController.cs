using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Client.PersistData;
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
            var store = model.Order.Store;
            model = TempData.Get<CustomerViewModel>("Customer");
            model.Pizza.Toppings = null;

            //Set up pizza orders layout values
            model.Pizza.Crusts = _context.GetAll<Crust>().ToList();
            model.Pizza.Sizes = _context.GetAll<Size>().ToList();
            model.Pizza.SetToppings();

            model.Order.Store = store;

            return View("Order", model);
        }

        [HttpPost("/addpizza")]
        [ValidateAntiForgeryToken]
        public IActionResult AddPizza(CustomerViewModel model)
        {
            var pizza = new Pizza();
            pizza.Name = "custom";
            foreach(var topping in model.Pizza.Toppings)
            {
                if(topping.Selected)
                {
                    pizza.AddTopping(topping.Topping);
                }
            }
            pizza.Crust = _context.GetAPizzaPartByName<Crust>(model.Pizza.Crust);
            pizza.Size = _context.GetAPizzaPartByName<Size>(model.Pizza.Size);

            model = TempData.Get<CustomerViewModel>("Customer");
            model.Pizza.SetToppings();
            //model.Pizza.Pizzas.Add(pizza);
            model.Order.Pizzas.Add(pizza);

            return View("Order", model);
        }

        [HttpPost("/removepizza")]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePizza(int value)
        {
            CustomerViewModel model = TempData.Get<CustomerViewModel>("Customer");
            model.Pizza.SetToppings();
            //model.Pizza.Pizzas.Add(pizza);
            model.Order.Pizzas.RemoveAt(value);

            return View("Order", model);
        }

        [HttpPost("/post")]
        [ValidateAntiForgeryToken]
        public IActionResult Post(CustomerViewModel model, string button)
        {
            model = TempData.Get<CustomerViewModel>("Customer");
            if(button == "cancel")
            {
                return RedirectToAction("Home", "Customer", model);
            }
            else if(button == "finish" && ModelState.IsValid)
            {
                var order = new Order(){};
                return View("OrderPlaced");
            }
            return View("home", model);
        }
    }
}
