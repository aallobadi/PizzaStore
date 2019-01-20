using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStore.Models
{
    public class PizzaAndToppingViewModel
    {
        public IList<SelectListItem> SelectedToppings { get; set; }

        public Pizza Pizza { get; set; }
        public List<Topping> Topping { get; set; }
    }
}