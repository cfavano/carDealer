using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class InventoryReport
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public Int16 Year { get; set; }
        public Decimal Total { get; set; }
        public int Count { get; set; }
    }
}