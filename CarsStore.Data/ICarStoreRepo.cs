using CarsStore.Models;
using System;
using System.Collections.Generic;

namespace CarsStore.Data
{
    public interface ICarStoreRepo
    {
        void DeleteCar(int id);
        Car GetCarByID(int id);
        int GetCarIDByVIN(string vin);
        void UpdateCar(Car car, int id);
        List<Specials> GetSpecials();
        List<Specials> GetSpecialsWithoutID();
        List<Car> GetCars(bool? isNew, int? minprice, int? maxprice, int? minyear, int? maxyear, string search);
        List<SalesReport> GetSalesReport(string person, DateTime? minDate, DateTime? maxDate);
        List<InventoryReport> GetInventoryReport(bool isNew);
        List<Make> GetCarMakes();
        List<Model> GetCarModels();
        List<Model> GetCarModels(int makeID);
        Model GetCarModelByID(int modelID);
        Make GetCarMakeByID(int makeID);
        List<Car> GetFeaturedCars();
        void AddSpecial(Specials special);
        Specials GetSpecialByID(int id);
        void DeleteSpecial(int id);
        void AddMake(Make make);
        void AddModel(Model model);
        void AddContact(ContactMessage contact);
        void AddCar(CarToAdd car);
        void AddSale(Sale sale);
        List<BodyStyle> GetBodyStyles();
        List<Transmission> GetTransmissions();
        List<Color> GetColors();
        List<Interior> GetInteriorColors();
        List<PurchaseType> GetPurchaseTypes();
        List<State> GetState();
        State GetState(int id);
        List<String> GetSalesPeople();
        int GetLastCarID();
        bool VinExists(string ID);
    }
}