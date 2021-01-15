using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PizzaBox.Domain.Abstract;

namespace PizzaBox.Domain.Models
{
    public class User : AEntity
    {
        
        public string Name { get; set; }
        
        [NotMapped]
        public Store SelectedStore { get; set; }
        
        public virtual List<Order> Orders { get; set; }
        
        public User()
        {
            if(Orders == null)
            {
                Orders = new List<Order>();
            }
        }
        
        public bool AddOrder(Order order)
        {
            if(Orders.Count() == 0) //Checks if the user is new.
            {
                Orders.Add(order);
                return true;
            }
            TimeSpan lastOrderTime = order.Date - Orders.Last().Date;
            TimeSpan checkTime = new TimeSpan(2, 0, 0);
            if(TimeSpan.Compare(lastOrderTime, checkTime) == 1)
            {
                Orders.Add(order);
                return true;
            }
            return false;
        }
        
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
