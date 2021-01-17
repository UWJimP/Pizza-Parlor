using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        public string Name { get; set; }

        [Required]
        public User user { get; set; }
        
        public OrderViewModel Order { get; set; }

        public CustomerViewModel()
        {
            Order = new OrderViewModel();
        }
    }
}
