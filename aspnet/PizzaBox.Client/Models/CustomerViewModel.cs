using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        [Required]
        public string Name { get; set; }
        
        public OrderViewModel Order { get; set; }

        public PizzaViewModel Pizza { get; set; }

        public List<HistoryViewModel> History { get; set; }

        public bool CanOrder { get; set; }

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
            History = new List<HistoryViewModel>();
        }
    }
}
