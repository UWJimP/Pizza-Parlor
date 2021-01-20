using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing
{
    public class StoreTests
    {
        [Fact]
        private void Test_StoreExists()
        {
            //arrange
            var store = new Store();

            //act
            var actual = store;

            //assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_StoreProperties()
        {
            var store = new Store();
            var name = "Test Store";

            store.Name = name;
            Assert.True(store.Name == name);
            Assert.NotNull(store.Orders);
        }
        
        [Fact]
        private void Test_StoreDeleteMethod()
        {
            var store = new Store();
            var order = new Order();

            Assert.False(store.DeleteOrder(order));
            store.Orders.Add(order);
            Assert.True(store.DeleteOrder(order));
            Assert.True(store.Orders.Count == 0);
        }
    }
}
