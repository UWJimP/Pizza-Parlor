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
    }
}
