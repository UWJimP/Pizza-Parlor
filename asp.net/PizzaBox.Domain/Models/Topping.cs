using PizzaBox.Domain.Abstract;

namespace PizzaBox.Domain.Models
{
    public class Topping : APizzaPart
    {
        
        public Topping(){}
        
        public Topping(string name) : base(name, 0.75d){}
        
        public Topping(string name, double price) : base(name, price){}
        
        public override string ToString()
        {
            return $"{Name}: ${Price.ToString("0.00")}";
        }
    }
}
