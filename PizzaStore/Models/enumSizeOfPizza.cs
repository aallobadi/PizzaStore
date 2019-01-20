using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PizzaStore.Models
{
    public enum enumSizeOfPizza
    {
        [Display(Name = "Small Size")]
        SS,
        [Display(Name = "Medium Size")]
        MS,
        [Display(Name = "Large Size")]
        LS,
    }
}