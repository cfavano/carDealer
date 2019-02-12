using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data;
using CarsStore.Models;

namespace CarsStore.Data
{
    public class EFCarRepo : ICarStoreRepo
    {
        public void DeleteCar(int id)
        {
            var car = GetCarByID(id);
            using (var context = new CarStoreEntities())
            {
                context.Cars.Attach(car);
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }

        public Car GetCarByID(int id)
        {
            using (var context = new CarStoreEntities())
            {
                var query = context.Cars
                     .Where(q => q.CarID == id)
                     .Select(q => new
                     {
                         q.VinID,
                         q.IsFeatured,
                         q.Picture,
                         q.Year,
                         q.Transmissions,
                         q.TransmissionID,
                         q.ColorID,
                         q.Colors,
                         q.Mileage,
                         q.SalesPrice,
                         q.MSRP,
                         q.Description,
                         q.IsNew,
                         q.InteriorID,
                         q.Interiors,
                         q.ModelID,
                         q.Models,
                         q.Models.Makes,
                         q.BodyStyles,
                         q.BodyStyleID,
                         q.IsAvailable,
                         q.CarID
                     }).FirstOrDefault();

                var car = new Car()
                {
                    CarID = query.CarID,
                    VinID = query.VinID,
                    IsFeatured = query.IsFeatured,
                    Picture = query.Picture,
                    Year = query.Year,
                    TransmissionID = query.TransmissionID,
                    Transmissions = query.Transmissions,
                    ColorID = query.ColorID,
                    Colors = query.Colors,
                    Mileage = query.Mileage,
                    SalesPrice = query.SalesPrice,
                    MSRP = query.MSRP,
                    Description = query.Description,
                    IsNew = query.IsNew,
                    IsAvailable = query.IsAvailable,
                    InteriorID = query.InteriorID,
                    Interiors = query.Interiors,
                    ModelID = query.ModelID,
                    Models = query.Models,
                    BodyStyles = query.BodyStyles,
                    BodyStyleID = query.BodyStyleID,
                };
                return car;
            }
        }

        public int GetCarIDByVIN(string vin)
        {
            using (var context = new CarStoreEntities())
            {
                var query = context.Cars
                     .Where(q => q.VinID == vin)
                     .Select(q => new
                     {
                         q.CarID
                     }).FirstOrDefault();

                var id = query.CarID;
                return id;
            }
        }

        public void UpdateCar(Car car, int id)
        {
            using (var context = new CarStoreEntities())
            {
                var carToUpdate = GetCarByID(id);

                carToUpdate.VinID = car.VinID;
                carToUpdate.IsFeatured = car.IsFeatured;
                carToUpdate.Year = car.Year;
                carToUpdate.ModelID = car.ModelID;
                carToUpdate.BodyStyleID = car.BodyStyleID;
                carToUpdate.TransmissionID = car.TransmissionID;
                carToUpdate.ColorID = car.ColorID;
                carToUpdate.Mileage = car.Mileage;
                carToUpdate.SalesPrice = car.SalesPrice;
                carToUpdate.MSRP = car.MSRP;
                carToUpdate.Description = car.Description;
                carToUpdate.IsNew = car.IsNew;
                carToUpdate.InteriorID = car.InteriorID;
                carToUpdate.Models.DateAdded = carToUpdate.Models.DateAdded;
                carToUpdate.Models.Makes.DateAdded = carToUpdate.Models.Makes.DateAdded;

                if (String.IsNullOrEmpty(car.Picture))
                    carToUpdate.Picture = carToUpdate.Picture;

                else
                    carToUpdate.Picture = car.Picture;

                context.Cars.Add(carToUpdate);
                context.Entry(carToUpdate).State = EntityState.Modified;

                context.Entry(carToUpdate.Models).State = EntityState.Unchanged;
                context.Entry(carToUpdate.Models.Makes).State = EntityState.Unchanged;
                context.Entry(carToUpdate.Interiors).State = EntityState.Unchanged;
                context.Entry(carToUpdate.Colors).State = EntityState.Unchanged;
                context.Entry(carToUpdate.Transmissions).State = EntityState.Unchanged;
                context.Entry(carToUpdate.BodyStyles).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }

        public List<Specials> GetSpecials()
        {
            var specials = new List<Specials>();
            using (var context = new CarStoreEntities())
            {
                var query = (from s in context.Specials
                             select new
                             {
                                 s.SpecialsID,
                                 s.Title,
                                 s.Description
                             }).ToList();

                foreach (var q in query)
                {
                    var special = new Specials()
                    {
                        SpecialsID = q.SpecialsID,
                        Title = q.Title,
                        Description = q.Description
                    };
                    specials.Add(special);
                }
                return specials;
            }
        }

        public List<Specials> GetSpecialsWithoutID()
        {
            var specials = new List<Specials>();
            using (var context = new CarStoreEntities())
            {
                var query = (from s in context.Specials
                             select new
                             {
                                 s.Title,
                                 s.Description
                             }).ToList();

                foreach (var q in query)
                {
                    var special = new Specials()
                    {
                        Title = q.Title,
                        Description = q.Description
                    };
                    specials.Add(special);
                }
                return specials;
            }
        }

        public List<Car> GetCars(bool? isNew, int? minprice, int? maxprice, int? minyear, int? maxyear, string search)
        {
            var cars = new List<Car>();
            var stringSearchList = search.ToUpper().Split(' ');
            var intList = new List<int>();


            foreach (var s in stringSearchList)
            {
                int num;
                var testInt = int.TryParse(s, out num);
                if (testInt)
                {
                    intList.Add(num);
                }
            }

            using (var context = new CarStoreEntities())
            {
                var query = context.Cars
                             .Where(q => q.IsAvailable == true)
                             .OrderByDescending(q => q.MSRP)
                             .Select(q => new
                             {
                                 q.VinID,
                                 q.IsFeatured,
                                 q.Picture,
                                 q.Year,
                                 q.Transmissions,
                                 q.Colors,
                                 q.Mileage,
                                 q.SalesPrice,
                                 q.MSRP,
                                 q.Description,
                                 q.IsNew,
                                 q.Interiors,
                                 q.Models,
                                 q.Models.Makes,
                                 q.BodyStyles,
                                 q.CarID,
                                 q.IsAvailable
                             });

                if (isNew != null)
                    query = query.Where(c => c.IsNew == isNew);

                if (minyear != null)
                    query = query.Where(c => c.Year >= minyear);

                if (maxyear != null)
                    query = query.Where(c => c.Year <= maxyear);

                if (minprice != null)
                    query = query.Where(c => c.MSRP >= minprice);

                if (maxprice != null)
                    query = query.Where(c => c.MSRP <= maxprice);

                if (!String.IsNullOrEmpty(search))
                {
                    foreach (var word in stringSearchList)
                    {
                        int number;
                        var isNum = int.TryParse(word, out number);

                        query = query.Where(c => c.Models.ModelName.ToUpper().Contains(word) || c.Models.Makes.MakeName.ToUpper().Contains(word) || c.Year == number);
                    }
                }

                var top20 = query.Take(20);

                foreach (var q in top20)
                {
                    var car = new Car()
                    {
                        VinID = q.VinID,
                        IsFeatured = q.IsFeatured,
                        Picture = q.Picture,
                        Year = q.Year,
                        Transmissions = q.Transmissions,
                        Colors = q.Colors,
                        Mileage = q.Mileage,
                        SalesPrice = q.SalesPrice,
                        MSRP = q.MSRP,
                        Description = q.Description,
                        IsNew = q.IsNew,
                        Interiors = q.Interiors,
                        CarID = q.CarID,
                        IsAvailable = q.IsAvailable,
                        Models = new Model
                        {
                            ModelName = q.Models.ModelName,

                            Makes = new Make
                            {
                                MakeName = q.Models.Makes.MakeName,
                            }
                        },
                        BodyStyles = q.BodyStyles,
                    };
                    cars.Add(car);
                }
                return cars;
            }
        }

        public List<SalesReport> GetSalesReport(string person, DateTime? minDate, DateTime? maxDate)
        {
        
            string email;
            string name;
            using (var context = new CarStoreEntities())
            {
                var query = from sale in context.Sales
                            select new { sale.SalesPerson, sale.PurchasePrice, sale.PurchaseDate };

                if (minDate != null)
                    query = query.Where(z => z.PurchaseDate >= minDate);

                if (maxDate != null)
                    query = query.Where(z => z.PurchaseDate <= maxDate);

                if (!String.IsNullOrEmpty(person))
                {
                    var index = person.IndexOf(" ");
                    email = person.Substring(0, index);
                    name = person.Substring(index + 1);
                    query = query.Where(z => z.SalesPerson.ToUpper().Contains(email.ToUpper()));

                }

                var report = (from l in query
                         group l by l.SalesPerson into grp
                         select new SalesReport
                         {
                             SalesPersonID = grp.Key,
                             TotalSales = grp.Sum(y => y.PurchasePrice),
                             TotalCars = grp.Count()
                         }).ToList();
                return report;
            }
        }

        public List<InventoryReport> GetInventoryReport(bool isNew)
        {
            using (var context = new CarStoreEntities())
            {
                var query = (from cars in context.Cars
                             where cars.IsNew == isNew
                             where cars.IsAvailable == true
                             group cars by new { cars.Year, cars.Models.Makes.MakeName, cars.Models.ModelName } into grp
                             select new InventoryReport
                             {
                                 Make = grp.Key.MakeName,
                                 Model = grp.Key.ModelName,
                                 Year = grp.Key.Year,
                                 Count = grp.Count(),
                                 Total = grp.Sum(x => x.MSRP)
                             }).ToList();
                return query;
            }
        }

        public List<Make> GetCarMakes()
        {
            var makes = new List<Make>();
            using (var context = new CarStoreEntities())
            {
                var query = (from make in context.Makes
                             orderby make.MakeName ascending
                             select new
                             {
                                 make.MakeName,
                                 make.MakeID,
                                 make.DateAdded,
                                 make.UserID
                             }).Distinct().ToList();

                foreach (var m in query)
                {
                    var make = new Make()
                    {
                        MakeName = m.MakeName,
                        MakeID = m.MakeID,
                        DateAdded = m.DateAdded,
                        UserID = m.UserID
                    };
                    makes.Add(make);
                }
                return makes;
            }
        }

        public List<Model> GetCarModels()
        {
            var models = new List<Model>();
            using (var context = new CarStoreEntities())
            {
                var query = (from model in context.Models
                             orderby model.ModelName ascending
                             select new
                             {
                                 makeName = model.Makes.MakeName,
                                 model.ModelName,
                                 model.ModelID,
                                 model.DateAdded,
                                 model.UserID,
                                 makeID = model.Makes.MakeID
                             }).Distinct().ToList();

                foreach (var x in query)
                {
                    var model = new Model
                    {
                        MakeID = x.ModelID,
                        ModelName = x.ModelName,
                        ModelID = x.ModelID,
                        DateAdded = x.DateAdded,
                        UserID = x.UserID,
                        Makes = new Make()
                        {
                            MakeID = x.makeID,
                            MakeName = x.makeName
                        }
                    };

                    models.Add(model);
                }
                return models;
            }
        }

        public List<Model> GetCarModels(int makeID)
        {
            var models = new List<Model>();
            using (var context = new CarStoreEntities())
            {
                var query = (from model in context.Models
                             where model.MakeID == makeID
                             orderby model.ModelName ascending
                             select new
                             {
                                 model.Makes.MakeName,
                                 model.ModelName,
                                 model.ModelID
                             }).Distinct().ToList();

                foreach (var x in query)
                {
                    var model = new Model
                    {
                        MakeID = x.ModelID,
                        ModelName = x.ModelName,
                        ModelID = x.ModelID
                    };

                    models.Add(model);
                }
                return models;
            }
        }

        public Model GetCarModelByID(int modelID)
        {

            using (var context = new CarStoreEntities())
            {
                var query = context.Models
                    .Where(m => m.ModelID == modelID)
                    .Select(q => new { q.DateAdded, q.ModelName }).FirstOrDefault();

                var model = new Model()
                {
                    DateAdded = query.DateAdded,
                    ModelName = query.ModelName
                };

                return model;
            }
        }

        public Make GetCarMakeByID(int makeID)
        {
            using (var context = new CarStoreEntities())
            {
                var query = context.Makes
                    .Where(m => m.MakeID == makeID)
                    .Select(q => new { q.DateAdded, q.MakeName }).FirstOrDefault();

                var make = new Make()
                {
                    DateAdded = query.DateAdded,
                    MakeName = query.MakeName

                };

                return make;
            }
        }

        public List<Car> GetFeaturedCars()
        {
            var cars = new List<Car>();

            using (var context = new CarStoreEntities())
            {
                var query = (from c in context.Cars
                             where c.IsFeatured.Equals(true)
                             select new
                             {
                                 c.CarID,
                                 c.VinID,
                                 c.IsFeatured,
                                 c.Picture,
                                 c.Year,
                                 c.TransmissionID,
                                 c.ColorID,
                                 c.Mileage,
                                 c.SalesPrice,
                                 c.MSRP,
                                 c.Description,
                                 c.IsNew,
                                 c.InteriorID,
                                 c.Models,
                                 c.BodyStyleID,
                                 c.Models.Makes
                             }).Take(20).ToList();


                foreach (var q in query)
                {
                    var car = new Car()
                    {
                        CarID = q.CarID,
                        VinID = q.VinID,
                        IsFeatured = q.IsFeatured,
                        Picture = q.Picture,
                        Year = q.Year,
                        TransmissionID = q.TransmissionID,
                        ColorID = q.ColorID,
                        Mileage = q.Mileage,
                        SalesPrice = q.SalesPrice,
                        MSRP = q.MSRP,
                        Description = q.Description,
                        IsNew = q.IsNew,
                        InteriorID = q.InteriorID,
                        Models = new Model
                        {
                            ModelName = q.Models.ModelName,
                            Makes = new Make
                            {
                                MakeName = q.Makes.MakeName
                            }
                        },
                        BodyStyleID = q.BodyStyleID,
                    };
                    cars.Add(car);
                }
            }
            return cars;
        }

        public void AddSpecial(Specials special)
        {
            using (var context = new CarStoreEntities())
            {
                var newSpecial = new Specials
                {
                    Title = special.Title,
                    Description = special.Description

                };
                context.Specials.Add(newSpecial);
                context.SaveChanges();
            }
        }

        public Specials GetSpecialByID(int id)
        {
            using (var context = new CarStoreEntities())
            {
                var query = context.Specials
                            .Where(q => q.SpecialsID == id)
                            .Select(q => new
                            {
                                id = q.SpecialsID,
                                description = q.Description,
                                title = q.Title
                            }).FirstOrDefault();

                var special = new Specials()
                {
                    SpecialsID = query.id,
                    Description = query.description,
                    Title = query.title
                };

                return special;
            }
        }

        public void DeleteSpecial(int id)
        {
            var special = GetSpecialByID(id);
            using (var context = new CarStoreEntities())
            {
                context.Specials.Attach(special);
                context.Specials.Remove(special);
                context.SaveChanges();
            }
        }

        public void AddMake(Make make)
        {
            using (var context = new CarStoreEntities())
            {
                var newMake = new Make
                {
                    MakeName = make.MakeName,
                    DateAdded = DateTime.Now,
                    UserID = make.UserID
                };
                context.Makes.Add(newMake);
                context.SaveChanges();
            }
        }

        public void AddModel(Model model)
        {
            using (var context = new CarStoreEntities())
            {
                var newModel = new Model

                {
                    ModelName = model.ModelName,
                    DateAdded = DateTime.Now,
                    MakeID = model.MakeID,
                    UserID = model.UserID
                };

                context.Models.Add(newModel);
                context.SaveChanges();
            }
        }

        public void AddContact(ContactMessage contact)
        {
            using (var context = new CarStoreEntities())
            {
                context.ContactMessages.Add(contact);
                context.SaveChanges();
            }
        }

        public void AddCar(CarToAdd car)
        {
            using (var context = new CarStoreEntities())
            {

                var model = GetCarModelByID(car.ModelID);

                var make = GetCarMakeByID(car.MakeID);

                var newCar = new Car()
                {
                    VinID = car.VinID,
                    IsFeatured = car.IsFeatured,
                    Picture = car.Picture,
                    Year = car.Year,
                    TransmissionID = car.TransmissionID,
                    ColorID = car.ColorID,
                    Mileage = car.Mileage,
                    SalesPrice = car.SalesPrice,
                    MSRP = car.MSRP,
                    Description = car.Description,
                    IsNew = car.IsNew,
                    InteriorID = car.InteriorID,
                    ModelID = car.ModelID,
                    BodyStyleID = car.BodyStyleID,
                    IsAvailable = true
                };
                context.Cars.Add(newCar);
                context.SaveChanges();
            }
        }

        public void AddSale(Sale sale)
        {
            var purchasedCar = GetCarByID(sale.CarID);
            purchasedCar.IsAvailable = false;
            using (var context = new CarStoreEntities())
            {
                context.Sales.Add(sale);
                context.Cars.Add(purchasedCar);

                context.Entry(purchasedCar).State = EntityState.Modified;
                context.Entry(purchasedCar.Models).State = EntityState.Unchanged;
                context.Entry(purchasedCar.Models.Makes).State = EntityState.Unchanged;
                context.Entry(purchasedCar.Interiors).State = EntityState.Unchanged;
                context.Entry(purchasedCar.Colors).State = EntityState.Unchanged;
                context.Entry(purchasedCar.Transmissions).State = EntityState.Unchanged;
                context.Entry(purchasedCar.BodyStyles).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }

        public List<BodyStyle> GetBodyStyles()
        {
            var bodyStyles = new List<BodyStyle>();
            using (var context = new CarStoreEntities())
            {
                var query = context.BodyStyles
                    .Select(q => new
                    {
                        q.BodyStyleID,
                        q.BodyStyleName
                    });

                foreach (var q in query)
                {
                    var bodyStyle = new BodyStyle
                    {
                        BodyStyleID = q.BodyStyleID,
                        BodyStyleName = q.BodyStyleName
                    };

                    bodyStyles.Add(bodyStyle);
                }
                return bodyStyles;
            }
        }

        public List<Transmission> GetTransmissions()
        {
            var transmissions = new List<Transmission>();

            using (var context = new CarStoreEntities())
            {
                var query = context.Transmissions
                    .Select(q => new
                    {
                        q.TransmissionID,
                        q.TransmissionType
                    });

                foreach (var q in query)
                {
                    var transmission = new Transmission
                    {
                        TransmissionID = q.TransmissionID,
                        TransmissionType = q.TransmissionType
                    };
                    transmissions.Add(transmission);
                }
                return transmissions;
            }
        }

        public List<Color> GetColors()
        {
            var colors = new List<Color>();

            using (var context = new CarStoreEntities())
            {
                var query = context.Colors
                    .Select(q => new
                    {
                        q.ColorID,
                        q.ColorName
                    });

                foreach (var q in query)
                {
                    var color = new Color
                    {
                        ColorID = q.ColorID,
                        ColorName = q.ColorName
                    };
                    colors.Add(color);
                }
                return colors;
            }
        }

        public List<Interior> GetInteriorColors()
        {
            var interiors = new List<Interior>();
            using (var context = new CarStoreEntities())
            {
                var query = context.Interiors
                    .Select(q => new
                    {
                        q.InteriorID,
                        q.InteriorColor
                    });

                foreach (var q in query)
                {
                    var interior = new Interior
                    {
                        InteriorID = q.InteriorID,
                        InteriorColor = q.InteriorColor
                    };
                    interiors.Add(interior);
                }
                return interiors;
            }
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            var purchaseTypes = new List<PurchaseType>();

            using (var context = new CarStoreEntities())
            {
                var query = context.PurchaseTypes
                    .Select(q => new
                    {
                        q.PurchaseTypeID,
                        q.PurchaseTypeName
                    });

                foreach (var q in query)
                {
                    var purchaseType = new PurchaseType
                    {
                        PurchaseTypeID = q.PurchaseTypeID,
                        PurchaseTypeName = q.PurchaseTypeName

                    };
                    purchaseTypes.Add(purchaseType);
                }
            }
            return purchaseTypes;
        }

        public List<State> GetState()
        {
            var states = new List<State>();
            using (var context = new CarStoreEntities())
            {
                var query = context.States
                    .Select(q => new
                    {
                        id = q.StateID,
                        name = q.StateName,
                        abbreviation = q.StateAbbreviation
                    }).ToList();

                foreach (var q in query)
                {
                    var state = new State
                    {
                        StateID = q.id,
                        StateName = q.name,
                        StateAbbreviation = q.abbreviation

                    };
                    states.Add(state);
                }
                return states;
            };
        }

        public State GetState(int id)
        {
            using (var context = new CarStoreEntities())
            {
                var query = context.States
                    .Where(q => q.StateID == id)
                    .Select(q => new
                    {
                        id = q.StateID,
                        name = q.StateName,
                        abbreviation = q.StateAbbreviation
                    }).FirstOrDefault();

                var state = new State
                {
                    StateID = query.id,
                    StateName = query.name,
                    StateAbbreviation = query.abbreviation

                };
                return state;
            };
        }

        public List<String> GetSalesPeople()
        {
            var names = new List<string>();
            using (var context = new CarStoreEntities())
            {
                var query = context.Sales
                    .Select(q => new{q.SalesPerson}).Distinct().ToList();

                foreach (var x in query)
                {
                    names.Add(x.SalesPerson);
                }
                return names;
            }
        }

        public int GetLastCarID()
        {
            using (var context = new CarStoreEntities())
            {
                var query = context.Cars
                    .OrderByDescending(q => q.CarID)
                    .Select(q => new { q.CarID }).FirstOrDefault();
                return query.CarID;
            };
        }

        public bool VinExists(string ID) {
            using (var context = new CarStoreEntities())
            {
                var query = context.Cars
                    .Where(q => q.VinID == ID)
                    .Select(q => new
                    {
                        q.VinID
                    }).ToList();

                if (query.Count > 0) {
                    return true;
                }
                return false;
            };
        }
    }
    
}
