using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStore.Models
{
    public class Pizza
    {

        public string Name { get; set; }

        public Size Size { get; set; }

        //public decimal Price { get; set; }

        public List<Size> SizeList { set; get; }
        public enumSizeOfPizza enumSize { set; get; }

    }

    public class Size
    {
        public string Type { get; set; }
        public double Price { get; set; }
    }
}