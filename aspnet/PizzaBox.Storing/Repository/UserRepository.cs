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
    }
}
