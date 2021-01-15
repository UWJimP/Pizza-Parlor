using PizzaBox.Domain.Abstract;

namespace PizzaBox.Domain.Models
{
    public class Size : APizzaPart
    {
        public Size(){}
        public Size(string name, double price) : base(name, price){}
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
