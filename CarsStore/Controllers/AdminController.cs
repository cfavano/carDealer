using CarsStore.UI;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CarsStore.Models;
using CarsStore.UI.Models;
using CarsStore.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.IO;

namespace CarsStore.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public AdminController(ApplicationUserManager userManager,
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

        public ActionResult SearchCars(int? minPrice, int? maxPrice, int? minYear, int? maxYear, string search)
        {
            var newCars = RepoFactory.GetRepo().GetCars(null, minPrice, maxPrice, minYear, maxYear, search);

            return Json(newCars, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult GetModelByID(int makeID)
        {
           
            var carModels = RepoFactory.GetRepo().GetCarModels(makeID);
            var selectList = Utility.CreateSelectList(carModels, x => x.ModelID, x => x.ModelName);
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult DeleteCar(int id)
        {

            var repo = RepoFactory.GetRepo();
           
            var car = repo.GetCarByID(id);

            string path = Server.MapPath("~/Images/Inventory/" + car.Picture);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            repo.DeleteCar(id);
   
            return RedirectToAction("Vehicles");
        }

        public ActionResult AddVehicle()
        {
            var repo = RepoFactory.GetRepo();
            var models = repo.GetCarModels(1);
            var makes = repo.GetCarMakes();
            var types = repo.GetPurchaseTypes();
            var transmissions = repo.GetTransmissions();
            var colors = repo.GetColors();
            var bodyStyles = repo.GetBodyStyles();
            var interiors = repo.GetInteriorColors();

            var model = new CarViewModel()
            {
                MakeList = Utility.CreateSelectList(makes, x => x.MakeID, x => x.MakeName),
                ModelList = Utility.CreateSelectList(models, x => x.ModelID, x => x.ModelName),
                BodyStyleList = Utility.CreateSelectList(bodyStyles, x => x.BodyStyleID, x => x.BodyStyleName),
                TransmissionList = Utility.CreateSelectList(transmissions, x => x.TransmissionID, x => x.TransmissionType),
                InteriorList = Utility.CreateSelectList(interiors, x => x.InteriorID, x => x.InteriorColor),
                ColorList = Utility.CreateSelectList(colors, x => x.ColorID, x => x.ColorName)

            };

            return View(model);
        }

        public void AddPicture()
        {
            
            var repo = RepoFactory.GetRepo();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];

                int fileSize = file.ContentLength;
                string extension = Path.GetExtension(file.FileName);

                int num = repo.GetLastCarID() + 1;
                string fileName = num.ToString() + extension;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;

                file.SaveAs(Server.MapPath("~/Images/Inventory/inventory-") + fileName); //File will be saved in application root
            }
        }
        public void UpdatedPicture()
        {

            var repo = RepoFactory.GetRepo();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];

                int fileSize = file.ContentLength;
                string extension = Path.GetExtension(file.FileName);

                int num = repo.GetLastCarID() + 1;
                string fileName = Request.Form["id"] + extension;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;

                file.SaveAs(Server.MapPath("~/Images/Inventory/inventory-") + fileName); //File will be saved in application root
            }
        }

        [HttpPost]
        public ActionResult AddVehicle(CarToAdd car)
        {
            switch (car.Picture)
            {
                case "png":
                    break;
                case "jpeg":
                    break;
                case "jpg":
                    break;
                default:
                    ModelState.AddModelError("car.Picture", "Photo needs to be .jpg, .jpeg. or .png");
                    break;
            }
            var maxYear = DateTime.Now.Year + 1;

            if (car.Year < 2000 || car.Year > maxYear)
                ModelState.AddModelError("car.Year", "Year should be between 2000 and " + maxYear);

            if (car.Mileage <= 0)
                ModelState.AddModelError("car.Mileage", "Mileage should be between greater than 0");

            if (car.IsNew)
            {
                if (car.Mileage > 1000)
                    ModelState.AddModelError("car.Mileage", "If car is new, mileage should be between 0 and 1000");
            }

            if (!car.IsNew)
            {
                if (car.Mileage < 1000)
                    ModelState.AddModelError("car.Mileage", "If car is used, mileage should be over 1000");
            }
            if (string.IsNullOrEmpty(car.VinID))
                ModelState.AddModelError("car.VinID", "Please enter Vin ID");


            if (string.IsNullOrEmpty(car.Picture))
                ModelState.AddModelError("car.Picture", "Please add a picture");


            if (car.VinID != null && car.VinID.Length != 17)
                ModelState.AddModelError("car.VinID", "VIN ID needs to have 17 characters");

            
            if (car.MSRP <= 0)
                ModelState.AddModelError("car.MSRP", "MSRP must greater than 0");


            if (string.IsNullOrEmpty(car.Description))
                ModelState.AddModelError("car.Description", "Please enter car description");


            if (car.SalesPrice <= 0)
                ModelState.AddModelError("car.SalesPrice", "Sales Price must greater than 0");


            if (car.SalesPrice > car.MSRP)
                ModelState.AddModelError("car.SalesPrice", "Sales Price must not be greater than MSRP");


            var repo = RepoFactory.GetRepo();

            if (repo.VinExists(car.VinID))
            {

                ModelState.AddModelError("car.VinID", "Vin already exists");
            }

            if (ModelState.IsValid)
            {
                int num = repo.GetLastCarID() + 1;
                string fileName = "inventory-" + num.ToString() + "." + car.Picture;
                car.Picture = fileName;
                
                repo.AddCar(car);
                var newCarID = repo.GetCarIDByVIN(car.VinID);
                var carID = newCarID;

                return Json(new { success = true, id = newCarID });

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

        public ActionResult EditVehicle(int id)
        {
            var repo = RepoFactory.GetRepo();
            var car = repo.GetCarByID(id);

            var models = repo.GetCarModels(car.Models.Makes.MakeID);
            var makes = repo.GetCarMakes();
            var types = repo.GetPurchaseTypes();
            var transmissions = repo.GetTransmissions();
            var colors = repo.GetColors();
            var bodyStyles = repo.GetBodyStyles();
            var interiors = repo.GetInteriorColors();

            var model = new CarViewModel()
            {
                Car = car,
                MakeList = Utility.CreateSelectList(makes, x => x.MakeID, x => x.MakeName),
                ModelList = Utility.CreateSelectList(models, x => x.ModelID, x => x.ModelName),
                BodyStyleList = Utility.CreateSelectList(bodyStyles, x => x.BodyStyleID, x => x.BodyStyleName),
                TransmissionList = Utility.CreateSelectList(transmissions, x => x.TransmissionID, x => x.TransmissionType),
                InteriorList = Utility.CreateSelectList(interiors, x => x.InteriorID, x => x.InteriorColor),
                ColorList = Utility.CreateSelectList(colors, x => x.ColorID, x => x.ColorName),
                IsNewList = Utility.CreateBooleanSelectList("New", "Used")
            };
            return View(model);

        }

        [HttpPut]
        public ActionResult EditVehicle(CarViewModel model)
        {
            var repo = RepoFactory.GetRepo();
            if (!string.IsNullOrEmpty(model.Car.Picture))
            {
                switch (model.Car.Picture)
                {
                    case "png":
                        break;
                    case "jpeg":
                        break;
                    case "jpg":
                        break;
                    default:
                        ModelState.AddModelError("car.Picture", "Photo needs to be .jpg, .jpeg. or .png");
                        break;
                }


                string fileName = "inventory-" + model.Car.CarID.ToString() + "." +model.Car.Picture;
                model.Car.Picture = fileName;
            }
            else {
               
                var existingCar = repo.GetCarByID(model.Car.CarID);
                model.Car.Picture = existingCar.Picture;


            }
            var maxYear = DateTime.Now.Year + 1;

            if (model.Car.Year < 2000 || model.Car.Year > maxYear)
                ModelState.AddModelError("car.Year", "Year should be between 2000 and " + maxYear);

            if (model.Car.Mileage < 0)
                ModelState.AddModelError("car.Mileage", "Mileage should be between greater than 0");

            if (model.Car.IsNew)
                if (model.Car.Mileage > 1000)
                    ModelState.AddModelError("car.Mileage", "If car is new, mileage should be between 0 and 1000");

            if (!model.Car.IsNew)
                if (model.Car.Mileage < 1000)
                    ModelState.AddModelError("car.Mileage", "If car is used, mileage should be over 1000");

            if (string.IsNullOrEmpty(model.Car.VinID))
                ModelState.AddModelError("car.VinID", "Please enter Vin ID");

            if (model.Car.VinID != null && model.Car.VinID.Length != 17)
                ModelState.AddModelError("car.VinID", "VIN ID needs to have 17 characters");

            if (model.Car.MSRP <= 0)
                ModelState.AddModelError("car.MSRP", "MSRP must greater than 0");

            if (string.IsNullOrEmpty(model.Car.Description))
                ModelState.AddModelError("car.Description", "Please enter car description");

            if (model.Car.SalesPrice <= 0)
                ModelState.AddModelError("car.SalesPrice", "Sales Price must greater than 0");

            if (model.Car.SalesPrice > model.Car.MSRP)
                ModelState.AddModelError("car.SalesPrice", "Sales Price must not be greater than MSRP");


            if (ModelState.IsValid)
            {
              
                repo.UpdateCar(model.Car, model.Car.CarID);
                return Json(new { success = true });
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

            };
        }

        public ActionResult Models()
        {
            var repo = RepoFactory.GetRepo();
            var models = repo.GetCarModels();
            var modelWithUserList = new List<ModelWithUser>();

            foreach (var m in models)
            {
                
                var modelWithUser = new ModelWithUser();
                modelWithUser.Email = GetEmail(m.UserID);
                modelWithUser.Model = m;
                modelWithUserList.Add(modelWithUser);
            }

            var model = new ModelsViewModel()
            {
                ModelWithUsers = modelWithUserList,
                MakesList = Utility.CreateSelectList(repo.GetCarMakes(), x => x.MakeID, x => x.MakeName)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Models(ModelsViewModel newModel)
        {
            var repo = RepoFactory.GetRepo();
            var models = repo.GetCarModels();

            var nameType = newModel.ModelToAdd.ModelName as String;
            int value;
            var nameAsInt = int.TryParse(newModel.ModelToAdd.ModelName, out value);
            var modelWithUserList = new List<ModelWithUser>();

            foreach (var m in models)
            {
                var modelWithUser = new ModelWithUser();
                modelWithUser.Email = GetEmail(m.UserID);
                modelWithUser.Model = m;
                modelWithUserList.Add(modelWithUser);
            }
            var model = new ModelsViewModel()
            {
                ModelWithUsers = modelWithUserList,
                MakesList = Utility.CreateSelectList(repo.GetCarMakes(), x => x.MakeID, x => x.MakeName),

                ModelToAdd = new NewModel()
                {
                    MakeID = newModel.ModelToAdd.MakeID,
                    ModelName = newModel.ModelToAdd.ModelName
                }
            };

            var modelsByID = repo.GetCarModels(newModel.ModelToAdd.MakeID);

            if (nameType == null || nameAsInt)
                ModelState.AddModelError("ModelToAdd.ModelName", "Please enter model name");

            var modelExists = modelsByID.Where(s => String.Equals(s.ModelName, newModel.ModelToAdd.ModelName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (modelExists.Count > 0)
                ModelState.AddModelError("ModelToAdd.ModelName", "Make and Model pair already exists");

            if (!ModelState.IsValid)
                return View(model);

            var newCarModel = new Model
            {
                MakeID = newModel.ModelToAdd.MakeID,
                ModelName = newModel.ModelToAdd.ModelName
            };

            ApplicationUser appUser = new ApplicationUser();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            newCarModel.UserID = user.Id;
            repo.AddModel(newCarModel);
            return RedirectToAction("Models");
        }

        public ActionResult Makes()
        {
            var repo = RepoFactory.GetRepo();
            var makes = repo.GetCarMakes();

            var makeWithUserList = new List<MakeWithUser>();

            foreach (var m in makes)
            {
                var makeWithUser = new MakeWithUser();
                makeWithUser.Email = GetEmail(m.UserID);
                makeWithUser.Make = m;
                makeWithUserList.Add(makeWithUser);

            }

            var model = new MakesViewModel()
            {
                Makes = makeWithUserList

            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Makes(MakesViewModel newMake)
        {
            var nameType = newMake.MakeToAdd.MakeName as String;
            int value;
            var nameAsInt = int.TryParse(newMake.MakeToAdd.MakeName, out value);

            var repo = RepoFactory.GetRepo();
            var makes = repo.GetCarMakes();

            var makeWithUserList = new List<MakeWithUser>();
            foreach (var m in makes)
            {
                var makeWithUser = new MakeWithUser();
                makeWithUser.Email = GetEmail(m.UserID);
                makeWithUser.Make = m;
                makeWithUserList.Add(makeWithUser);

            }

            var model = new MakesViewModel()
            {
                Makes = makeWithUserList,
                MakeToAdd = new Make { MakeName = newMake.MakeToAdd.MakeName }
            };
            if (nameType == null || nameAsInt)
                ModelState.AddModelError("MakeToAdd.MakeName", "Please enter make name");

            var makeExists = makes.Where(s => String.Equals(s.MakeName, newMake.MakeToAdd.MakeName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (makeExists.Count > 0)
                ModelState.AddModelError("MakeToAdd.MakeName", "Make already exists");


            if (!ModelState.IsValid)
                return View(model);



            var newCarModel = new Make
            {
                MakeID = newMake.MakeToAdd.MakeID,
                MakeName = newMake.MakeToAdd.MakeName
            };

            ApplicationUser appUser = new ApplicationUser();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            newCarModel.UserID = user.Id;
            repo.AddMake(newCarModel);

            return RedirectToAction("Makes");

        }

        public ActionResult Specials()
        {
            var repo = RepoFactory.GetRepo();
            var specialsList = repo.GetSpecials();

            var model = new AdminSpecialViewModel()
            {
                SpecialsList = specialsList
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Specials(Specials special)
        {
            int valueTitle;
            int valueDescription;

            var titleAsInt = int.TryParse(special.Title, out valueTitle);
            var DescriptionAsInt = int.TryParse(special.Title, out valueDescription);

            var repo = RepoFactory.GetRepo();
            var specials = repo.GetSpecials();

            var model = new AdminSpecialViewModel()
            {
                SpecialsList = specials,
                Special = new Specials
                {
                    Title = special.Title,
                    Description = special.Description
                }
            };

            if (String.IsNullOrEmpty(special.Title) || titleAsInt)
                ModelState.AddModelError("special.Title", "Please enter title");


            if (String.IsNullOrEmpty(special.Description) || DescriptionAsInt)
                ModelState.AddModelError("special.Description", "Please enter description");

            if (!string.IsNullOrEmpty(special.Title) && !string.IsNullOrEmpty(special.Description))
            {
                var x = specials.Where(s => String.Equals(s.Title, special.Title, StringComparison.OrdinalIgnoreCase)).ToList();

                if (x.Count > 0)
                {
                    var y = specials.Where(s => String.Equals(s.Title, special.Title, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    if (string.Equals(y.Description, special.Description, StringComparison.OrdinalIgnoreCase))
                        ModelState.AddModelError("", "Title and Description already exist");
                }
            }

            if (!ModelState.IsValid)
                return View(model);


            repo.AddSpecial(model.Special);
            return RedirectToAction("Specials");
        }

        [HttpDelete]
        public ActionResult Specials(int id)
        {
            var repo = RepoFactory.GetRepo();
            repo.DeleteSpecial(id);

            var specialsList = repo.GetSpecials();

            var model = new AdminSpecialViewModel()
            {
                SpecialsList = specialsList
            };
            return View(model);
        }

        public ActionResult Users()
        {
            var allUser = UserManager.Users.ToList();

            var userListViewModel = new UI.Models.UsersListViewModel();
            var list = new List<UI.Models.UserWithRole>();

            foreach (var user in allUser)
            {
                var role = UserManager.GetRoles(user.Id).FirstOrDefault();
                var userWithRole = new UI.Models.UserWithRole()
                {
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Email = user.Email,
                    Role = role,
                    ID = user.Id

                };

                list.Add(userWithRole);
            }
            userListViewModel.Users = list;

            return View(userListViewModel);
        }


        public ActionResult AddUser()
        {
            var context = new ApplicationUsersDbContext();
            var model = new UserViewModel();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = roleManager.Roles.ToList();
            var roleList = Utility.CreateSelectList(roles, x => x.Name, x => x.Name);

            model.RoleList = roleList;

            return View(model);
        }

        [HttpPost]
        //       [ValidateAntiForgeryToken] //what is this
        public ActionResult AddUser(UserViewModel user)
        {
            var model = new ApplicationUser()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
            };

            if (string.IsNullOrEmpty(user.FirstName))

                ModelState.AddModelError("user.Firstname", "Please enter first name");

            if (string.IsNullOrEmpty(user.LastName))

                ModelState.AddModelError("user.LastName", "Please enter last name");

            if (string.IsNullOrEmpty(user.Email))

                ModelState.AddModelError("user.Email", "Please enter email");

            if (!string.IsNullOrEmpty(user.Email) && !Utility.ValidateEmail(user.Email))

                ModelState.AddModelError("user.Email", "Please enter valid email");


            if (string.IsNullOrEmpty(user.Password))

                ModelState.AddModelError("user.Password", "Please password");

            if (string.IsNullOrEmpty(user.ConfirmedPassword))

                ModelState.AddModelError("user.Password", "Please confirmed password");


            if (user.Password != user.ConfirmedPassword)
                ModelState.AddModelError("user.ConfirmedPassword", "Passwords do not match");

            var context = new ApplicationUsersDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = roleManager.Roles.ToList();
            var roleList = Utility.CreateSelectList(roles, x => x.Name, x => x.Name);
            user.RoleList = roleList;

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (UserManager.FindByEmail(user.Email) != null)
            {
                ModelState.AddModelError("", "Email exists. User was not added");
                return View(user);
            }

            IdentityResult result = UserManager.Create(model, user.Password);

            if (result.Succeeded)
            {
                UserManager.AddToRole(model.Id, user.RoleName);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "An error occurred. User was not added");

            return View(user);
        }

        public ActionResult EditUser(string id)
        {
            var appUser = new ApplicationUser();
            appUser = UserManager.FindById(id);

            var role = UserManager.GetRoles(appUser.Id).FirstOrDefault();
            var roles = RoleManager.Roles.ToList();
            var context = new ApplicationUsersDbContext();

            var model = new UserViewModel()
            {
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                RoleList = Utility.CreateSelectList(roles, x => x.Name, x => x.Name),
                RoleName = role
            };

            return View(model);
        }

        [HttpPut]
        public ActionResult EditUser(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName))
            {
                ModelState.AddModelError("Firstname", "Please enter first name");
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError("model.LastName", "Please enter last name");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("model.Email", "Please enter email");
            }

            if (!string.IsNullOrEmpty(model.Email) && !Utility.ValidateEmail(model.Email))
            {
                ModelState.AddModelError("model.Email", "Please enter valid email");
            }

            if ((string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.ConfirmedPassword)) || (!string.IsNullOrEmpty(model.Password) && string.IsNullOrEmpty(model.ConfirmedPassword)))
            {
                ModelState.AddModelError("model.Password", "Please enter both password fields to update password.");
            }


            if (model.Password != model.ConfirmedPassword)
                ModelState.AddModelError("model.ConfirmedPassword", "Passwords do not match");

            var context = new ApplicationUsersDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = roleManager.Roles.ToList();
            var roleList = Utility.CreateSelectList(roles, x => x.Name, x => x.Name);
            model.RoleList = roleList;

            if (!ModelState.IsValid)
                return View(model);

            var user = UserManager.FindByEmail(model.Email);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;

                if (!string.IsNullOrEmpty(model.Password) && string.IsNullOrEmpty(model.ConfirmedPassword))
                {
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.Password);
                }

                UserManager.Update(user);

                var oldRoleID = user.Roles.SingleOrDefault().RoleId;
                var oldRoleName = context.Roles.SingleOrDefault(r => r.Id == oldRoleID).Name;

                if (oldRoleName != model.RoleName)
                {
                    UserManager.RemoveFromRole(user.Id, oldRoleName);
                    UserManager.AddToRole(user.Id, model.RoleName);
                }

                UserManager.AddToRole(user.Id, model.RoleName);

                return RedirectToAction("Users", "Admin");
            }

            ModelState.AddModelError("", "An error occurred. User was not updated");
            return View(model);
        }

        public string GetName(string email)
        {
            //ApplicationUser appUser = new ApplicationUser();
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var currentUser = UserManager.FindByEmail(email);
            return currentUser.FirstName + " " + currentUser.LastName;

        }

        public string GetEmail(string ID)
        {
            ApplicationUser appUser = new ApplicationUser();
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var currentUser = UserManager.FindById(ID);
            return currentUser.Email;

        }
    }
}