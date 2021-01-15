using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Interfaces
{
    public interface IStoreRepository
    {
        public IEnumerable<Order> GetUserOrders(User user);
        public IEnumerable<Order> GetOrdersByStore(Store store);
        public IEnumerable<Order> ReadStoreOrdersByUser(Store store, User user);
        public IEnumerable<Order> GetOrderByDateRange(Store store, DateTime startDate, int days);
    }
}