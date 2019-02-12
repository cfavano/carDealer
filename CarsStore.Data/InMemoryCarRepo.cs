﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarsStore.Models;

namespace CarsStore.Data
{
    public class InMemoryCarRepo : ICarStoreRepo
    {
        private static List<State> _states = new List<State> {
                new State { StateID = 1, StateAbbreviation = "AL", StateName = "Alabama" },
                new State { StateID = 2, StateAbbreviation = "AK", StateName = "Alaska" },
                new State { StateID = 3, StateAbbreviation = "AZ", StateName = "Arizona" },
                new State { StateID = 4, StateAbbreviation = "AR", StateName = "Arkansas" },
                new State { StateID = 5, StateAbbreviation = "CA", StateName = "California" },
                new State { StateID = 6, StateAbbreviation = "CO", StateName = "Colorado" },
                new State { StateID = 7, StateAbbreviation = "CT", StateName = "Connecticut" },
                new State { StateID = 8, StateAbbreviation = "DE", StateName = "Delaware" },
                new State { StateID = 9, StateAbbreviation = "FL", StateName = "Florida" },
                new State { StateID = 10, StateAbbreviation = "GA", StateName = "Georgia" },
                new State { StateID = 11, StateAbbreviation = "HI", StateName = "Hawaii" },
                new State { StateID = 12, StateAbbreviation = "ID", StateName = "Idaho" },
                new State { StateID = 13, StateAbbreviation = "IL", StateName = "Illinois" },
                new State { StateID = 14, StateAbbreviation = "IN", StateName = "Indiana" },
                new State { StateID = 15, StateAbbreviation = "IA", StateName = "Iowa" },
                new State { StateID = 16, StateAbbreviation = "KS", StateName = "Kansas" },
                new State { StateID = 17, StateAbbreviation = "KY", StateName = "Kentucky" },
                new State { StateID = 18, StateAbbreviation = "LA", StateName = "Louisiana" },
                new State { StateID = 19, StateAbbreviation = "ME", StateName = "Maine" },
                new State { StateID = 20, StateAbbreviation = "MD", StateName = "Maryland" },
                new State { StateID = 21, StateAbbreviation = "MA", StateName = "Massachusetts" },
                new State { StateID = 22, StateAbbreviation = "MI", StateName = "Michigan" },
                new State { StateID = 23, StateAbbreviation = "MN", StateName = "Minnesota" },
                new State { StateID = 24, StateAbbreviation = "MS", StateName = "Mississippi" },
                new State { StateID = 25, StateAbbreviation = "MO", StateName = "Missouri" },
                new State { StateID = 26, StateAbbreviation = "MT", StateName = "Montana" },
                new State { StateID = 27, StateAbbreviation = "NE", StateName = "Nebraska" },
                new State { StateID = 28, StateAbbreviation = "NV", StateName = "Nevada" },
                new State { StateID = 29, StateAbbreviation = "NH", StateName = "New Hampshire" },
                new State { StateID = 30, StateAbbreviation = "NJ", StateName = "New Jersey" },
                new State { StateID = 31, StateAbbreviation = "NM", StateName = "New Mexico" },
                new State { StateID = 32, StateAbbreviation = "NY", StateName = "New York" },
                new State { StateID = 33, StateAbbreviation = "NC", StateName = "North Carolina" },
                new State { StateID = 34, StateAbbreviation = "ND", StateName = "North Dakota" },
                new State { StateID = 35, StateAbbreviation = "OH", StateName = "Ohio" },
                new State { StateID = 36, StateAbbreviation = "OK", StateName = "Oklahoma" },
                new State { StateID = 37, StateAbbreviation = "OR", StateName = "Oregon" },
                new State { StateID = 38, StateAbbreviation = "PA", StateName = "Pennsylvania" },
                new State { StateID = 39, StateAbbreviation = "RI", StateName = "Rhode Island" },
                new State { StateID = 40, StateAbbreviation = "SC", StateName = "South Carolina" },
                new State { StateID = 41, StateAbbreviation = "SD", StateName = "South Dakota" },
                new State { StateID = 42, StateAbbreviation = "TN", StateName = "Tennessee" },
                new State { StateID = 43, StateAbbreviation = "TX", StateName = "Texas" },
                new State { StateID = 44, StateAbbreviation = "UT", StateName = "Utah" },
                new State { StateID = 45, StateAbbreviation = "VT", StateName = "Vermont" },
                new State { StateID = 46, StateAbbreviation = "VA", StateName = "Virginia	" },
                new State { StateID = 47, StateAbbreviation = "WA", StateName = "Washington" },
                new State { StateID = 48, StateAbbreviation = "WV", StateName = "West Virginia" },
                new State { StateID = 49, StateAbbreviation = "WI", StateName = "Wisconsin" },
                new State { StateID = 50, StateAbbreviation = "WY", StateName = "Wyoming" }
        };

        private static List<BodyStyle> _bodystyles = new List<BodyStyle> {
                new BodyStyle { BodyStyleID = 1, BodyStyleName = "Car" },
                new BodyStyle { BodyStyleID = 2, BodyStyleName = "SUV" },
                new BodyStyle { BodyStyleID = 3, BodyStyleName = "Van" },
                new BodyStyle { BodyStyleID = 4, BodyStyleName = "Truck" }
            };

        private static List<Transmission> _transmissions = new List<Transmission> {
                new Transmission { TransmissionID = 1, TransmissionType = "Manual" },
                new Transmission { TransmissionID = 2, TransmissionType = "Automatic" }
            };

        private static List<Color> _colors = new List<Color> {
                new Color { ColorID = 1, ColorName = "Black" },
                new Color { ColorID = 2, ColorName = "White" },
                new Color { ColorID = 3, ColorName = "Red" },
                new Color { ColorID = 4, ColorName = "Blue" },
                new Color { ColorID = 5, ColorName = "Gray" }
            };

        private static List<Interior> _interiors = new List<Interior> {
                new Interior { InteriorID = 1, InteriorColor = "Gray" },
                new Interior { InteriorID = 2, InteriorColor = "Black" },
                new Interior { InteriorID = 3, InteriorColor = "White" },
                new Interior { InteriorID = 4, InteriorColor = "Peach" },
                new Interior { InteriorID = 5, InteriorColor = "Cream" }
        };

        private static List<Specials> _specials = new List<Specials> {
                new Specials { SpecialsID = 1, Title = "Holiday Special", Description = "orem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                new Specials { SpecialsID = 2, Title = "First Time Buyer", Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. " },
                new Specials { SpecialsID = 3, Title = "Military Discount", Description = "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?" }
        };

        private static List<ContactMessage> _contactMessages = new List<ContactMessage> {
                new ContactMessage { ContactMessageID = 1, Name = "Harold Finch", Phone = "7181231234", Message = "Can I get a customized color on a specific car?", Email = "hfinch@gmail.com" },
                new ContactMessage { ContactMessageID = 2, Name = "John Reese", Phone = "2124568945", Message = "I would like to inquire if you have a military discount", Email = "johnreese@gmail.com" },
                new ContactMessage { ContactMessageID = 3, Name = "Joss Carter", Phone = "9176543214", Message = "What is the sales tax in your county", Email = "jcarter@gmail.com" }
        };

