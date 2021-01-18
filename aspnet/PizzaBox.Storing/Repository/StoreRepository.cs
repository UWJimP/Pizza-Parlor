using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Storing.Repository
{
    internal class StoreRepository : IStoreRepository
    {
        
        private readonly PizzaBoxContext _db;
/*         public StoreRepository(DbContextOptions<PizzaBoxContext> options)
        {
            _db = new PizzaBoxContext(options);
        } */
        
        public StoreRepository(PizzaBoxContext context)
        {
            _db = context;
        }

        public Store GetStoreByName(string name)
        {
            return _db.Set<Store>().FirstOrDefault(s => s.Name == name);
        }
        
        public IEnumerable<Order> GetUserOrders(User user)
        {
            var query = _db.Stores
            .Include(store => store.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Crust)
            .Include(store => store.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Size)
            .Include(store => store.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Toppings)
            .FirstOrDefault<Store>(s => s.EntityID == user.SelectedStore.EntityID);
            return query.Orders;
        }
        
        public IEnumerable<Order> GetOrdersByStore(Store store)
        {
            var query = _db.Stores
            .Include(store => store.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Crust)
            .Include(store => store.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Size)
            .Include(store => store.Orders)
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Toppings)
            .FirstOrDefault<Store>(s => s.EntityID == store.EntityID);
            return query.Orders;
        }
        
        public IEnumerable<Order> ReadStoreOrdersByUser(Store store, User user)
        {
            var query = _db.Stores
            .Include(store => store.Orders
                .Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Crust)
            .Include(store => store.Orders
                .Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Size)
            .Include(store => store.Orders
                .Where(o => o.UserEntityID == user.EntityID))
                .ThenInclude(order => order.Pizzas)
                    .ThenInclude(pizza => pizza.Toppings)
            .FirstOrDefault<Store>(s => s.EntityID == store.EntityID);
            return query.Orders;
        }
        
        public IEnumerable<Order> GetOrderByDateRange(Store store, DateTime startDate, int days)
        {
            var endDate = startDate.Date.AddDays(days);
            var query = _db.Stores
            .Include(s => s.Orders
                .Where(o => o.Date >= startDate && o.Date <= endDate))
                .ThenInclude(o => o.Pizzas)
                    .ThenInclude(o => o.Size)
            .Include(s => s.Orders
                .Where(o => o.Date >= startDate && o.Date <= endDate))
                .ThenInclude(o => o.Pizzas)
                    .ThenInclude(o => o.Crust)
            .Include(s => s.Orders
                .Where(o => o.Date >= startDate && o.Date <= endDate))
                .ThenInclude(o => o.Pizzas)
                    .ThenInclude(o => o.Toppings)
            .FirstOrDefault<Store>(s => s.EntityID == store.EntityID).Orders;
            return query;
        }
    }
}
