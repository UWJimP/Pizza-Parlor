using PizzaBox.Domain.Models;
using PizzaBox.Domain.Factory;
using Xunit;

namespace PizzaBox.Testing
{
    public class PizzaTests
    {
        [Fact]
        private void Test_PizzaExists()
        {
            //arrange
            var pizza = new Pizza();

            //act
            var actual = pizza;

            //assert
            Assert.IsType<Pizza>(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        private void Test_PizzaAddTopping()
        {
            var pizza = new Pizza();

            var topping1 = APizzaPartFactory.MakeTopping("cheese");
            var topping2 = APizzaPartFactory.MakeTopping("sauce");
            var topping3 = APizzaPartFactory.MakeTopping("pepperoni");
            var topping4 = APizzaPartFactory.MakeTopping("pineapple");
            var topping5 = APizzaPartFactory.MakeTopping("olive");
            var topping6 = APizzaPartFactory.MakeTopping("sausage");
            
            Assert.NotNull(pizza.Toppings);
            Assert.True(pizza.AddTopping(topping1));
            Assert.True(pizza.AddTopping(topping2));
            Assert.True(pizza.AddTopping(topping3));
            Assert.True(pizza.AddTopping(topping4));
            Assert.True(pizza.AddTopping(topping5));
            Assert.False(pizza.AddTopping(topping6));
        }
        [Fact]
        private void Test_PizzaGetTotalCost()
        {
            var pizza = new Pizza();

            var topping1 = APizzaPartFactory.MakeTopping("cheese");
            var topping2 = APizzaPartFactory.MakeTopping("sauce");
            var crust = APizzaPartFactory.MakeCrust("regular");
            var size = APizzaPartFactory.MakeSize("medium");
            var amount = 1d + topping1.Price + topping2.Price + crust.Price + size.Price;

            pizza.AddTopping(topping1);
            pizza.AddTopping(topping2);
            pizza.Crust = crust;
            pizza.Size = size;
            Assert.True(pizza.GetTotalCost() == amount);
        }
    }
}
