using PizzaBox.Domain.Abstract;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Interfaces
{
    public interface IPizzaRepository
    {
        public T GetAPizzaPartByName<T>(string name) where T : APizzaPart;
    }
}
