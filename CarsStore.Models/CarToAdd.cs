using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class CarToAdd
    {
        public string VinID { get; set; }
        public bool IsFeatured { get; set; }
        public string Picture { get; set; }
        public Int16 Year { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int BodyStyleID { get; set; }
        public int TransmissionID { get; set; }
        public int ColorID { get; set; }
        public int Mileage { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal MSRP { get; set; }

        public string Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsAvailable { get; set; }
        public int InteriorID { get; set; }
    }
}