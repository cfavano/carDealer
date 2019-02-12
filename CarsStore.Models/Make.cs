using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Make
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserID { get; set; }
    }
}