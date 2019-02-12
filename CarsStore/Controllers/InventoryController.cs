using CarsStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsStore.UI.Models;

namespace CarsStore.Views
{
    public class InventoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult SearchNewCars(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string search)
        {
            var repo = RepoFactory.GetRepo();
            var newCars = repo.GetCars(true, minPrice, maxPrice, minYear, maxYear, search);

            return Json(newCars, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult SearchUsedCars(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string search)
        {
            var repo =  RepoFactory.GetRepo();
            var newCars = repo.GetCars(false, minPrice, maxPrice, minYear, maxYear, search);

            return Json(newCars, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var repo =  RepoFactory.GetRepo();
            var car = repo.GetCarByID(id);

            var model = new CarViewModel
            {
                Car = car
            };
            return View(model);

        }
    }
}