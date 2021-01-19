using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
    public class HistoryViewModel
    {
        public string Customer { get; set; }

        public Order Order { get; set; }

        public string Store { get; set; }

        public HistoryViewModel(){}
    }
}
