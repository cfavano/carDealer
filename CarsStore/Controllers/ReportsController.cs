using CarsStore.Data;
using CarsStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarsStore.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public ReportsController()
        {
        }

        public ReportsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ReportsController(ApplicationUserManager userManager,
       ISecureDataFormat<AuthenticationTicket> accessTokenFormat, ApplicationRoleManager roleManager)
        {
            ///Make an instance of the user manager in the controller to avoid null reference exception
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            ///Make an instance of the role manager in the constructor to avoid null reference exception
            RoleManager = roleManager;
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {
            var context = new ApplicationUsersDbContext();

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var salesUserId = roleManager.FindByName("Sales").Users.Select(e => e.UserId).ToList();
            var SalesNameList = new Dictionary<string, string>();

            ApplicationUser appUser = new ApplicationUser();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            foreach (var salesPersonID in salesUserId)
            {
                var currentUser = UserManager.FindById(salesPersonID);
               
                var name = currentUser.FirstName + " " + currentUser.LastName;

                SalesNameList.Add(currentUser.Email,name);
            }

            var selectList = GetSelectListItems(SalesNameList);
            var model = new UI.Models.ReportViewModels.SalesReportViewModel
            {
                SalesList = selectList
            };

            return View(model);
        }

        private List<SelectListItem> GetSelectListItems(Dictionary<string, string> salesNames)
        {
            var selectList = new List<SelectListItem>();
            foreach (var person in salesNames)
            {

                selectList.Add(new SelectListItem
                {
                    Value = person.Key +" " + person.Value,
                    Text = person.Value
                });

            }
            return selectList;
        }


        public ActionResult GetSales(string name, DateTime? min, DateTime? max)
        {
            var repo = RepoFactory.GetRepo();
            var sales = repo.GetSalesReport(name, min, max);
            var salesReportWithName = new List<SalesReportWithUser>();

            if (!string.IsNullOrEmpty(name))
            {

                foreach (var x in sales)
                {
                    var salesReportWithUser = new SalesReportWithUser();
                    salesReportWithUser.SalesPersonName = GetNameByEmail(x.SalesPersonID);
                    salesReportWithUser.TotalCars = x.TotalCars;
                    salesReportWithUser.TotalSales = x.TotalSales;

                    salesReportWithName.Add(salesReportWithUser);

                }
            }
            else {
                foreach (var x in sales)
                {
                    var salesReportWithUser = new SalesReportWithUser();
                    salesReportWithUser.SalesPersonName = GetNameByEmail(x.SalesPersonID);
                    salesReportWithUser.TotalCars = x.TotalCars;
                    salesReportWithUser.TotalSales = x.TotalSales;

                    salesReportWithName.Add(salesReportWithUser);

                }


            }

            return Json(salesReportWithName, JsonRequestBehavior.AllowGet);
        }

      

        public ActionResult Inventory()
        {
            var repo =  RepoFactory.GetRepo();
            var reportNew = repo.GetInventoryReport(true);
            var reportUsed = repo.GetInventoryReport(false);

            var report = new UI.Models.ReportViewModels.ReportViewModel()
            {
                ReportNew = reportNew,
                ReportUsed = reportUsed
            };

            return View(report);
        }

        public string GetNameByEmail(string email)
        {
            ApplicationUser appUser = new ApplicationUser();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var currentUser = UserManager.FindByEmail(email);
            if (string.IsNullOrEmpty(currentUser.FirstName)) {
                return "no name";

            }
            return currentUser.FirstName + " " + currentUser.LastName;

        }

        //public string GetNameByID(string id)
        //{
        //    ApplicationUser appUser = new ApplicationUser();
        //    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

        //    var currentUser = UserManager.FindById(id);
        //    return currentUser.FirstName + " " + currentUser.LastName;

        //}
    }
}