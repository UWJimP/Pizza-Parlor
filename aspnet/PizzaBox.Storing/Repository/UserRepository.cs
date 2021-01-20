using System;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Storing.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PizzaBoxContext _context;

        public UserRepository(PizzaBoxContext context)
        {
            _context = context;
        }

        public User GetUserByName(string name)
        {
            return _context.Set<User>().ToList().FirstOrDefault(user => user.Name == name);
        }

        public DateTime GetUserLastOrderDate(User user)
        {
            var lastOrder = _context.Set<Order>().ToList()
                .LastOrDefault(order => order.UserEntityID == user.EntityID);
            return lastOrder.Date;
        }

        public bool UserCanOrder(User user)
        {
            var lastOrder = _context.Set<Order>().ToList()
                .LastOrDefault(order => order.UserEntityID == user.EntityID);
            if(lastOrder != null)
            {
                TimeSpan lastOrderTime = DateTime.Now - lastOrder.Date;
                TimeSpan checkTime = new TimeSpan(2, 0, 0);
                if(TimeSpan.Compare(lastOrderTime, checkTime) != 1){
                    return false;
                }
            }
            return true;
        }

        public bool UserCanOrderFromStore(User user, Store store)
        {
            var lastOrder = _context.Set<Order>().ToList()
                .LastOrDefault(order => order.UserEntityID == user.EntityID
                && order.StoreEntityID == store.EntityID);
            if(lastOrder != null)
            {
                TimeSpan lastOrderTime = DateTime.Now - lastOrder.Date;
                TimeSpan checkTime = new TimeSpan(24, 0, 0);
                if(TimeSpan.Compare(lastOrderTime, checkTime) != 1){
                    return false;
                }
            }
            return true;
        }
    }
}
