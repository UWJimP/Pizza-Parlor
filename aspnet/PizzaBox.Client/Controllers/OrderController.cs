using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Client.PersistData;
using PizzaBox.Domain.Factory;
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
            model.Pizza = new PizzaViewModel();
            model.Pizza.Crusts = _context.GetAll<Crust>().ToList();
            model.Pizza.Sizes = _context.GetAll<Size>().ToList();
            model.Pizza.SetToppings();
            model.Order.Pizzas.Add(pizza);

            return View("Order", model);
        }

        [HttpPost("/removepizza")]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePizza(int value)
        {
            CustomerViewModel model = TempData.Get<CustomerViewModel>("Customer");
            model.Pizza.SetToppings();
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
            else if(button == "finish")
            {
                var store = _context.GetStoreByName(model.Order.Store);
                var user = _context.GetUserByName(model.Name);
                var order = new Order();
                foreach(var pizza in model.Order.Pizzas)
                {
                    var madePizza = new Pizza();
                    madePizza.Name = "custom";
                    madePizza.Crust = _context.GetAPizzaPartByName<Crust>(pizza.Crust.Name);
                    madePizza.Size = _context.GetAPizzaPartByName<Size>(pizza.Size.Name);
                    madePizza.Toppings = new List<Topping>();
                    foreach(var topping in pizza.Toppings)
                    {
                        madePizza.Toppings.Add(APizzaPartFactory.MakeTopping(topping.Name));
                    }

                    order.AddPizza(madePizza);
                }
                store.Orders.Add(order);
                user.Orders.Add(order);
                _context.SaveChanges();
                return View("OrderPlaced", model);
            }
            return View("home", model);
        }

        [HttpGet("/done")]
        public IActionResult Done(string button)
        {
            var model = new CustomerViewModel();
            model.Name = button;
            model.Order = new OrderViewModel();
            model.Pizza = new PizzaViewModel();

            return RedirectToAction("Home", "Customer", model);
        }
    }
}
