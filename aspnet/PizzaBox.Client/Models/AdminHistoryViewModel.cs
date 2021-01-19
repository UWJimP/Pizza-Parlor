using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class AdminHistoryViewModel
    {
        public string Customer { get; set; }

        public List<HistoryViewModel> Orders { get; set; }

        public List<Store> Stores { get; set; }

        public AdminHistoryViewModel()
        {
            Orders = new List<HistoryViewModel>();
        }
    }
}
