using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factory
{
    public class PizzaFactory
    {
        
        private static readonly List<string> _pizzas = new List<string>()
        {
            "cheese", "pepperoni", "combo", "hawaiian"
        };
        
        private PizzaFactory(){}
        
        public static Pizza MakePizza(string pizza)
        {
            var madePizza = new Pizza();
            madePizza.Name = pizza.ToLower();
            madePizza.AddTopping(APizzaPartFactory.MakeTopping("cheese"));
            madePizza.AddTopping(APizzaPartFactory.MakeTopping("sauce"));
            switch(pizza.ToLower())
            {
                case "pepperoni":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    return madePizza;
                case "combo":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pepperoni"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("sausage"));
                    return madePizza;
                case "hawaiian":
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("pineapple"));
                    madePizza.AddTopping(APizzaPartFactory.MakeTopping("ham"));
                    return madePizza;
                default:
                    madePizza.Name = "cheese";
                    return madePizza;
            }
        }
        
        public static List<string> GetAllPizzaStrings()
        {
            return _pizzas;
        }
    }
}
