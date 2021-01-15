using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Factory
{
    public class APizzaPartFactory
    {
        private APizzaPartFactory(){}
        public static Size MakeSize(string size)
        {
            switch(size.ToLower())
            {
                case "large":
                    return new Size("large", 3d);
                case "medium":
                    return new Size("medium", 2d);
                default:
                    return new Size("small", 1d);
            }
        }
        public static Crust MakeCrust(string crust)
        {
            switch(crust.ToLower())
            {
                case "thin":
                    return new Crust("thin", 1.5d);
                case "pan":
                    return new Crust("pan", 1.75d);
                default:
                    return new Crust("regular", 1d);
            }
        }
        public static Topping MakeTopping(string topping)
        {
            switch(topping.ToLower())
            {
                case "pepperoni":
                    return new Topping("pepperoni");
                case "sausage":
                    return new Topping("sausage");
                case "pineapple":
                    return new Topping("pineapple");
                case "ham":
                    return new Topping("ham");
                case "onion":
                    return new Topping("onion");
                case "mushroom":
                    return new Topping("mushroom");
                case "olive":
                    return new Topping("olive");
                case "sauce":
                    return new Topping("sauce", 2d);
                default:
                    return new Topping("cheese", 1d);
            }
        }
        public static List<Topping> GetToppings()
        {
            return new List<Topping>()
            {
                new Topping("cheese", 1d), new Topping("sauce", 2d), new Topping("pepperoni"), 
                new Topping("sausage"), new Topping("pineapple"), new Topping("ham"),
                new Topping("onion"), new Topping("mushroom"), new Topping("olive") 
            };
        }
    }
}
