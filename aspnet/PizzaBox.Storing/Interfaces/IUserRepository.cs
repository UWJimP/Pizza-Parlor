using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Interfaces
{
    public interface IUserRepository
    {
        public User GetUserByName(string name);

        public DateTime GetUserLastOrderDate(User user);

        public bool UserCanOrderFromStore(User user, Store store);

        public bool UserCanOrder(User user);
    }
}
