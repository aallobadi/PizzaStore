using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace PizzaStore.Models
{
    public class Topping
    {
        public Topping(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        
    }
}