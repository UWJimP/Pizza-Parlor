using System.Linq;
using PizzaBox.Domain.Abstract;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Storing.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaBoxContext _context;

        public PizzaRepository(PizzaBoxContext context)
        {
            _context = context;
        }

        public T GetAPizzaPartByName<T>(string name) where T : APizzaPart
        {
            return _context.Set<T>().FirstOrDefault(part => part.Name == name);
        }
    }
}
