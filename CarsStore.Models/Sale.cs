using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int CarID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int StateID { get; set; }
        public string Zip { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeID { get; set; }
        public string SalesPerson { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string VinID { get; set; }


        public virtual PurchaseType Purchases { get; set; }
        public virtual State States { get; set; }
    }
}