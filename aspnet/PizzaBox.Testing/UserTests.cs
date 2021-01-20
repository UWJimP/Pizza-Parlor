using PizzaBox.Domain.Factory;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        private void Test_UserExists()
        {
            //arrange
            var user = new User();

            //act
            var actual = user;
            user.Name = "Test";

            //assert
            Assert.IsType<User>(actual);
            Assert.NotNull(actual);
            Assert.True(actual.Name == "Test");
        }
        
        [Fact]
        private void Test_UserAddOrders()
        {
            var user = new User();

            Assert.NotNull(user.Orders);
            Assert.True(user.Orders.Count == 0);

            var order = new Order();
            Assert.True(user.AddOrder(order));
            Assert.True(user.Orders.Count == 1);
        }
    }
}