        private static List<Make> _makes = new List<Make> {
                new Make { MakeID = 1, MakeName = "Audi", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 2, MakeName = "Buick", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 3, MakeName = "BMW", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 4, MakeName = "Chevrolet", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 5, MakeName = "Volkswagen", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 6, MakeName = "Honda", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 7, MakeName = "Toyota", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 8, MakeName = "Kia", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Make { MakeID = 9, MakeName = "Ford", DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" }
        };

        private static List<Model> _models = new List<Model> {
                new Model { ModelID = 1, ModelName = "A3 Sportback e-tron", MakeID = 1, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 2, ModelName = "A4 allroad", MakeID = 1, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 3, ModelName = "LaCrosse", MakeID = 2, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 4, ModelName = "Enclave", MakeID = 2, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 5, ModelName = "M3", MakeID = 3, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 6, ModelName = "X1", MakeID = 3, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 7, ModelName = "Silverado 1500", MakeID = 4, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 8, ModelName = "Colorado", MakeID = 4, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 9, ModelName = "New Beetle", MakeID = 5, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 10, ModelName = "Bus", MakeID = 5, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },

                new Model { ModelID = 11, ModelName = "Civic", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 12, ModelName = "CR-V", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 13, ModelName = "Fit", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 14, ModelName = "HR-v", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 15, ModelName = "Accord", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 16, ModelName = "Civic Type R", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 17, ModelName = "Insight", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 18, ModelName = "Pilot", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 19, ModelName = "Odyssey", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 20, ModelName = "Ridgeline", MakeID = 6, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },

                new Model { ModelID = 21, ModelName = "Corolla", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 22, ModelName = "Camry", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 23, ModelName = "Rav4", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 24, ModelName = "C-HR", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 25, ModelName = "Prius", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 26, ModelName = "Yaris", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 27, ModelName = "Land Cruiser", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 28, ModelName = "4Runner", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 29, ModelName = "Tacoma", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 30, ModelName = "Highlander", MakeID = 7, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },

                new Model { ModelID = 31, ModelName = "Sportage", MakeID = 8, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 32, ModelName = "Soul", MakeID = 8, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },

                new Model { ModelID = 33, ModelName = "Focus", MakeID = 9, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" },
                new Model { ModelID = 34, ModelName = "Fiesta", MakeID = 9, DateAdded = new DateTime(2018, 11, 12), UserID = "80fbd47b-586d-4ad6-8d90-3dcd17d845e0" }

        };

        private static List<PurchaseType> _purchaseTypes = new List<PurchaseType> {
                new PurchaseType { PurchaseTypeID = 1, PurchaseTypeName = "Bank Finance" },
                new PurchaseType { PurchaseTypeID = 2, PurchaseTypeName = "Dealer Finance" },
                new PurchaseType { PurchaseTypeID = 3, PurchaseTypeName = "Cash" }
        };

        private static List<Car> _cars = new List<Car> {
                new Car
                { CarID = 1,
                    VinID = "1FTFW1EV2AFC41754",
                    IsFeatured = false,
                    Picture = "inventory-1.jpg",
                    Year = 2018,
                    ModelID = 1,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 1,
                    Mileage = 0,
                    SalesPrice = 48000,
                    MSRP = 49875,
                    Description = "A pleasing blend of hybrid and hatchback, the A3 e-tron gives you Audi cachet and power, plus an EPA-rated 83–86 MPGe. In fairness, in our test, we saw just 40 MPGe, but by most every performance measure the A3 e-tron still beats the BMW i3, the Chevrolet Volt, and the Ford C-Max Energi. A turbo four and a six-speed automatic team with an electric motor and battery. Electric-only range is rated at 16 miles. With 14 cubic feet of cargo space, this hatchback is roomy enough for everyday tasks.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = false
                },
                new Car
                {
                    CarID = 2,
                    VinID = "JM3ER2W55A0305917",
                    IsFeatured = false,
                    Picture = "inventory-2.jpg",
                    Year = 2019,
                    ModelID = 2,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 2,
                    Mileage = 0,
                    SalesPrice = 43000,
                    MSRP = 45475,
                    Description = "While the Allroad may not be a hard-core off-roader, as competent all-weather transportation, it hits the mark. Plus, we really like wagons, and with a maximum of 58.5 cu ft of cargo space, the Allroad meets the needs of most buyers. A 252-hp turbo 2.0-liter four teams with a seven-speed dual-clutch automatic; all-wheel drive is standard. It’s a fine highway cruiser and easily tackles country roads thanks to its Offroad mode.",
                    IsNew = true,
                    InteriorID = 2,
                    IsAvailable = false
                },
                new Car
                {
                    CarID = 3,
                    VinID = "1HD1FC41X8Y680850",
                    IsFeatured = true,
                    Picture = "inventory-3.png",
                    Year = 2015,
                    ModelID = 3,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 3,
                    Mileage = 15000,
                    SalesPrice = 30000,
                    MSRP = 30490,
                    Description = "Enticing new buyers and satisfying loyalists requires careful balance, but the LaCrosse delivers. With the base setup, it’s a casual hybrid cruiser with a four-cylinder and an electric motor. The optional V-6 provides more gusto, and an available adaptive suspension transforms the LaCrosse into a  competent sedan; those seeking a floatier ride will prefer the base suspension instead. The LaCrosse is loaded with tech, including Apple CarPlay, Android Auto, and 4G LTE Wi-Fi all as standard.",
                    IsNew = false,
                    InteriorID = 3,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 4,
                    VinID = "1FTRF12255NB94299",
                    IsFeatured = false,
                    Picture = "inventory-4.jpg",
                    Year = 2017,
                    ModelID = 4,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 2,
                    Mileage = 22000,
                    SalesPrice = 40000,
                    MSRP = 40990,
                    Description = "The Enclave offers spacious accommodations in all three rows of seating. A 310-hp 3.6-liter V-6 and nine-speed automatic drive the front or all four wheels. Second-row occupants enjoy captain’s chairs, while third-row passengers sit on a power-folding bench seat. All Enclaves come with an 8.0-inch infotainment touchscreen, Apple CarPlay, Android Auto, and a 4G LTE Wi-Fi hotspot; automated emergency braking and adaptive cruise control are optional.",
                    IsNew = false,
                    InteriorID = 4,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 5,
                    VinID = "WVGBV7AX7DW519950",
                    IsFeatured = false,
                    Picture = "inventory-5.jpg",
                    Year = 2019,
                    ModelID = 5,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 1,
                    Mileage = 0,
                    SalesPrice = 67000,
                    MSRP = 67495,
                    Description = "The M3 is a legend in the world of performance cars, causing enthusiasts to gush when given the chance. Under the hood is a twin-turbo 3.0-liter inline-six that makes 425 hp and 406 lb-ft of torque; it makes glorious sounds all the way to its 7500-rpm redline. For more power, the Competition package offers 444 ponies. A six-speed manual is standard and a seven-speed dual-clutch automatic is optional. The M3 comes only as a sedan; coupe and convertibles wear the M4 badge.",
                    IsNew = true,
                    InteriorID = 5,
                    IsAvailable = false
                },
                new Car
                {
                    CarID = 6,
                    VinID = "1N4AL3AP1DC231850",
                    IsFeatured = false,
                    Picture = "inventory-6.jpg",
                    Year = 2010,
                    ModelID = 6,
                    BodyStyleID = 2,
                    TransmissionID = 1,
                    ColorID = 1,
                    Mileage = 15000,
                    SalesPrice = 33900,
                    MSRP = 34000,
                    Description = "Despite its SUV-like body, the X1 offers distinctly BMW-like driving fun, earning it one of our 10Best awards for 2018. Responsive steering and a firm ride make tossing it around back-country roads a joy. The 2.0-liter turbo four-cylinder makes 228 hp and drives either the front or all four wheels through an eight-speed automatic. Infotainment with a 6.5-inch display and Bluetooth is standard; nav, adaptive cruise control, automated emergency braking, and a self-parking feature are optional.",
                    IsNew = false,
                    InteriorID = 4,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 7,
                    VinID = "2FMDK39CX8BA32230",
                    IsFeatured = true,
                    Picture = "inventory-7.jpg",
                    Year = 2019,
                    ModelID = 7,
                    BodyStyleID = 3,
                    TransmissionID = 2,
                    ColorID = 2,
                    Mileage = 0,
                    SalesPrice = 33300,
                    MSRP = 33695,
                    Description = "Chevrolet’s weapon in the ever-raging truck wars is the rugged, adaptable, and trusty Silverado 1500. A range of engines—including a V-6, three V-8 choices, a turbocharged four-cylinder, and a diesel inline-six—means there’s a Silverado for any job. On the road, the big truck drives smaller than it is; handling is surprisingly agile, and the suspension delivers a smooth ride. Clever storage cubbies dot the cabin, and stout towing capacities mean hauling extra stuff out back is a snap.",
                    IsNew = true,
                    InteriorID = 3,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 8,
                    VinID = "5N1AN08W78C539767",
                    IsFeatured = false,
                    Picture = "inventory-8.jpg",
                    Year = 2017,
                    ModelID = 8,
                    BodyStyleID = 3,
                    TransmissionID = 2,
                    ColorID = 3,
                    Mileage = 10000,
                    SalesPrice = 20000,
                    MSRP = 20200,
                    Description = "Colorado ZR2 is capable of just about anything, with everything you need to be trail-ready from day one. That includes one-touch terrain select for desert, mud or mountains that adjusts the calibration of the engine, transmission and Traction Control to enhance performance. And when the trail day ends, segment-exclusive Multimatic™ shocks offer an exceptional ride when you transition to paved roads.",
                    IsNew = false,
                    InteriorID = 2,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 9,
                    VinID = "JM1BL1UF2B1381688",
                    IsFeatured = false,
                    Picture = "inventory-9.jpg",
                    Year = 2019,
                    ModelID = 9,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 4,
                    Mileage = 0,
                    SalesPrice = 21000,
                    MSRP = 21115,
                    Description = "Its shape is among the most distinctive on the road; happily, the Beetle, offered as a coupe or a convertible, is as fun to drive as it looks. A 174-hp turbo four pairs to a six-speed automatic and front-wheel drive for reasonably peppy performance. The Beetle Dune rides 0.4 in higher and has off-road styling elements. The Beetle’s quirky, retro-look design is charming, and options such as blind-spot monitoring and a touchscreen navigation system bring it into the modern era.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 10,
                    VinID = "JN8AZ2NE1F9081562",
                    IsFeatured = false,
                    Picture = "inventory-10.jpg",
                    Year = 2000,
                    ModelID = 10,
                    BodyStyleID = 4,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 70000,
                    SalesPrice = 27700,
                    MSRP = 28000,
                    Description = "Beautifully restored 2000 VW Camper Van.Vanagan Bus 4 speed on the floor, 4 cylinder, with a rebuilt carburetor, tires are in good condition, great Kenwood stereo system, leather spare tire cover on the front. Clean interior! ",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 11,
                    VinID = "3N1AB7AP2EY256692",
                    IsFeatured = false,
                    Picture = "inventory-11.jpg",
                    Year = 2019,
                    ModelID = 11,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 19000,
                    MSRP = 19450,
                    Description = "The Civic exemplifies automotive excellence and mixes fun with efficiency and practicality. Offered in sedan, hatchback, and coupe body styles, there's a Civic model for everyone—including enthusiast drivers, although we review the Civic Si and the Civic Type R performance models separately. Precise steering and a well-tuned suspension provide sweet handling; the Sport model earned a 2018 10Best Cars award for its blend of value, utility, and fun-to-drive quality. Each model comes with one of two four-cylinder engines, one of which is a turbo; the standard 2.0-liter four-cylinder makes 158 horsepower, but the sweet turbocharged 1.5-liter is boosted to either 174 or 180 ponies (depending on trim). In our testing, it helped hustle the Civic Touring sedan from zero to 60 mph in just 6.9 seconds. The interior is spacious and well built,  but some may find the seats lack support.The Civic's optional 7.0-inch touchscreen infotainment system provides plenty of connectivity features, including Apple CarPlay and Android Auto, but its menus are poorly organized and the absence of physical knobs and buttons means making volume or tuning adjustments while driving is a challenge. Honda provides active-safety technologies such as automated emergency braking, lane-keeping assist, and adaptive cruise control, but none of the features are offered as standard. A freshened Civic sedan and coupe debut for 2019 with a new infotainment setup and more standard active-safety gear. Can't wait for the 2019 ? The current Civic in all of its iterations is still a great car at a fair price. ",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 12,
                    VinID = "2C4RDGBGXCR179639",
                    IsFeatured = false,
                    Picture = "inventory-12.png",
                    Year = 2019,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 24000,
                    MSRP = 24250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 13,
                    VinID = "5FNYF4H75CB001273",
                    IsFeatured = false,
                    Picture = "inventory-13.jpg",
                    Year = 2019,
                    ModelID = 13,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 16000,
                    MSRP = 16190,
                    Description = "Fit Ride and Handling: Playful and Agile. For a subcompact hatchback, the front-wheel-drive Fit is fun to drive, thanks to its precise steering and sharp handling. The suspension does a good job of absorbing bumps (though the ride is a little firm), and added insulation for 2018 means the cabin is now even quieter.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 14,
                    VinID = "WBXPC93497WF17562",
                    IsFeatured = false,
                    Picture = "inventory-14.jpg",
                    Year = 2019,
                    ModelID = 14,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 19600,
                    MSRP = 19670,
                    Description = "The HR-V has an attractive design, but look beyond the surface and you’ll find it lacking. The driving experience is uninspired due to an anemic engine—even when teamed with the manual transmission. Light steering and a soft suspension result in disappointing driving dynamics. The interior is practical thanks to its configurability; there’s a maximum of 59 cubic feet of storage. Touch-capacitive buttons make the infotainment system hard to use; Apple CarPlay and Android Auto aren’t offered. ",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 15,
                    VinID = "1FAFP40634F150386",
                    IsFeatured = false,
                    Picture = "inventory-15.jpg",
                    Year = 2019,
                    ModelID = 15,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 27700,
                    MSRP = 28000,
                    Description = "Turbo engines are both powerful and fuel-efficient. Interior is cavernous and fitted with upscale materials Sporty handling makes it fun to drive.Many advanced driver safety aids come standard",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 16,
                    VinID = "WDDHF9HBXEA922004",
                    IsFeatured = false,
                    Picture = "inventory-16.jpg",
                    Year = 2019,
                    ModelID = 16,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 34000,
                    MSRP = 34700,
                    Description = "The lone powertrain is a turbocharged four that pumps its 306 horsepower to the front wheels. The Type R handles corners with poise, but the ride isn't punishing over rough pavement. In our testing, it went from zero to 60 mph in 4.9 seconds and braked from 70 mph to a stop in 142 feet.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 17,
                    VinID = "JM1BL1UF6C1527446",
                    IsFeatured = false,
                    Picture = "inventory-17.jpg",
                    Year = 2019,
                    ModelID = 17,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 22000,
                    MSRP = 22830,
                    Description = "The Honda Insight is a hybrid electric vehicle that was manufactured and marketed by Honda in its first generation as a three-door, two passenger hatchback (1999–2006) and in its second generation as a five-door, five passenger liftback (2009–2014). ... The Insight was the least expensive hybrid available in the US.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 18,
                    VinID = "WMWRH33545TK55424",
                    IsFeatured = false,
                    Picture = "inventory-18.png",
                    Year = 2019,
                    ModelID = 18,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 31000,
                    MSRP = 31450,
                    Description = "Image result for honda pilot description The Pilot shares its platform with the Acura MDX, as well as the Odyssey minivan and the Accord sedan.The Pilot's unibody construction and independent suspension are designed to provide handling similar to that of a car, and it has integrated perimeter frame rails to allow towing and light off-road use.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 19,
                    VinID = "1FAFP53U52G172039",
                    IsFeatured = false,
                    Picture = "inventory-19.jpg",
                    Year = 2019,
                    ModelID = 19,
                    BodyStyleID = 4,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 30000,
                    MSRP = 30090,
                    Description = "The Odyssey was introduced in 1994 as Honda's first minivan — based on the Accord platform, with a 4-cylinder engine, all-disc anti-lock braking, all wishbone suspension, and a four-speed automatic transmission with a steering-column-mounted shifter and a hill-hold feature, marketed as Grade Logic.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                 new Car
                 {
                     CarID = 20,
                     VinID = "1HGCR2F59DA242126",
                     IsFeatured = false,
                     Picture = "inventory-20.jpg",
                     Year = 2019,
                     ModelID = 20,
                     BodyStyleID = 4,
                     TransmissionID = 2,
                     ColorID = 5,
                     Mileage = 0,
                     SalesPrice = 29500,
                     MSRP = 29900,
                     Description = "The 2019 Honda Ridgeline is a distinctive choice for a midsize pickup truck. Rather than going with the crowd and opting for a traditional body-on-frame design, Honda uses a more carlike unibody construction and a fully independent suspension for the Ridgeline.",
                     IsNew = true,
                     InteriorID = 1,
                     IsAvailable = true
                 },
                new Car
                {
                    CarID = 21,
                    VinID = "1FTWW3DY7AEA80136",
                    IsFeatured = false,
                    Picture = "inventory-21.png",
                    Year = 2007,
                    ModelID = 11,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 12000,
                    SalesPrice = 11000,
                    MSRP = 11450,
                    Description = "The Civic exemplifies automotive excellence and mixes fun with efficiency and practicality. Offered in sedan, hatchback, and coupe body styles, there's a Civic model for everyone—including enthusiast drivers, although we review the Civic Si and the Civic Type R performance models separately. Precise steering and a well-tuned suspension provide sweet handling; the Sport model earned a 2018 10Best Cars award for its blend of value, utility, and fun-to-drive quality. Each model comes with one of two four-cylinder engines, one of which is a turbo; the standard 2.0-liter four-cylinder makes 158 horsepower, but the sweet turbocharged 1.5-liter is boosted to either 174 or 180 ponies (depending on trim). In our testing, it helped hustle the Civic Touring sedan from zero to 60 mph in just 6.9 seconds. The interior is spacious and well built,  but some may find the seats lack support.The Civic's optional 7.0-inch touchscreen infotainment system provides plenty of connectivity features, including Apple CarPlay and Android Auto, but its menus are poorly organized and the absence of physical knobs and buttons means making volume or tuning adjustments while driving is a challenge. Honda provides active-safety technologies such as automated emergency braking, lane-keeping assist, and adaptive cruise control, but none of the features are offered as standard. A freshened Civic sedan and coupe debut for 2019 with a new infotainment setup and more standard active-safety gear. Can't wait for the 2019 ? The current Civic in all of its iterations is still a great car at a fair price. ",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 22,
                    VinID = "JM1BK32FX61466429",
                    IsFeatured = false,
                    Picture = "inventory-22.jpg",
                    Year = 2008,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 16000,
                    SalesPrice = 18000,
                    MSRP = 18250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 23,
                    VinID = "1G1ZC5EU9CF371563",
                    IsFeatured = false,
                    Picture = "inventory-23.jpg",
                    Year = 2009,
                    ModelID = 13,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 17000,
                    SalesPrice = 12000,
                    MSRP = 12190,
                    Description = "Fit Ride and Handling: Playful and Agile. For a subcompact hatchback, the front-wheel-drive Fit is fun to drive, thanks to its precise steering and sharp handling. The suspension does a good job of absorbing bumps (though the ride is a little firm), and added insulation for 2018 means the cabin is now even quieter.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 24,
                    VinID = "2HGEJ6611XH544973",
                    IsFeatured = false,
                    Picture = "inventory-24.jpg",
                    Year = 2010,
                    ModelID = 14,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 18000,
                    SalesPrice = 12600,
                    MSRP = 12670,
                    Description = "The HR-V has an attractive design, but look beyond the surface and you’ll find it lacking. The driving experience is uninspired due to an anemic engine—even when teamed with the manual transmission. Light steering and a soft suspension result in disappointing driving dynamics. The interior is practical thanks to its configurability; there’s a maximum of 59 cubic feet of storage. Touch-capacitive buttons make the infotainment system hard to use; Apple CarPlay and Android Auto aren’t offered. ",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 25,
                    VinID = "1G4HP52K34U147465",
                    IsFeatured = false,
                    Picture = "inventory-25.jpg",
                    Year = 2011,
                    ModelID = 15,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 10000,
                    SalesPrice = 20700,
                    MSRP = 20000,
                    Description = "Accord Turbo engines are both powerful and fuel-efficient.Interior is cavernous and fitted with upscale materials Sporty handling makes it fun to drive.Many advanced driver safety aids come standard",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 26,
                    VinID = "WP0CA2992YS652917",
                    IsFeatured = false,
                    Picture = "inventory-26.png",
                    Year = 2012,
                    ModelID = 16,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 30000,
                    SalesPrice = 24000,
                    MSRP = 24700,
                    Description = "Civic R The lone powertrain is a turbocharged four that pumps its 306 horsepower to the front wheels. The Type R handles corners with poise, but the ride isn't punishing over rough pavement. In our testing, it went from zero to 60 mph in 4.9 seconds and braked from 70 mph to a stop in 142 feet.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 27,
                    VinID = "5TFUW5F14AX119983",
                    IsFeatured = false,
                    Picture = "inventory-27.jpg",
                    Year = 2013,
                    ModelID = 17,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 25000,
                    SalesPrice = 17000,
                    MSRP = 17830,
                    Description = "The Honda Insight is a hybrid electric vehicle that was manufactured and marketed by Honda in its first generation as a three-door, two passenger hatchback (1999–2006) and in its second generation as a five-door, five passenger liftback (2009–2014). ... The Insight was the least expensive hybrid available in the US.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 28,
                    VinID = "WVWED7AJ4DW043432",
                    IsFeatured = false,
                    Picture = "inventory-28.jpg",
                    Year = 2014,
                    ModelID = 18,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 50000,
                    SalesPrice = 21000,
                    MSRP = 21450,
                    Description = "Image result for honda pilot description The Pilot shares its platform with the Acura MDX, as well as the Odyssey minivan and the Accord sedan.The Pilot's unibody construction and independent suspension are designed to provide handling similar to that of a car, and it has integrated perimeter frame rails to allow towing and light off-road use.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 29,
                    VinID = "5XYZU3LB3FG248045",
                    IsFeatured = false,
                    Picture = "inventory-29.jpg",
                    Year = 2015,
                    ModelID = 19,
                    BodyStyleID = 3,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 15000,
                    SalesPrice = 25000,
                    MSRP = 25090,
                    Description = "The Odyssey was introduced in 1994 as Honda's first minivan — based on the Accord platform, with a 4-cylinder engine, all-disc anti-lock braking, all wishbone suspension, and a four-speed automatic transmission with a steering-column-mounted shifter and a hill-hold feature, marketed as Grade Logic.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 30,
                    VinID = "4DRBUAFNX7A355425",
                    IsFeatured = false,
                    Picture = "inventory-30.png",
                    Year = 2019,
                    ModelID = 20,
                    BodyStyleID = 4,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 18000,
                    MSRP = 18700,
                    Description = "The 2019 Honda Ridgeline is a distinctive choice for a midsize pickup truck. Rather than going with the crowd and opting for a traditional body-on-frame design, Honda uses a more carlike unibody construction and a fully independent suspension for the Ridgeline.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 31,
                    VinID = "3MEHM0JA5AR654023",
                    IsFeatured = false,
                    Picture = "inventory-31.jpg",
                    Year = 2019,
                    ModelID = 21,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 27700,
                    MSRP = 28000,
                    Description = " The sedan comes with a 1.8-liter four-cylinder engine that makes 132 horsepower in the base model, or 140 horsepower in LE Eco editions. You can match this with either a CVT (a type of automatic transmission) or a six-speed manual. For a little more gusto, go with the Corolla hatchback.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 32,
                    VinID = "5NPEU46F27H283219",
                    IsFeatured = false,
                    Picture = "inventory-32.jpg",
                    Year = 2019,
                    ModelID = 22,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 20500,
                    SalesPrice = 13000,
                    MSRP = 13845,
                    Description = "The Toyota Camry is an excellent car. It offers fuel-efficient, energetic engines; it rides comfortably; and it handles well, making it more fun to drive than many rivals.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 33,
                    VinID = "3N1CN7AP3EL866789",
                    IsFeatured = false,
                    Picture = "inventory-33.jpg",
                    Year = 2019,
                    ModelID = 23,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 35070,
                    SalesPrice = 14000,
                    MSRP = 14660,
                    Description = "The RAV4 has paddle shifters on the steering wheel and a sport-tuned suspension. It comes with synthetic leather seats, power-adjustable heated front seats, a proximity key, push-button start, blind spot monitoring, and rear cross traffic alert.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 34,
                    VinID = "JF1SG67656H754464",
                    IsFeatured = false,
                    Picture = "inventory-34.jpg",
                    Year = 2019,
                    ModelID = 24,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 25420,
                    SalesPrice = 15700,
                    MSRP = 16000,
                    Description = "CHR is a subcompact crossover SUV produced by Toyota. The production version of the C-HR was unveiled at the March 2016 Geneva Motor Show. ... The name C-HR stands for Compact High Rider, Cross Hatch Run–about or Coupé High–Rider.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 35,
                    VinID = "3N1AB7AP4EY329870",
                    IsFeatured = false,
                    Picture = "inventory-35.jpg",
                    Year = 2019,
                    ModelID = 25,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 56000,
                    SalesPrice = 13000,
                    MSRP = 13475,
                    Description = "Prius is a full hybrid electric automobile developed by Toyota and manufactured by the company since 1997. Initially offered as a 4-door sedan, it has been produced only as a 5-door liftback since 2003",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 36,
                    VinID = "3GCUKREC8EG215020",
                    IsFeatured = false,
                    Picture = "inventory-36.jpg",
                    Year = 2010,
                    ModelID = 26,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 1,
                    Mileage = 25000,
                    SalesPrice = 16385,
                    MSRP = 16760,
                    Description = "The Toyota Yaris is a subcompact model introduced in 2007 to the U.S. market. Hatchback and sedan body styles have been offered. The Yaris is a front-wheel drive vehicle powered by a four-cylinder engine.",
                    IsNew = false,
                    InteriorID = 2,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 37,
                    VinID = "JN1CV6AP3DM711531",
                    IsFeatured = false,
                    Picture = "inventory-37.png",
                    Year = 2011,
                    ModelID = 27,
                    BodyStyleID = 2,
                    TransmissionID = 1,
                    ColorID = 1,
                    Mileage = 21250,
                    SalesPrice = 61000,
                    MSRP = 64765,
                    Description = "With an off-road heritage spanning more than 65 years, the Land Cruiser remains unique in its ability to combine outstanding quality, durability and reliability with unrivalled off-road performance and ever greater levels of luxury, prestige, and on-road comfort.",
                    IsNew = false,
                    InteriorID = 2,
                    IsAvailable = false
                },
                new Car
                {
                    CarID = 38,
                    VinID = "KNDJF723X77361479",
                    IsFeatured = false,
                    Picture = "inventory-38.jpg",
                    Year = 2011,
                    ModelID = 28,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 2,
                    Mileage = 18120,
                    SalesPrice = 30000,
                    MSRP = 32765,
                    Description = "The 4Runner isn't the most powerful SUV in the class, but it has no issues getting up a mountain pass, merging onto the highway, or towing up to 5,000 pounds. Its 270-horsepower powertrain consists of a 4.0-liter V6 engine mated to a five-speed automatic transmission.",
                    IsNew = false,
                    InteriorID = 3,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 39,
                    VinID = "1FADP3F21EL157216",
                    IsFeatured = false,
                    Picture = "inventory-39.jpg",
                    Year = 2012,
                    ModelID = 29,
                    BodyStyleID = 4,
                    TransmissionID = 2,
                    ColorID = 2,
                    Mileage = 19522,
                    SalesPrice = 20000,
                    MSRP = 22050,
                    Description = "The 2018 Toyota Tacoma earns a respectable score in the competitive compact pickup truck class. It handles tricky terrain and tough hauling jobs with ease, and it has a strong predicted reliability rating. These traits help distinguish it as one of our class leaders",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 40,
                    VinID = "19XFB2F81DE001281",
                    IsFeatured = false,
                    Picture = "inventory-40.jpg",
                    Year = 2013,
                    ModelID = 30,
                    BodyStyleID = 4,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 23535,
                    SalesPrice = 31000,
                    MSRP = 32050,
                    Description = "The Toyota Highlander is a three-row SUV that competes with the Honda Pilot, Ford Explorer, Hyundai Santa Fe and others. It's available as a hybrid or a traditional gas-powered SUV. The base LE trim comes with a 2.7-liter four-cylinder engine, six-speed automatic transmission and front-wheel drive.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },

                new Car
                {
                    CarID = 41,
                    VinID = "1FT7W2BT5EEA47955",
                    IsFeatured = false,
                    Picture = "inventory-41.jpg",
                    Year = 2019,
                    ModelID = 31,
                    BodyStyleID = 2,
                    TransmissionID = 1,
                    ColorID = 2,
                    Mileage = 0,
                    SalesPrice = 25000,
                    MSRP = 26600,
                    Description = "The 2019 Kia Sportage combines above-average performance with one of the best interiors in the class, earning it a spot in the top third of our compact SUV rankings. Spacious, upscale cabin, Smooth ride, Agile handling, User-friendly infotainment system, Subpar fuel economy.",

                    IsNew = true,
                    InteriorID = 2,
                    IsAvailable = true
                },

                new Car
                {
                    CarID = 42,
                    VinID = "1FVDYDY99HP293165",
                    IsFeatured = false,
                    Picture = "inventory-42.jpg",
                    Year = 2019,
                    ModelID = 32,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 1,
                    Mileage = 0,
                    SalesPrice = 19000,
                    MSRP = 20490,
                    Description = "The 2019 Kia Soul is one of the best compact cars on the market. It features an exceptionally spacious and comfortable cabin, and its build quality is nicer than you'd expect from a vehicle at this price point. The Soul carries one of the lowest price tags in the class while also featuring one of the longest warranties. That said, this Kia gets poor gas mileage, and its base engine is lacking power. However, the available turbocharged engine delivers peppy acceleration.",
                    IsNew = true,
                    InteriorID = 3,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 43,
                    VinID = "4T4BF3EK2BR213662",
                    IsFeatured = false,
                    Picture = "inventory-43.jpg",
                    Year = 2012,
                    ModelID = 33,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 1,
                    Mileage = 20120,
                    SalesPrice = 14000,
                    MSRP = 14500,
                    Description = "The Focus serves as Ford's entry in the compact car class; it's available in sedan and hatchback body styles. Most models come with a 2.0-liter four-cylinder engine, but the SE sedan offers a turbocharged three-cylinder engine.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },

                new Car
                {
                    CarID = 44,
                    VinID = "JHMGE8H60DC019612",
                    IsFeatured = false,
                    Picture = "inventory-44.jpg",
                    Year = 2011,
                    ModelID = 34,
                    BodyStyleID = 1,
                    TransmissionID = 1,
                    ColorID = 2,
                    Mileage = 20120,
                    SalesPrice = 9599,
                    MSRP = 10000,
                    Description = "Though the Fiesta might be small, it is still mighty fierce. An engaging five-speed manual comes standard as does a 1.6-liter four-cylinder engine that makes 120 horsepower; an optional six-speed automatic is almost as fun to drive as the manual. Steering is crisp and well weighted, and although it isn't quick—the last one we tested needed 9.1 seconds to reach 60 mph—the Fiesta is playful in the corners. Driving enthusiasts are encouraged to check out the high-performance Fiesta ST, which we review separately.",
                    IsNew = false,
                    InteriorID = 2,
                    IsAvailable = true
                },

                new Car
                {
                    CarID = 45,
                    VinID = "KMHGC46E79U039668",
                    IsFeatured = false,
                    Picture = "inventory-45.jpg",
                    Year = 2007,
                    ModelID = 11,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 12000,
                    SalesPrice = 11000,
                    MSRP = 11450,
                    Description = "The Civic exemplifies automotive excellence and mixes fun with efficiency and practicality. Offered in sedan, hatchback, and coupe body styles, there's a Civic model for everyone—including enthusiast drivers, although we review the Civic Si and the Civic Type R performance models separately. Precise steering and a well-tuned suspension provide sweet handling; the Sport model earned a 2018 10Best Cars award for its blend of value, utility, and fun-to-drive quality. Each model comes with one of two four-cylinder engines, one of which is a turbo; the standard 2.0-liter four-cylinder makes 158 horsepower, but the sweet turbocharged 1.5-liter is boosted to either 174 or 180 ponies (depending on trim). In our testing, it helped hustle the Civic Touring sedan from zero to 60 mph in just 6.9 seconds. The interior is spacious and well built, but some may find the seats lack support.The Civic's optional 7.0-inch touchscreen infotainment system provides plenty of connectivity features, including Apple CarPlay and Android Auto, but its menus are poorly organized and the absence of physical knobs and buttons means making volume or tuning adjustments while driving is a challenge. Honda provides active-safety technologies such as automated emergency braking, lane-keeping assist, and adaptive cruise control, but none of the features are offered as standard. A freshened Civic sedan and coupe debut for 2019 with a new infotainment setup and more standard active-safety gear. Can't wait for the 2019 ? The current Civic in all of its iterations is still a great car at a fair price. ",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 46,
                    VinID = "5LMFU28595LJ21358",
                    IsFeatured = false,
                    Picture = "inventory-46.jpg",
                    Year = 2007,
                    ModelID = 11,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 12000,
                    SalesPrice = 11000,
                    MSRP = 11450,
                    Description = "The Civic exemplifies automotive excellence and mixes fun with efficiency and practicality. Offered in sedan, hatchback, and coupe body styles, there's a Civic model for everyone—including enthusiast drivers, although we review the Civic Si and the Civic Type R performance models separately. Precise steering and a well-tuned suspension provide sweet handling; the Sport model earned a 2018 10Best Cars award for its blend of value, utility, and fun-to-drive quality. Each model comes with one of two four-cylinder engines, one of which is a turbo; the standard 2.0-liter four-cylinder makes 158 horsepower, but the sweet turbocharged 1.5-liter is boosted to either 174 or 180 ponies (depending on trim). In our testing, it helped hustle the Civic Touring sedan from zero to 60 mph in just 6.9 seconds. The interior is spacious and well built, but some may find the seats lack support.The Civic's optional 7.0-inch touchscreen infotainment system provides plenty of connectivity features, including Apple CarPlay and Android Auto, but its menus are poorly organized and the absence of physical knobs and buttons means making volume or tuning adjustments while driving is a challenge. Honda provides active-safety technologies such as automated emergency braking, lane-keeping assist, and adaptive cruise control, but none of the features are offered as standard. A freshened Civic sedan and coupe debut for 2019 with a new infotainment setup and more standard active-safety gear. Can't wait for the 2019 ? The current Civic in all of its iterations is still a great car at a fair price. ",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 47,
                    VinID = "YV1LW5537W2361471",
                    IsFeatured = false,
                    Picture = "inventory-47.jpg",
                    Year = 2008,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 16000,
                    SalesPrice = 18000,
                    MSRP = 18250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 48,
                    VinID = "1G1RB6E44FU103772",
                    IsFeatured = false,
                    Picture = "inventory-48.jpg",
                    Year = 2008,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 16000,
                    SalesPrice = 18000,
                    MSRP = 18250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 49,
                    VinID = "1C3EL46X76N158859",
                    IsFeatured = false,
                    Picture = "inventory-49.jpg",
                    Year = 2009,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 16000,
                    SalesPrice = 18000,
                    MSRP = 18250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 50,
                    VinID = "1GNFK16367J219875",
                    IsFeatured = false,
                    Picture = "inventory-50.jpg",
                    Year = 2009,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 16000,
                    SalesPrice = 18000,
                    MSRP = 18250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 51,
                    VinID = "JA32U2FU9EU010897",
                    IsFeatured = false,
                    Picture = "inventory-51.jpg",
                    Year = 2009,
                    ModelID = 13,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 17000,
                    SalesPrice = 12000,
                    MSRP = 12190,
                    Description = "Fit Ride and Handling: Playful and Agile. For a subcompact hatchback, the front-wheel-drive Fit is fun to drive, thanks to its precise steering and sharp handling. The suspension does a good job of absorbing bumps (though the ride is a little firm), and added insulation for 2018 means the cabin is now even quieter.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 52,
                    VinID = "1N4AL11E12C271412",
                    IsFeatured = false,
                    Picture = "inventory-52.jpg",
                    Year = 2009,
                    ModelID = 13,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 17000,
                    SalesPrice = 12000,
                    MSRP = 12190,
                    Description = "Fit Ride and Handling: Playful and Agile. For a subcompact hatchback, the front-wheel-drive Fit is fun to drive, thanks to its precise steering and sharp handling. The suspension does a good job of absorbing bumps (though the ride is a little firm), and added insulation for 2018 means the cabin is now even quieter.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 53,
                    VinID = "1XP9DB9X6HD209222",
                    IsFeatured = false,
                    Picture = "inventory-53.jpg",
                    Year = 2009,
                    ModelID = 13,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 17000,
                    SalesPrice = 12000,
                    MSRP = 12190,
                    Description = "Fit Ride and Handling: Playful and Agile. For a subcompact hatchback, the front-wheel-drive Fit is fun to drive, thanks to its precise steering and sharp handling. The suspension does a good job of absorbing bumps (though the ride is a little firm), and added insulation for 2018 means the cabin is now even quieter.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 54,
                    VinID = "1GNDX03E01D106096",
                    IsFeatured = false,
                    Picture = "inventory-54.jpg",
                    Year = 2010,
                    ModelID = 13,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 17000,
                    SalesPrice = 12000,
                    MSRP = 12190,
                    Description = "Fit Ride and Handling: Playful and Agile. For a subcompact hatchback, the front-wheel-drive Fit is fun to drive, thanks to its precise steering and sharp handling. The suspension does a good job of absorbing bumps (though the ride is a little firm), and added insulation for 2018 means the cabin is now even quieter.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 55,
                    VinID = "19UUA8F5XCA015217",
                    IsFeatured = false,
                    Picture = "inventory-55.jpg",
                    Year = 2010,
                    ModelID = 13,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 17000,
                    SalesPrice = 12000,
                    MSRP = 12190,
                    Description = "Fit Ride and Handling: Playful and Agile. For a subcompact hatchback, the front-wheel-drive Fit is fun to drive, thanks to its precise steering and sharp handling. The suspension does a good job of absorbing bumps (though the ride is a little firm), and added insulation for 2018 means the cabin is now even quieter.",
                    IsNew = false,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 56,
                    VinID = "2C4RDGEG1ER385785",
                    IsFeatured = false,
                    Picture = "inventory-56.jpg",
                    Year = 2019,
                    ModelID = 15,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 27700,
                    MSRP = 28000,
                    Description = "Turbo engines are both powerful and fuel-efficient.Interior is cavernous and fitted with upscale materials Sporty handling makes it fun to drive.Many advanced driver safety aids come standard",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 57,
                    VinID = "JTDBU4EE2AJ087775",
                    IsFeatured = false,
                    Picture = "inventory-57.jpg",
                    Year = 2019,
                    ModelID = 15,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 27700,
                    MSRP = 28000,
                    Description = "Turbo engines are both powerful and fuel-efficient.Interior is cavernous and fitted with upscale materials Sporty handling makes it fun to drive.Many advanced driver safety aids come standard",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 58,
                    VinID = "5TDBK3EH5DS249609",
                    IsFeatured = false,
                    Picture = "inventory-58.jpg",
                    Year = 2019,
                    ModelID = 15,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 27700,
                    MSRP = 28000,
                    Description = "Turbo engines are both powerful and fuel-efficient.Interior is cavernous and fitted with upscale materials Sporty handling makes it fun to drive.Many advanced driver safety aids come standard",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 59,
                    VinID = "1N4CL21E98C121202",
                    IsFeatured = false,
                    Picture = "inventory-59.jpg",
                    Year = 2019,
                    ModelID = 11,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 19000,
                    MSRP = 19450,
                    Description = "The Civic exemplifies automotive excellence and mixes fun with efficiency and practicality. Offered in sedan, hatchback, and coupe body styles, there's a Civic model for everyone—including enthusiast drivers, although we review the Civic Si and the Civic Type R performance models separately. Precise steering and a well-tuned suspension provide sweet handling; the Sport model earned a 2018 10Best Cars award for its blend of value, utility, and fun-to-drive quality. Each model comes with one of two four-cylinder engines, one of which is a turbo; the standard 2.0-liter four-cylinder makes 158 horsepower, but the sweet turbocharged 1.5-liter is boosted to either 174 or 180 ponies (depending on trim). In our testing, it helped hustle the Civic Touring sedan from zero to 60 mph in just 6.9 seconds. The interior is spacious and well built, but some may find the seats lack support.The Civic's optional 7.0-inch touchscreen infotainment system provides plenty of connectivity features, including Apple CarPlay and Android Auto, but its menus are poorly organized and the absence of physical knobs and buttons means making volume or tuning adjustments while driving is a challenge. Honda provides active-safety technologies such as automated emergency braking, lane-keeping assist, and adaptive cruise control, but none of the features are offered as standard. A freshened Civic sedan and coupe debut for 2019 with a new infotainment setup and more standard active-safety gear. Can't wait for the 2019 ? The current Civic in all of its iterations is still a great car at a fair price. ",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 60,
                    VinID = "1J8GR48K47C503646",
                    IsFeatured = false,
                    Picture = "inventory-60.jpg",
                    Year = 2019,
                    ModelID = 11,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 19000,
                    MSRP = 19450,
                    Description = "The Civic exemplifies automotive excellence and mixes fun with efficiency and practicality. Offered in sedan, hatchback, and coupe body styles, there's a Civic model for everyone—including enthusiast drivers, although we review the Civic Si and the Civic Type R performance models separately. Precise steering and a well-tuned suspension provide sweet handling; the Sport model earned a 2018 10Best Cars award for its blend of value, utility, and fun-to-drive quality. Each model comes with one of two four-cylinder engines, one of which is a turbo; the standard 2.0-liter four-cylinder makes 158 horsepower, but the sweet turbocharged 1.5-liter is boosted to either 174 or 180 ponies (depending on trim). In our testing, it helped hustle the Civic Touring sedan from zero to 60 mph in just 6.9 seconds. The interior is spacious and well built, but some may find the seats lack support.The Civic's optional 7.0-inch touchscreen infotainment system provides plenty of connectivity features, including Apple CarPlay and Android Auto, but its menus are poorly organized and the absence of physical knobs and buttons means making volume or tuning adjustments while driving is a challenge. Honda provides active-safety technologies such as automated emergency braking, lane-keeping assist, and adaptive cruise control, but none of the features are offered as standard. A freshened Civic sedan and coupe debut for 2019 with a new infotainment setup and more standard active-safety gear. Can't wait for the 2019 ? The current Civic in all of its iterations is still a great car at a fair price. ",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 61,
                    VinID = "1GTEK19R9WR502551",
                    IsFeatured = false,
                    Picture = "inventory-61.jpg",
                    Year = 2019,
                    ModelID = 11,
                    BodyStyleID = 1,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 19000,
                    MSRP = 19450,
                    Description = "The Civic exemplifies automotive excellence and mixes fun with efficiency and practicality. Offered in sedan, hatchback, and coupe body styles, there's a Civic model for everyone—including enthusiast drivers, although we review the Civic Si and the Civic Type R performance models separately. Precise steering and a well-tuned suspension provide sweet handling; the Sport model earned a 2018 10Best Cars award for its blend of value, utility, and fun-to-drive quality. Each model comes with one of two four-cylinder engines, one of which is a turbo; the standard 2.0-liter four-cylinder makes 158 horsepower, but the sweet turbocharged 1.5-liter is boosted to either 174 or 180 ponies (depending on trim). In our testing, it helped hustle the Civic Touring sedan from zero to 60 mph in just 6.9 seconds. The interior is spacious and well built, but some may find the seats lack support.The Civic's optional 7.0-inch touchscreen infotainment system provides plenty of connectivity features, including Apple CarPlay and Android Auto, but its menus are poorly organized and the absence of physical knobs and buttons means making volume or tuning adjustments while driving is a challenge. Honda provides active-safety technologies such as automated emergency braking, lane-keeping assist, and adaptive cruise control, but none of the features are offered as standard. A freshened Civic sedan and coupe debut for 2019 with a new infotainment setup and more standard active-safety gear. Can't wait for the 2019 ? The current Civic in all of its iterations is still a great car at a fair price. ",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 62,
                    VinID = "JTHCK262692032026",
                    IsFeatured = false,
                    Picture = "inventory-62.jpg",
                    Year = 2019,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 24000,
                    MSRP = 24250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 63,
                    VinID = "1G4HP54K544106221",
                    IsFeatured = false,
                    Picture = "inventory-63.jpg",
                    Year = 2019,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 24000,
                    MSRP = 24250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 64,
                    VinID = "2J4FY29TXLJ555651",

                    IsFeatured = false,
                    Picture = "inventory-64.jpg",
                    Year = 2019,
                    ModelID = 12,
                    BodyStyleID = 2,
                    TransmissionID = 2,
                    ColorID = 5,
                    Mileage = 0,
                    SalesPrice = 24000,
                    MSRP = 24250,
                    Description = "The five-seat CR-V is Honda’s popular entry in the thriving compact SUV segment. It was redesigned last year with larger dimensions and updated styling. Base LX versions use a 2.4-liter four-cylinder engine, while other trim levels have a turbocharged 1.5-liter four-cylinder. All models come with a continuously variable automatic transmission and a choice of front- or all-wheel drive.",
                    IsNew = true,
                    InteriorID = 1,
                    IsAvailable = true
                }
            };

        private static List<Sale> _sales = new List<Sale> {
                new Sale
                {
                    SaleID = 1,
                    CustomerName = "Neil Armstrong",
                    Email = "narmstrong@gmail.com",
                    Street1 = "1 Columbia Ave",
                    Street2 = "",
                    City = "Oceanside",
                    StateID = 5,
                    Zip = "92056",
                    PurchasePrice = 27700,
                    SalesPerson = "sales@softwareguild.com",
                    PurchaseTypeID = 1,
                    PurchaseDate = new DateTime(2018, 11, 14),
                    Phone = "4561234567",
                    VinID = "JN8AZ2NE1F9081562"
                },
                new Sale
                {
                    SaleID = 2,
                    CustomerName = "Buzz Aldrin",
                    Email = "baldrin@gmail.com",
                    Street1 = "2200 Tamarack",
                    Street2 = "Unit 200",
                    City = "Carlsbad",
                    StateID = 5,
                    Zip = "92008",
                    PurchasePrice = 67000,
                    PurchaseTypeID = 1,
                    SalesPerson = "sales@softwareguild.com",
                    PurchaseDate = new DateTime(2018, 11, 14),
                    Phone = "1234569877",
                    VinID = "WVGBV7AX7DW519950"
                },
                new Sale
                {
                    SaleID = 3,
                    CustomerName = "John Glenn",
                    Email = "jglenn@gmail.com",
                    Street1 = "1250 Acacia Ave",
                    Street2 = "",
                    City = "Carlsbad",
                    StateID = 5,
                    Zip = "92008",
                    PurchasePrice = 40000,
                    PurchaseTypeID = 3,
                    SalesPerson = "sales@softwareguild.com",
                    PurchaseDate = new DateTime(2018, 11, 14),
                    Phone = "9201234568",
                    VinID = "1FTRF12255NB94299"
                },
                new Sale
                {
                    SaleID = 4,
                    CustomerName = "Yuri Gagarin",
                    Email = "yurig@gmail.com",
                    Street1 = "1500 Delaware Ct",
                    Street2 = "",
                    City = "Denver",
                    StateID = 6,
                    Zip = "89056",
                    PurchasePrice = 30000,
                    PurchaseTypeID = 2,
                    SalesPerson = "sales@softwareguild.com",
                    PurchaseDate = new DateTime(2018, 11, 14),
                    Phone = "2582362583",
                    VinID = "1HD1FC41X8Y680850"
                }
        };

        public void AddCar(CarToAdd car)
        {

            var lastCarID = _cars
                .OrderByDescending(x => x.CarID)
                .Select(x => x.CarID)
                .FirstOrDefault();

            var newCar = new Car()
            {
                VinID = car.VinID,
                IsFeatured = car.IsFeatured,
                Picture = car.Picture,
                Year = car.Year,
                Models = new Model
                {
                    Makes = new Make
                    {
                        MakeID = car.MakeID
                    }
                },
                ModelID = car.ModelID,
                BodyStyleID = car.BodyStyleID,
                TransmissionID = car.TransmissionID,
                ColorID = car.ColorID,
                Mileage = car.Mileage,
                SalesPrice = car.SalesPrice,
                MSRP = car.MSRP,
                Description = car.Description,
                IsNew = car.IsNew,
                IsAvailable = true,
                InteriorID = car.InteriorID,
                CarID = lastCarID + 1
            };

            _cars.Add(newCar);

        }

        public void AddContact(ContactMessage contact)
        {
            var lastContactID = _contactMessages
                .OrderByDescending(x => x.ContactMessageID)
                .Select(x => x.ContactMessageID)
                .LastOrDefault();

            contact.ContactMessageID = lastContactID + 1;

            _contactMessages.Add(contact);
        }

        public void AddMake(Make make)
        {
            var lastMakeID = _makes
                  .OrderByDescending(x => x.MakeID)
                  .Select(x => x.MakeID)
                  .FirstOrDefault();

            make.MakeID = lastMakeID + 1;
            make.DateAdded = DateTime.Now;
            _makes.Add(make);
        }

        public void AddModel(Model model)
        {
            var lastModelID = _models
                .OrderByDescending(x => x.ModelID)
                .Select(x => x.ModelID)
                .LastOrDefault();

            model.ModelID = lastModelID + 1;
            model.DateAdded = DateTime.Now;

            _models.Add(model);
        }

        public void AddSale(Sale sale)
        {
            var purchasedCar = GetCarByID(sale.CarID);
            purchasedCar.IsAvailable = false;

            var lastSaleID = _sales
                .OrderByDescending(x => x.SaleID)
                .Select(x => x.SaleID)
                .LastOrDefault();

            sale.SaleID = lastSaleID + 1;
            _sales.Add(sale);
        }

        public void AddSpecial(Specials special)
        {
            var lastSaleID = _specials
                .OrderByDescending(x => x.SpecialsID)
                .Select(x => x.SpecialsID)
                .LastOrDefault();
            special.SpecialsID = lastSaleID + 1;

            _specials.Add(special);
        }

        public void DeleteCar(int id)
        {
           // var car = GetCarByID(id);
            var index = _cars.FindIndex(x => x.CarID == id);
            _cars.RemoveAt(index);
        }

        public void DeleteSpecial(int id)
        {
            var special = GetSpecialByID(id);
            _specials.Remove(special);
        }

        public List<BodyStyle> GetBodyStyles()
        {
            var bodyStyles = new List<BodyStyle>();
            var query = _bodystyles
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


        public Car GetCarByID(int id)
        {
            var queryCar = _cars.FirstOrDefault(q => q.CarID == id);
            if (queryCar == null) {
                Car x = null;
                return x;
            }
            var car = new Car()
            {
                CarID = queryCar.CarID,
                VinID = queryCar.VinID,
                IsFeatured = queryCar.IsFeatured,
                Picture = queryCar.Picture,
                Year = queryCar.Year,
                TransmissionID = queryCar.TransmissionID,
                ColorID = queryCar.ColorID,
                Mileage = queryCar.Mileage,
                SalesPrice = queryCar.SalesPrice,
                MSRP = queryCar.MSRP,
                Description = queryCar.Description,
                IsNew = queryCar.IsNew,
                IsAvailable = queryCar.IsAvailable,
                InteriorID = queryCar.InteriorID,
                ModelID = queryCar.ModelID,
                BodyStyleID = queryCar.BodyStyleID,
            };

            var queryBodyStyle = _bodystyles.FirstOrDefault(q => q.BodyStyleID == queryCar.BodyStyleID);
            car.BodyStyles = new BodyStyle { BodyStyleName = queryBodyStyle.BodyStyleName };

            var queryModels = _models.FirstOrDefault(q => q.ModelID == queryCar.ModelID);


            var queryMakes = _makes.FirstOrDefault(q => q.MakeID == queryModels.MakeID);

            car.Models = new Model { ModelName = queryModels.ModelName, MakeID = queryMakes.MakeID, ModelID = queryModels.ModelID };
            car.Models.Makes = new Make { MakeName = queryMakes.MakeName, MakeID = queryMakes.MakeID };

            var queryTransmissions = _transmissions
               .FirstOrDefault(q => q.TransmissionID == queryCar.TransmissionID);

            car.Transmissions = new Transmission { TransmissionType = queryTransmissions.TransmissionType };


            var queryColors = _colors
               .FirstOrDefault(q => q.ColorID == queryCar.ColorID);

            car.Colors = new Color { ColorName = queryColors.ColorName };

            var queryInteriors = _interiors
               .FirstOrDefault(q => q.InteriorID == queryCar.InteriorID);


            car.Interiors = new Interior { InteriorColor = queryInteriors.InteriorColor };


            return car;
        }

        public int GetCarIDByVIN(string vin)
        {
            var query = _cars
                .Where(q => q.VinID == vin)
                .Select(q => new
                {
                    q.CarID
                }).FirstOrDefault();

            var id = query.CarID;
            return id;
        }

        public Make GetCarMakeByID(int makeID)
        {
            var query = _makes
                   .Where(m => m.MakeID == makeID)
                   .Select(q => new { q.DateAdded, q.MakeName }).FirstOrDefault();

            var make = new Make()
            {
                DateAdded = query.DateAdded,
                MakeName = query.MakeName

            };

            return make;
        }

        public List<Make> GetCarMakes()
        {
            var makes = new List<Make>();

            var query = (from make in _makes
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

        public Model GetCarModelByID(int modelID)
        {
            var query = _models
                    .Where(m => m.ModelID == modelID)
                    .Select(q => new { q.DateAdded, q.ModelName }).FirstOrDefault();

            var model = new Model()
            {
                DateAdded = query.DateAdded,
                ModelName = query.ModelName
            };

            return model;
        }

        public List<Model> GetCarModels()
        {
            var models = new List<Model>();

            var query = (from model in _models
                         join make in _makes
                        on model.MakeID equals make.MakeID

                         orderby model.ModelName ascending
                         select new
                         {
                             makeName = make.MakeName,
                             model.ModelName,
                             model.ModelID,
                             model.DateAdded,
                             model.UserID,
                             makeID = model.MakeID
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

        public List<Model> GetCarModels(int makeID)
        {
            var models = new List<Model>();
            var query = (from model in _models
                         join make in _makes
                      on model.MakeID equals make.MakeID
                         where model.MakeID == makeID
                         orderby model.ModelName ascending
                         select new
                         {
                             model.MakeID,
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


            var query = (from x in _cars
                         where x.IsAvailable == true
                         orderby x.MSRP
                         select new
                         {
                             x.VinID,
                             x.IsFeatured,
                             x.Picture,
                             x.Year,
                             x.TransmissionID,
                             x.ColorID,
                             x.Mileage,
                             x.SalesPrice,
                             x.MSRP,
                             x.IsNew,
                             x.InteriorID,
                             x.ModelID,
                             x.BodyStyleID,
                             x.CarID,
                             x.IsAvailable
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



            var unfilteredList = query.ToList();

            
           
                foreach (var q in unfilteredList)
                {

                    var car = new Car()
                    {
                        VinID = q.VinID,
                        IsFeatured = q.IsFeatured,
                        Picture = q.Picture,
                        Year = q.Year,
                        TransmissionID = q.TransmissionID,

                        ColorID = q.ColorID,

                        Mileage = q.Mileage,
                        SalesPrice = q.SalesPrice,
                        MSRP = q.MSRP,
                        IsNew = q.IsNew,
                        InteriorID = q.InteriorID,

                        CarID = q.CarID,
                        IsAvailable = q.IsAvailable,
                        ModelID = q.ModelID,

                        BodyStyleID = q.BodyStyleID

                    };
                    var queryModels = _models.FirstOrDefault(x => x.ModelID == q.ModelID);
                    car.Models = new Model { ModelName = queryModels.ModelName };

                    var queryTransmissions = _transmissions.FirstOrDefault(x => x.TransmissionID == car.TransmissionID);
                    car.Transmissions = new Transmission { TransmissionType = queryTransmissions.TransmissionType };

                    var queryColors = _colors.FirstOrDefault(x => x.ColorID == car.ColorID);
                    car.Colors = new Color { ColorName = queryColors.ColorName };

                    var queryInteriors = _interiors.FirstOrDefault(x => x.InteriorID == car.InteriorID);
                    car.Interiors = new Interior { InteriorColor = queryInteriors.InteriorColor };

                    var queryBodyStyles = _bodystyles.FirstOrDefault(x => x.BodyStyleID == car.BodyStyleID);
                    car.BodyStyles = new BodyStyle { BodyStyleName = queryBodyStyles.BodyStyleName };


                    var queryMakes = _makes.FirstOrDefault(y => y.MakeID == queryModels.MakeID);
                    car.Models.Makes = new Make { MakeName = queryMakes.MakeName };


                if (cars.Count < 20)
                {
                    if (String.IsNullOrEmpty(search))
                    {
                        cars.Add(car);
                    }

                    else
                    {
                        foreach (var word in stringSearchList)
                        {
                            int number;
                            var isNum = int.TryParse(word, out number);


                            if (car.Models.ModelName.ToUpper().Contains(word) || car.Models.Makes.MakeName.ToUpper().Contains(word) || car.Year == number)
                                cars.Add(car);
                        }


                    }

                }


            } 
            return cars;
        }

      
        public List<Color> GetColors()
        {
            var colors = new List<Color>();


            var query = _colors
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

        public List<Car> GetFeaturedCars()
        {
            var cars = new List<Car>();

            var queryCar = (from c in _cars
                            where c.IsFeatured.Equals(true)
                            select new
                            {
                                c.CarID,
                                c.IsFeatured,
                                c.Picture,
                                c.Year,
                                c.SalesPrice,
                                c.ModelID,
                            }).Take(20).ToList();


            foreach (var q in queryCar)
            {
                var car = new Car()
                {
                    CarID = q.CarID,
                    IsFeatured = q.IsFeatured,
                    Picture = q.Picture,
                    Year = q.Year,

                    SalesPrice = q.SalesPrice,

                    ModelID = q.ModelID

                };

                var queryModels = _models.FirstOrDefault(x => x.ModelID == car.ModelID);
                car.Models = new Model { ModelName = queryModels.ModelName };

                var queryMakes = _makes.FirstOrDefault(y => y.MakeID == queryModels.MakeID);
                car.Models.Makes = new Make { MakeName = queryMakes.MakeName };

                cars.Add(car);
            }
            return cars;
        }

        public List<Interior> GetInteriorColors()
        {
            var interiors = new List<Interior>();
            var query = _interiors
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

        public List<InventoryReport> GetInventoryReport(bool isNew)
        {
            var query = (from cars in _cars
                         join model in _models
                            on cars.ModelID equals model.ModelID
                         join make in _makes
                            on model.MakeID equals make.MakeID
                         where cars.IsNew == isNew
                         where cars.IsAvailable == true
                         group cars by new { cars.Year, make.MakeName, model.ModelName } into grp
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

        public int GetLastCarID()
        {
            var query = _cars
                  .OrderByDescending(q => q.CarID)
                  .Select(q => new { q.CarID }).FirstOrDefault();
            return query.CarID;
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            var purchaseTypes = new List<PurchaseType>();


            var query = _purchaseTypes
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

            return purchaseTypes;
        }

        public List<string> GetSalesPeople()
        {
            var names = new List<string>();

            var query = _sales
                .Select(q => new { q.SalesPerson }).Distinct().ToList();

            foreach (var x in query)
            {
                names.Add(x.SalesPerson);
            }
            return names;
        }

        public List<SalesReport> GetSalesReport(string person, DateTime? minDate, DateTime? maxDate)
        {
           // var report = new List<SalesReport>();

            string email;
            string name;

            //if (!String.IsNullOrEmpty(person)) {

            //    var index = person.IndexOf(" ");
            //    email = person.Substring(0, index);
            //    name = person.Substring(index + 1);
            //}


            var query = from sale in _sales
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
            //ID is email
            //needs name
            //foreach (var item in x) {
            //    if (item.SalesPersonID.Contains(person)) {
            //        report.Add(item);

            //    }

            //}
            
            return report;
        }

        public Specials GetSpecialByID(int id)
        {
            var query = _specials
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

        public List<Specials> GetSpecials()
        {
            var specials = new List<Specials>();

            var query = (from s in _specials
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

        public List<Specials> GetSpecialsWithoutID()
        {
            var specials = new List<Specials>();

            var query = (from s in _specials
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

        public List<State> GetState()
        {
            var states = new List<State>();

            var query = _states
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
        }

        public State GetState(int id)
        {

            var query = _states
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
        }

        public List<Transmission> GetTransmissions()
        {
            var transmissions = new List<Transmission>();


            var query = _transmissions
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

        public void UpdateCar(Car car, int id)
        {
            var carToUpdate = GetCarByID(id);

            var index = _cars.FindIndex(x => x.CarID == id);
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

            _cars[index] = carToUpdate;
        }

        public bool VinExists(string ID)
        {
            var query = _cars
                  .Where(q => q.VinID == ID)
                  .Select(q => new
                  {
                      q.VinID
                  }).ToList();

            if (query.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}