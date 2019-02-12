using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class CarModelsReport
    {
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public DateTime DateAdded { get; set; }
        public int User { get; set; }
    }
}