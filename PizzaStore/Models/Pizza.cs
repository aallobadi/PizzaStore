using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStore.Models
{
    public class Pizza
    {
        public string Name { get; set; }
    }

    public class Size
    {
        public Size(string Type, double Price)
        {
            this.Type = Type;
            this.Price = Price;
        }

        public string Type { get; set; }
        public double Price { get; set; }
    }
}