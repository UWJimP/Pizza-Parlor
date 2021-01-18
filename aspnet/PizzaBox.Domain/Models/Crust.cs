using PizzaBox.Domain.Abstract;

namespace PizzaBox.Domain.Models
{
    public class Crust : APizzaPart
    {
        
        public Crust(){}
        
        public Crust(string name, double price) : base(name, price){}

        public override string ToString()
        {
            return $"{Name}: ${Price.ToString("0.00")}";
        }
    }
}
