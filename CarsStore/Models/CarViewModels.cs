using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.UI.Models
{
    public class CarViewModel
    {
        public Car Car { get; set; }

        public IEnumerable<SelectListItem> MakeList { get; set; }
        public IEnumerable<SelectListItem> ModelList { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }
        public IEnumerable<SelectListItem> BodyStyleList { get; set; }
        public IEnumerable<SelectListItem> TransmissionList { get; set; }
        public IEnumerable<SelectListItem> InteriorList { get; set; }
        public IEnumerable<SelectListItem> ColorList { get; set; }
        public IEnumerable<SelectListItem> IsNewList { get; set; }
    }

    public class CarListViewModel
    {
        public List<Car> Car { get; set; }
        public string SearchString { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
    }

    public class ModelsViewModel
    {
        public List<ModelWithUser> ModelWithUsers { get; set; }
        public IEnumerable<SelectListItem> MakesList { get; set; }
        public List<Make> Makes { get; set; }

        public NewModel ModelToAdd { get; set; }
    }

    public class ModelWithUser
    {
        public Model Model { get; set; }
        public string Email { get; set; }
    }

    public class NewModel
    {
        public int MakeID { get; set; }
        public string ModelName { get; set; }
    }
    public class MakesViewModel
    {
        public List<MakeWithUser> Makes { get; set; }
        public Make MakeToAdd { get; set; }
    }

    public class MakeWithUser
    {
        public Make Make { get; set; }
        public string Email { get; set; }

    }
}
