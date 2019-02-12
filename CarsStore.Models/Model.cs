﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsStore.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int MakeID { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserID { get; set; }
        
        public virtual Make Makes { get; set; }
    }
}