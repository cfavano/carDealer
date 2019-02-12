using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarsStore.Models;

namespace CarsStore.Data
{
    public class ADOCarRepo : ICarStoreRepo
    {
        public void AddCar(CarToAdd car)
        {
            throw new NotImplementedException();
        }

        public void AddContact(ContactMessage contact)
        {
            throw new NotImplementedException();
        }

        public void AddMake(Make make)
        {
            throw new NotImplementedException();
        }

        public void AddModel(Model model)
        {
            throw new NotImplementedException();
        }

        public void AddSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public void AddSpecial(Specials special)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecial(int id)
        {
            throw new NotImplementedException();
        }

        public List<BodyStyle> GetBodyStyles()
        {
            throw new NotImplementedException();
        }

        public Car GetCarByID(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCarIDByVIN(string vin)
        {
            throw new NotImplementedException();
        }

        public Make GetCarMakeByID(int makeID)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetCarMakes()
        {
            throw new NotImplementedException();
        }

        public Model GetCarModelByID(int modelID)
        {
            throw new NotImplementedException();
        }

        public List<Model> GetCarModels()
        {
            throw new NotImplementedException();
        }

        public List<Model> GetCarModels(int makeID)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCars(bool? isNew, int? minprice, int? maxprice, int? minyear, int? maxyear, string search)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetColors()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetFeaturedCars() //this
        {
            throw new NotImplementedException();
        }

        public List<Interior> GetInteriorColors()
        {
            throw new NotImplementedException();
        }

        public List<InventoryReport> GetInventoryReport(bool isNew)
        {
            throw new NotImplementedException();
        }

        public int GetLastCarID()
        {
            throw new NotImplementedException();
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            throw new NotImplementedException();
        }

        public List<string> GetSalesPeople()
        {
            throw new NotImplementedException();
        }

        public List<SalesReport> GetSalesReport(string person, DateTime? minDate, DateTime? maxDate)
        {
            throw new NotImplementedException();
        }

        public Specials GetSpecialByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Specials> GetSpecials() //
        {

            var specials = new List<Specials>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {

          

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetSpecials";

                conn.Open();
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        
                            var special = new Specials()
                            {
                                Title = dataReader["Title"].ToString(),

                                Description = dataReader["Description"].ToString(),

                            };
                            specials.Add(special);
                        
                        
                    }
                }
            }
            return specials;
        }

        public List<Specials> GetSpecialsWithoutID()
        {
            throw new NotImplementedException();
        }

        public List<State> GetState()
        {
            throw new NotImplementedException();
        }

        public State GetState(int id)
        {
            throw new NotImplementedException();
        }

        public List<Transmission> GetTransmissions()
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car, int id)
        {
            throw new NotImplementedException();
        }

        public bool VinExists(string ID)
        {
            throw new NotImplementedException();
        }
    }
}