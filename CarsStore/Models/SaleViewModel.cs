using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.UI.Models
{

    public class PurchaseViewModel 
    {
        public Car Car { get; set; }
        public Sale Sale { get; set; }
        public IEnumerable<SelectListItem> StateList { get; set; }
        public IEnumerable<SelectListItem> PurchaseTypeList { get; set; }

      
        
    }

}
