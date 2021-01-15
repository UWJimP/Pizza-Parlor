using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstract;

namespace PizzaBox.Domain.Models
{
    public class Order : AEntity
    {
        public long StoreEntityID { get; set; }
        public long UserEntityID { get; set; }
        public DateTime Date { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public Order()
        {
            Date = DateTime.Now;
            Pizzas = new List<Pizza>();
        }
        public bool AddPizza(Pizza pizza)
        {
            if(pizza != null && pizza.GetTotalCost() + GetTotalAmount() <= 250d && Pizzas.Count < 50)
            {
                Pizzas.Add(pizza);
                return true;
            }
            return false;
        }
        public void RemovePizza(int index)
        {
            if(index >= 0 && index < Pizzas.Count())
            {
                Pizzas.RemoveAt(index);
            }
        }
        public double GetTotalAmount()
        {
            double cost = 0;
            if(Pizzas == null)
            {
                Pizzas = new List<Pizza>();
            }
            foreach(var pizza in Pizzas)
            {
                cost += pizza.GetTotalCost();
            }
            return cost;
        }
        public override string ToString()
        {
            return $"{Date}: pizzas: {Pizzas.Count()}";
        }
    }
}
