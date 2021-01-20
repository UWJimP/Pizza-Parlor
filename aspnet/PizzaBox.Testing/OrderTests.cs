using PizzaBox.Domain.Models;
using PizzaBox.Domain.Factory;
using Xunit;
using System.Linq;

namespace PizzaBox.Testing
{
    public class OrderTests
    {
        [Fact]
        private void Test_OrderExists()
        {
            //arrange
            var order = new Order();

            //act
            var actual = order;

            //assert
            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_OrderAddPizza()
        {
            var order1 = new Order();
            var order2 = new Order();

            var pizza = new Pizza();
            var pizza2 = new Pizza();
            pizza2.Crust = APizzaPartFactory.MakeCrust("regular");
            pizza2.Size = APizzaPartFactory.MakeSize("large");

            Assert.True(pizza2.GetTotalCost() == 5d);
            Assert.False(order1.AddPizza(null));
            for(int amount = 0; amount < 50; amount++)
            {
                Assert.True(order1.AddPizza(pizza));
            }
            Assert.False(order1.AddPizza(pizza));
            for(int amount = 0; amount < 50; amount++)
            {
                Assert.True(order2.AddPizza(pizza2));
            }
            Assert.False(order2.AddPizza(pizza2));
        }

        [Fact]
        private static void Test_OrderRemovePizza()
        {
            var order = new Order();
            var pizza = new Pizza();

            order.AddPizza(pizza);

            Assert.True(order.Pizzas.Count() == 1);
            
            order.RemovePizza(0);
            Assert.True(order.Pizzas.Count() == 0);
        }

        [Fact]
        private static void Test_OrderGetTotalAmount()
        {
            var order = new Order();
            var pizza = new Pizza();
            var topping1 = APizzaPartFactory.MakeTopping("cheese");
            var topping2 = APizzaPartFactory.MakeTopping("sauce");

            pizza.Crust = APizzaPartFactory.MakeCrust("regular");
            pizza.Size = APizzaPartFactory.MakeSize("large");
            pizza.AddTopping(topping1);
            pizza.AddTopping(topping2);
            order.AddPizza(pizza);

            var total = 1d + pizza.Crust.Price + pizza.Size.Price + topping1.Price + topping2.Price;

            Assert.True(order.GetTotalAmount() == total);
        }
    }
}
