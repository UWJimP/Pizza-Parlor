using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Interfaces
{
    public interface IUserRepository
    {
        public User GetUserByName(string name);

        //TODO Get user's last order date

        //TODO: Check if the user ordered from a store within the last 24 hours

        //TODO: Check if the user has ordered within the last 2 hours.
    }
}
