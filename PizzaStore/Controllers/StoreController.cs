using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PizzaStore.Models;

namespace PizzaStore.Controllers
{
    public class StoreController : Controller
    {

        Pizza pizza = new Pizza
        {
            Name = "Ham Pizza",

        };

        Size SmallPizza = new Size(Type: "Small", Price: 6.5);
        Size MediumPizza = new Size(Type: "Medium", Price: 8.8);
        Size LargePizza = new Size(Type: "Large", Price: 11.11);


        IEnumerable<Topping> listTopping = new List<Topping>()
        {
            new Topping()
            {
                Name = "Italian Sausage",
                Price = 3.33
            },
            new Topping()
            {
                Name = "Ham",
                Price = 6.05
            },
            new Topping()
            {
                Name = "Bacon",
                Price = 2.99
            },
            new Topping()
            {
                Name = "Beef",
                Price = 5.05
            },
        };

     
        // GET: Store
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: Store/Order
        public ActionResult Order()
        {
            var viewModel = new PizzaAndToppingViewModel { Pizza = pizza, Toppings = listTopping };

            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Confirm(FormCollection frm)
        {
            var total = 0.0;
            string size = frm["size"];

            if (size == null)
            {
                size = "small";
            }

            ViewBag.size = size;

            switch (size)
            {
                case "small":
                    total += SmallPizza.Price;
                    break;
                case "medium":
                    total += MediumPizza.Price;
                    break;
                case "large":
                    total += LargePizza.Price;
                    break;
            }
            

            var toppings = frm["SelectedToppings"];

            ViewBag.toppings = toppings;

            if (toppings.Contains("Italian Sausage"))
            {
                total += 3.33;
            }

            if (toppings.Contains("Ham"))
            {
                total += 6.05;
            }

            if (toppings.Contains("Bacon"))
            {
                total += 2.99;
            }

            if (toppings.Contains("Beef"))
            {
                total += 5.05;
            }

            ViewBag.total = total;

            return View();
        }
    }
}