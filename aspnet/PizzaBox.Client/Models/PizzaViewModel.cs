using System.Collections.Generic;
using PizzaBox.Domain.Factory;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class PizzaViewModel
    {
        public List<Crust> Crusts { get; set; }

        public List<Size> Sizes { get; set; }

        public List<SelectTopping> Toppings { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public string Crust { get; set; }

        public string Size { get; set; }

        public PizzaViewModel()
        {
            Pizzas = new List<Pizza>();
            //SetToppings();
        }

        public void SetToppings()
        {
            if(Toppings == null || Toppings.Count == 0)
            {
                Toppings = new List<SelectTopping>();
                foreach(var topping in APizzaPartFactory.GetToppings())
                {
                    Toppings.Add(new SelectTopping(){
                        Selected = false,
                        Topping = topping
                    });
                }
            }
        }
    }
    public class SelectTopping
    {
        public bool Selected { get; set; }

        public Topping Topping { get; set; }
    }
}
