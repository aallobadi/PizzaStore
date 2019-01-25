using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStore.Models
{
    public class PizzaAndToppingViewModel
    {
        public Pizza Pizza { get; set; }
        public Size Size { get; set; }
        public IEnumerable<Topping> Toppings { get; set; }
    }
}