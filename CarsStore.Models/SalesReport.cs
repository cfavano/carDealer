using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class SalesReport
    {
        public string SalesPersonID { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalCars { get; set; }
    }
    public class SalesReportWithUser
    {
        public string SalesPersonName { get; set; }
        public string SalesPersonID { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalCars { get; set; }
    }
}