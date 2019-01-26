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
            Name = "Margherita",
        };

        Size smallPizza = new Size(Type: "Small", Price: 6.5);
        Size mediumPizza = new Size(Type: "Medium", Price: 8.8);
        Size largePizza = new Size(Type: "Large", Price: 11.11);
        
        static Topping hamTopping = new Topping(Name: "Ham", Price: 6.5);
        static Topping sausageTopping = new Topping(Name: "Italian Sausage", Price: 3.33);
        static Topping baconTopping = new Topping(Name: "Bacon", Price: 2.99);
        static Topping beefTopping = new Topping(Name: "Beef", Price: 5.05);

        public IList<Topping> LToppings = new List<Topping>(){ hamTopping, sausageTopping, baconTopping, beefTopping };
        private static double _TAX = 0.06; 
        
        // GET: Store
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: Store/Order
        public ActionResult Order()
        {
            ViewBag.smallPizza = smallPizza;
            ViewBag.mediumPizza = mediumPizza;
            ViewBag.largePizza = largePizza;

            var viewModel = new PizzaAndToppingViewModel { Pizza = pizza, Toppings = LToppings };

            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Confirm(FormCollection frm)
        {
            var amount_before_tax = 0.0;
            string size = frm["size"];

            if (size == null)
            {
                size = "small";
            }
            
            switch (size)
            {
                case "small":
                    amount_before_tax += smallPizza.Price;
                    break;
                case "medium":
                    amount_before_tax += mediumPizza.Price;
                    break;
                case "large":
                    amount_before_tax += largePizza.Price;
                    break;
            }
            
            var toppings = frm["SelectedToppings"];

            if (toppings != null)
            {
                Session["toppings"] = toppings;
                if (toppings.Contains("Italian Sausage"))
                {
                    amount_before_tax += sausageTopping.Price;
                }

                if (toppings.Contains("Ham"))
                {
                    amount_before_tax += hamTopping.Price;
                }

                if (toppings.Contains("Bacon"))
                {
                    amount_before_tax += baconTopping.Price;
                }

                if (toppings.Contains("Beef"))
                {
                    amount_before_tax += baconTopping.Price;
                }
            }

            var taxable = amount_before_tax * _TAX;
            var total = taxable + amount_before_tax;

            // Saving the order data
            Session["size"] = size;
            Session["pizza"] = pizza.Name;

            // Saving the invoice data
            Session["amount_before_tax"] = amount_before_tax;
            Session["tax"] = taxable;
            Session["total"] = total;

            return View();
        }

        public ActionResult Reset()
        {
            Session.Abandon();

            return RedirectToAction("Order", "Store");
        }

    }
}