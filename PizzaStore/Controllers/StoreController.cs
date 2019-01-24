﻿using System;
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

        Size smallPizza = new Size(Type: "Small", Price: 6.5);
        Size mediumPizza = new Size(Type: "Medium", Price: 8.8);
        Size largePizza = new Size(Type: "Large", Price: 11.11);

        static Topping hamTopping = new Topping(Name: "Ham Topping", Price: 6.5);
        static Topping sausageTopping = new Topping(Name: "Italian Sausage", Price: 3.33);
        static Topping baconTopping = new Topping(Name: "Bacon Topping", Price: 2.99);
        static Topping beefTopping = new Topping(Name: "Beef Topping", Price: 5.05);

        public IList<Topping> LToppings = new List<Topping>(){ hamTopping, sausageTopping, baconTopping, beefTopping };

        

        // GET: Store
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: Store/Order
        public ActionResult Order()
        {
            var viewModel = new PizzaAndToppingViewModel { Pizza = pizza, Toppings = LToppings };

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
                    total += smallPizza.Price;
                    break;
                case "medium":
                    total += mediumPizza.Price;
                    break;
                case "large":
                    total += largePizza.Price;
                    break;
            }
            

            var toppings = frm["SelectedToppings"];

            if (toppings != null)
            {
                ViewBag.toppings = toppings;

                if (toppings.Contains("Italian Sausage"))
                {
                    total += sausageTopping.Price;
                }

                if (toppings.Contains("Ham"))
                {
                    total += hamTopping.Price;
                }

                if (toppings.Contains("Bacon"))
                {
                    total += baconTopping.Price;
                }

                if (toppings.Contains("Beef"))
                {
                    total += baconTopping.Price;
                }
            }

            

            ViewBag.total = total;

            return View();
        }

    }
}