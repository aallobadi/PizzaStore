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

       

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        // GET: Store/Order
        public ActionResult Order()
        {
            var pizza = new Pizza
                { Name = "Ham Pizza",

                  SizeList = new List<Size>
                  {
                      new Size{Type = "Small", Price = 6.5},
                      new Size{Type = "Medium", Price = 8.8},
                      new Size{Type = "Large", Price = 11.11}


                  }
            };

            List<Topping> listTopping = new List<Topping>()
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
            

            var model = new PizzaAndToppingViewModel { Pizza = pizza, Topping = listTopping};


            return View(model);
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
            switch (size)
            {
                case "small":
                    total += 6.5;
                    break;
                case "medium":
                    total += 8.8;
                    break;
                case "large":
                    total += 11.11;
                    break;
            }

           // Session["total"] = total;
            
           var toppings = string.Join(",", frm["SelectedToppings"]);


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