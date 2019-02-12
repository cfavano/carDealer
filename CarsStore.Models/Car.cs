using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Car
    {
       [Key]
        public int CarID { get; set; }
        public string VinID { get; set; }
        public bool IsFeatured { get; set; }
        public string Picture { get; set; }
        public Int16 Year { get; set; }

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

        public virtual Model Models { get; set; }
        public virtual Transmission Transmissions { get; set; }
        public virtual Color Colors { get; set; }
        public virtual Interior Interiors { get; set; }
        public virtual BodyStyle BodyStyles { get; set; }

    }
}