namespace PizzaBox.Client.Models
{
    public class CustomerViewModel
    {
        public string Name { get; set; }

        public OrderViewModel Order { get; set; }

        public CustomerViewModel()
        {
            Order = new OrderViewModel();
        }
    }
}
