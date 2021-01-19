using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class OrderViewModel
    {
        public List<Store> Stores { get; set; }
        
        [Required]
        public string Store { get; set; }

        [Required]
        public List<Pizza> Pizzas { get; set; }

        public OrderViewModel()
        {
            Pizzas = new List<Pizza>();
        }

        public double GetTotalAmount()
        {
            double total = 0;
            if(Pizzas != null)
            {
                foreach(var pizza in Pizzas)
                {
                    total += pizza.GetTotalCost();
                }
            }
            return total;
        }
    }
}
