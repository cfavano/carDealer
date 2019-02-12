using CarsStore.ActionFilters;
using CarsStore.Data;
using CarsStore.Models;
using CarsStore.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Controllers
{
    [Authorize(Roles = "Sales")]
    public class SalesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchCars(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string search)
        {
            var repo = RepoFactory.GetRepo();
            var newCars = repo.GetCars(null, minPrice, maxPrice, minYear, maxYear, search);

            return Json(newCars, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Purchase(Sale sale)
        {
            var repo = RepoFactory.GetRepo();
            var car = repo.GetCarByID(sale.CarID);

            var nameType = sale.CustomerName as String;

            if (String.IsNullOrEmpty(sale.CustomerName) || nameType == null)
                ModelState.AddModelError("sale.CustomerName", "Please enter customer name");

            if (sale.Phone != null)
            {
                var phoneIsValid = Utility.ValidatePhoneNumber(sale.Phone);

                if (!phoneIsValid)
                    ModelState.AddModelError("sale.Phone", "Please enter valid phone number");
            }

            if (sale.Email != null)
            {
                var emailIsValid = Utility.ValidateEmail(sale.Email);

                if (!emailIsValid)
                    ModelState.AddModelError("sale.Email", "Please enter valid email");
            }

            if (string.IsNullOrEmpty(sale.Phone))
            {
                ModelState.AddModelError("sale.Phone", "Please add email or phone number");
            }

            if (string.IsNullOrEmpty(sale.Email) && string.IsNullOrEmpty(sale.Phone))
            {
                ModelState.AddModelError("sale.Email", "Please add email or phone number");
                ModelState.AddModelError("sale.Phone", "Please add email or phone number");
            }

            if (string.IsNullOrEmpty(sale.Street1))
            {
                ModelState.AddModelError("sale.Street1", "Please add street address");
            }

            if (string.IsNullOrEmpty(sale.City))
            {
                ModelState.AddModelError("sale.City", "Please add city");
            }

            if (string.IsNullOrEmpty(sale.Zip))
            {
                ModelState.AddModelError("sale.Zip", "Please add zip");
            }

            if (sale.Zip != null)
            {
                var zipIsValid = Utility.ValidateZip(sale.Zip);

                if (!zipIsValid)
                    ModelState.AddModelError("sale.Zip", "Invalid zip");
            }

            if (sale.PurchasePrice > car.MSRP)
            {
                ModelState.AddModelError("sale.PurchasePrice", "Purchase price cannot be higher than MSRP");
            }


            if ((sale.PurchasePrice / car.SalesPrice) < (decimal)0.95)
            {
                ModelState.AddModelError("sale.PurchasePrice", "Purchase price cannot be less than 95% of sales price");
            }

            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser();
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                
                sale.PurchaseDate = DateTime.Today;
                sale.SalesPerson = user.Email;

                repo.AddSale(sale);

                return Json(new { success = true});
            }

            else
            {
                var errorList = new List<KeyValuePair<string, string>>();

                foreach (var modelStateKey in ViewData.ModelState.Keys)
                {
                    var modelStateVal = ViewData.ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        errorList.Add(new KeyValuePair<string, string>(modelStateKey, error.ErrorMessage));
                        
                    }
                }

                return Json(new { success = false, errors = errorList }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult Purchase(int id)
        {
            var repo = RepoFactory.GetRepo();
            var car = repo.GetCarByID(id);
            var states = repo.GetState();
            var purchaseTypes = repo.GetPurchaseTypes();

            var model = new UI.Models.PurchaseViewModel()
            {
                Car = car,
                StateList = Utility.CreateSelectList(states, x => x.StateID, x => x.StateAbbreviation),
                PurchaseTypeList = Utility.CreateSelectList(purchaseTypes, x => x.PurchaseTypeID, x => x.PurchaseTypeName)
            };

            return View(model);
        }
    }
}