using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using System.Data;
using CarsStore.Data;
using System.Data.Entity;
using CarsStore.Models;


namespace CarsStore.Tests
{
    public class DALTests
    {
        [TestFixture]
        public class EntityIntegrationTests
        {
            [Test]
            public void EFCanLoadFeaturedCars()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetFeaturedCars();

                Assert.AreEqual(2, cars.Count);
            }

            [Test, Order(1)]
            public void EFCanLoadSpecials()
            {
                var repo = new EFCarRepo();
                var specials = repo.GetSpecials();

                Assert.AreEqual(3, specials.Count);
                Assert.AreEqual("Holiday Special", specials[0].Title);
            }

            [Test]
            public void EFWillLoadMaxOfTwentyCars()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, null, null, null, null, "");

                Assert.AreEqual(20, cars.Count);
            }

            [Test]
            public void EFCanLoadCarsInPriceRange()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, 10000, 15000, null, null, "");

                Assert.AreEqual(15, cars.Count);
                Assert.AreEqual("3N1CN7AP3EL866789", cars[0].VinID);
            }

            [Test]
            public void EFCanLoadUsedCarsInPriceRange()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(false, 10000, 15000, null, null, "");

                Assert.AreEqual(15, cars.Count);
                Assert.AreEqual("3N1CN7AP3EL866789", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsInMaxPrice()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, null, 15000, null, null, "");

                Assert.AreEqual(15, cars.Count);
                Assert.AreEqual("3N1CN7AP3EL866789", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsInMinPrice()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, 35000, null, null, null, "");

                Assert.AreEqual(1, cars.Count);
                Assert.AreEqual("1FTRF12255NB94299", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsInYearRange()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, null, null, 2010, 2015, "");

                Assert.AreEqual(16, cars.Count);
                Assert.AreEqual("1N4AL3AP1DC231850", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsInMinYear()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, null, null, 2018, null, "");

                Assert.AreEqual(20, cars.Count);
                Assert.AreEqual("WDDHF9HBXEA922004", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsInMaxYear()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, null, null, null, 2000, "");

                Assert.AreEqual(1, cars.Count);
                Assert.AreEqual("JN8AZ2NE1F9081562", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsWithSearchYear()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, null, null, null, null, "");

                Assert.AreEqual(20, cars.Count);
                Assert.AreEqual("1FTRF12255NB94299", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsWithMakeModel()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(null, null, null, null, null, "Fo");

                Assert.AreEqual(2, cars.Count);
                Assert.AreEqual("4T4BF3EK2BR213662", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsWithMostSearchFields()
            {

                var repo = new EFCarRepo();
                var cars = repo.GetCars(true, null, null, null, null, "honda");

                Assert.AreEqual(20, cars.Count);
                Assert.AreEqual("WDDHF9HBXEA922004", cars[0].VinID);
            }

            [Test]
            public void EFCanReturnCarsWithAllSearchFields()
            {
                var repo = new EFCarRepo();
                var cars = repo.GetCars(false, 5000, 15000, 2011, 2012, "f");

                Assert.AreEqual(2, cars.Count);
                Assert.AreEqual("4T4BF3EK2BR213662", cars[0].VinID);
            }

            [Test]
            public void EFCanGetCarByID()
            {
                var repo = new EFCarRepo();
                var car = repo.GetCarByID(17);

                Assert.AreEqual("Insight", car.Models.ModelName);
                Assert.AreEqual("Honda", car.Models.Makes.MakeName);
            }

            [Test]
            public void EFCanGetSalesReportNoParams()
            {
                var repo = new EFCarRepo();
                var report = repo.GetSalesReport("", null, null);

                Assert.AreEqual("sales@softwareguild.com", report[0].SalesPersonID);


            }


            [Test]
            public void EFCanGetNewInventoryReport()
            {
                var repo = new EFCarRepo();
                var report = repo.GetInventoryReport(true);

                Assert.AreEqual(4, report[0].Count);
                Assert.AreEqual("Accord", report[0].Model);
                Assert.AreEqual(112000, report[0].Total);
            }

            [Test]
            public void EFCanGetUsedInventoryReport()
            {
                var repo = new EFCarRepo();
                var report = repo.GetInventoryReport(false);

                Assert.AreEqual(3, report[2].Count);
                Assert.AreEqual("CR-V", report[2].Model);
                Assert.AreEqual(54750, report[2].Total);
            }


            [Test]
            public void EFCanGetBodyStyles()
            {
                var repo = new EFCarRepo();
                var styles = repo.GetBodyStyles();

                Assert.AreEqual(4, styles.Count());
                Assert.AreEqual("Car", styles[0].BodyStyleName);
            }

            [Test]
            public void EFCanGetTransmission()
            {
                var repo = new EFCarRepo();
                var transmissions = repo.GetTransmissions();

                Assert.AreEqual(2, transmissions.Count());
                Assert.AreEqual("Manual", transmissions[0].TransmissionType);
            }

            [Test]
            public void EFCanGetColors()
            {
                var repo = new EFCarRepo();
                var colors = repo.GetColors();

                Assert.AreEqual(5, colors.Count());
                Assert.AreEqual("Black", colors[0].ColorName);
            }

            [Test]
            public void EFCanGetInteriorColors()
            {
                var repo = new EFCarRepo();
                var interiors = repo.GetInteriorColors();

                Assert.AreEqual(5, interiors.Count());
                Assert.AreEqual("Gray", interiors[0].InteriorColor);
            }

            [Test]
            public void EFCanGetPurchaseType()
            {
                var repo = new EFCarRepo();
                var purchaseTypes = repo.GetPurchaseTypes();

                Assert.AreEqual(3, purchaseTypes.Count());
                Assert.AreEqual("Bank Finance", purchaseTypes[0].PurchaseTypeName);
            }

            [Test]
            public void EFCanGetState()
            {
                var repo = new EFCarRepo();
                var states = repo.GetState();

                Assert.AreEqual(50, states.Count());
                Assert.AreEqual("Alabama", states[0].StateName);
            }

            [Test]
            public void EFCanGetAllMakesReport()
            {
                var repo = new EFCarRepo();
                var report = repo.GetCarMakes();

                Assert.AreEqual(9, report.Count());
                Assert.AreEqual("Audi", report[0].MakeName);
            }

            [Test, Order(2)]
            public void EFCanAddSpecial()
            {

                var special = new Specials()
                {
                    Title = "Test Title",
                    Description = "Test Description"

                };
                var repo = new EFCarRepo();
                repo.AddSpecial(special);

                var currentSpecials = repo.GetSpecials();

                Assert.AreEqual(4, currentSpecials.Count());
                Assert.AreEqual("Test Title", special.Title);
            }

            [Test, Order(3)]
            public void EFCanDeleteSpecial()
            {

                var repo = new EFCarRepo();
                var currentSpecials = repo.GetSpecials();
                int lastID;
                using (var context = new CarStoreEntities())
                {
                    var query = context.Specials
                        .OrderByDescending(p => p.SpecialsID)
                        .FirstOrDefault();

                    lastID = query.SpecialsID;

                }
                repo.DeleteSpecial(lastID);
                var newSpecialsCount = repo.GetSpecials().Count();

                Assert.AreEqual(3, newSpecialsCount);


            }



            [Test]
            public void EFCanAddContact()
            {
                var repo = new EFCarRepo();

                var contact = new ContactMessage
                {
                    Name = "christa valencia",
                    Email = "cv@gmail.com",
                    Message = "Test",
                    Phone = null
                };
                repo.AddContact(contact);

                using (var context = new CarStoreEntities())
                {
                    var query = context.ContactMessages
                        .OrderByDescending(q => q.ContactMessageID)
                        .Select(q => new
                        {
                            q.ContactMessageID,
                            q.Name,
                            q.Email,
                            q.Phone,
                            q.Message
                        }).ToList();

                    var count = query.Count();
                    Assert.AreEqual(4, count);

                    var id = query[0].ContactMessageID;

                    var queryDelete = context.ContactMessages
                         .Where(q => q.ContactMessageID == id)
                         .Select(q => new
                         {
                             id = q.ContactMessageID,
                             name = q.Name,
                             email = q.Email,
                             phone = q.Phone,
                             mess = q.Message
                         }).FirstOrDefault();

                    var contactToDelete = new ContactMessage
                    {
                        ContactMessageID = queryDelete.id,
                        Name = queryDelete.name,

                        Email = queryDelete.email,
                        Phone = queryDelete.phone,
                        Message = queryDelete.mess
                    };

                    context.ContactMessages.Attach(contactToDelete);
                    context.ContactMessages.Remove(contactToDelete);
                    context.SaveChanges();
                }
            }

            [Test]
            public void EFCanAddDeleteSale()
            {
                var repo = new EFCarRepo();

                var sale = new Sale
                {
                    CustomerName = "Test Customer",
                    Phone = "7141231234",
                    Email = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0",
                    Street1 = "1 Circle Ave",
                    SaleID = 5,
                    Zip = "12345",
                    PurchasePrice = 2700,
                    PurchaseTypeID = 1,
                    SalesPerson = "test@gmail.com",
                    PurchaseDate = DateTime.Now,
                    VinID = "12312312312312312",
                    CarID = 1,StateID = 5
                };
                repo.AddSale(sale);

                using (var context = new CarStoreEntities())
                {
                    var query = context.Sales
                        .OrderByDescending(q => q.SaleID)
                        .Select(q => new
                        {
                            q.SaleID,
                            q.CustomerName

                        }).ToList();

                    Assert.AreEqual("Test Customer", query[0].CustomerName);

                    var id = query[0].SaleID;

                    var queryDelete = context.Sales
                        .Where(q => q.SaleID == id)
                        .Select(q => new
                        {
                            q.SaleID,
                            q.CustomerName,
                            q.Phone,
                            q.Email,
                            q.Street1,
                            q.Zip,
                            q.PurchasePrice,
                            q.PurchaseTypeID,
                            q.SalesPerson,
                            q.PurchaseDate,
                            q.VinID,
                            q.CarID,
                            q.StateID
                        }).FirstOrDefault();

                    var SaleDelete = new Sale
                    {
                        SaleID = queryDelete.SaleID,
                        CustomerName = queryDelete.CustomerName,
                        Phone = queryDelete.Phone,
                        Email = queryDelete.Email,
                        Street1 = queryDelete.Street1,
                        Zip = queryDelete.Zip,
                        PurchasePrice = queryDelete.PurchasePrice,
                        PurchaseTypeID = queryDelete.PurchaseTypeID,
                        SalesPerson = queryDelete.SalesPerson,
                        PurchaseDate = queryDelete.PurchaseDate,
                        VinID = queryDelete.VinID,
                        CarID = queryDelete.CarID,
                        StateID = queryDelete.StateID
                    };

                    context.Sales.Attach(SaleDelete);
                    context.Sales.Remove(SaleDelete);
                    context.SaveChanges();
                }
            }

            [Test]
            public void EFCanAddDeleteMake()
            {
                var repo = new EFCarRepo();

                var make = new Make
                {
                    MakeName = "Test Model",
                    DateAdded = DateTime.Now,
                    UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0"
                };
                repo.AddMake(make);
               
                using (var context = new CarStoreEntities())
                {
                    var query = context.Makes
                        .OrderByDescending(q => q.MakeID)
                        .Select(q => new
                        {
                            q.MakeName,
                            q.MakeID
                            
                        }).ToList();

                    Assert.AreEqual("Test Model", query[0].MakeName);

                    var id = query[0].MakeID;

                    var queryDelete = context.Makes
                         .Where(q => q.MakeID == id)
                         .Select(q => new
                         {
                             id = q.MakeID,
                             name = q.MakeName,
                             date = q.DateAdded,
                             user = q.UserID
                         }).FirstOrDefault();

                    var makeToDelete = new Make
                    {
                        MakeID = queryDelete.id,
                        MakeName = queryDelete.name,

                        DateAdded = queryDelete.date,
                        UserID = queryDelete.user
                    };

                    context.Makes.Attach(makeToDelete);
                    context.Makes.Remove(makeToDelete);
                    context.SaveChanges();
                }

            }
            
            [Test]
            public void EFCanAddDeleteModel()
            {
                var repo = new EFCarRepo();

                var model = new Model
                {
                    ModelName = "test model",
                    MakeID = 1,
                    DateAdded = DateTime.Now,
                    UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0"
                };
                repo.AddModel(model);

                

                using (var context = new CarStoreEntities())
                {

                    var query = context.Models
                        .OrderByDescending(q => q.ModelID)
                        .Select(q => new
                        {
                            q.ModelID,
                            q.ModelName

                        }).ToList();

                Assert.AreEqual("test model", query[0].ModelName);

                var id = query[0].ModelID;
                 

                    var deleteQuery = context.Models
                         .Where(q => q.ModelID == id)
                         .Select(q => new 
                         {
                               q.ModelID,
                               q.ModelName,
                               q.MakeID,
                               q.DateAdded,
                               q.UserID
                         }).FirstOrDefault();

                    var modelToDelete = new Model
                    {
                        ModelID = deleteQuery.ModelID,
                        ModelName = deleteQuery.ModelName,
                        MakeID = deleteQuery.MakeID,
                        DateAdded = deleteQuery.DateAdded,
                        UserID = deleteQuery.UserID

                    };
                  

                    context.Models.Attach(modelToDelete);
                    context.Models.Remove(modelToDelete);
                    context.SaveChanges();
                }

            }
        }
    }
}