using CarsStore.Data;
using CarsStore.UI.Models;
using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = RepoFactory.GetRepo();

            List<Specials> specials = repo.GetSpecials();
            List<Car> featuredCars = repo.GetFeaturedCars();

            var model = new SpecialsFeaturedCarViewModel
            {
                Specials = specials,
                FeaturedCars = featuredCars
            };

            return View(model);
        }

        public ActionResult Specials()
        {
            var repo = RepoFactory.GetRepo();

            var specials = repo.GetSpecials();

            var model = new SpecialsViewModel()
            {
                Specials = specials
            };

            return View(model);
        }

        [Route("Home/Contact")]
        [Route("Home/Contact/{id}")]
        public ActionResult Contact(string id)
        {
            if (id != null) {

                var model = new ContactViewModel
                {
                    Message = id
                };
                return View(model);
            }
            return View();
        }

        
       

        [HttpPost]
        public ActionResult Contact(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var repo = RepoFactory.GetRepo();
                var model = new ContactMessage()
                {
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Message = contact.Message
                };

                repo.AddContact(model);
                ViewBag.SuccessMessage = "Message was successfully sent!";

                return View();
            }

            else 
                return View("Contact", contact);
            
        }
    }
}