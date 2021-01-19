using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public class RevenueViewModel
    {
        public DateTime Today { get; set; }

        public int PizzaAmount { get; set; }

        public double SalesTotal { get; set; }

        public List<HistoryViewModel> History { get; set; }

        public RevenueViewModel()
        {
            History = new List<HistoryViewModel>();
            Today = DateTime.Now;
        }
    }
}
