using System.Collections.Generic;
using System.Text;
using PizzaBox.Domain.Abstract;

namespace PizzaBox.Domain.Models
{
    public class Pizza : AEntity
    {
        public Crust Crust { get; set; }
        public Size Size { get; set; }
        public string Name { get; set; }
        public virtual List<Topping> Toppings { get; set; }
        public Pizza()
        {
            if(Toppings == null)
            {
                DefaultToppings();
            }
        }
        public double GetTotalCost()
        {
            double total = 1d; //Base price of pizza without anything.
            if(Crust != null)
            {
                total += Crust.Price;
            }
            if(Size != null)
            {
                total += Size.Price;
            }
            foreach(var topping in Toppings)
            {
                total += topping.Price;
            }
            return total;
        }
        public bool AddTopping(Topping topping)
        {
            if(Toppings == null)
            {
                DefaultToppings();
            }
            if(Toppings.Count < 5)
            {
                Toppings.Add(topping);
                return true;
            }
            return false;
        }
        private void DefaultToppings()
        {
            Toppings = new List<Topping>();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder($"{Name} pizza: ");
            stringBuilder.Append($"price: ${GetTotalCost()} ");
            if(Crust != null)
            {
                stringBuilder.Append($"Crust: {Crust} ");
            }
            if(Size != null)
            {
                stringBuilder.Append($"Size: {Size} ");
            }
            stringBuilder.Append("Ingredients: ");
            foreach(var topping in Toppings)
            {
                stringBuilder.Append($"{topping} ");
            }
            return stringBuilder.ToString();
        }
    }
}
