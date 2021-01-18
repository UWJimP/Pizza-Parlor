using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        [Required]
        public string Name { get; set; }

        //[Required]
        //public User User { get; set; }
        
        public OrderViewModel Order { get; set; }

        public PizzaViewModel Pizza { get; set; }

        public CustomerViewModel()
        {
            if(Order == null)
            {
                Order = new OrderViewModel();
            }
            if(Pizza == null)
            {
                Pizza = new PizzaViewModel();
            }
        }
    }
}
