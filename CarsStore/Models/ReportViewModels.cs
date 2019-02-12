using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.UI.Models
{
    public class ReportViewModels
    {
        public class ReportViewModel
        {
            public List<InventoryReport> ReportNew { get; set; }
            public List<InventoryReport> ReportUsed { get; set; }
        }

        public class SalesReportViewModel
        {
            public string SalesName { get; set; }
            public DateTime? MinDate { get; set; }
            public DateTime? MaxDate { get; set; }
            public IEnumerable<SelectListItem> SalesList { get; set; }

            public List<SalesReport> SalesByPerson { get; set; }
        }
    }
}