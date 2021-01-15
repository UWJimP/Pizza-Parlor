using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Repository;

namespace PizzaBox.Client.Controllers
{
    public class ToppingsController : Controller
    {
        private readonly UnitOfWork _context;
        
        public ToppingsController(UnitOfWork context)
        {
            _context = context;
        }

    }
}
