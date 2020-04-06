using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Uppgift5Test
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void AddVehicleTest()
        {
            var garage = new Uppgift5_Ludvig_Baummann_Olsson.Garage<Uppgift5_Ludvig_Baummann_Olsson.Vehicle>(2);
            Assert.IsTrue(garage.AddVehicle(new Uppgift5_Ludvig_Baummann_Olsson.Vehicle("ABC123", "Red", 4)));
            Assert.IsTrue(garage.Count() > 0 && garage.Count() < 2);        
        }

        [TestMethod]
        public void RemoveVehicleTest()
        {
            var garage = new Uppgift5_Ludvig_Baummann_Olsson.Garage<Uppgift5_Ludvig_Baummann_Olsson.Vehicle>(2);
            garage.AddVehicle(new Uppgift5_Ludvig_Baummann_Olsson.Vehicle("ABC123", "Red", 4));
            Assert.IsTrue(garage.RemoveVehicle("ABC123"));
            Assert.IsTrue(garage.Count() == 0);
        }

        [TestMethod]
        public void CreateGarageTest()
        {
            var garageHandler = new Uppgift5_Ludvig_Baummann_Olsson.GarageHandler();
            garageHandler.CreateGarage(1);
            Assert.IsTrue(garageHandler.HasGarage());
        }

        [TestMethod]
        public void FindVehicleTest()
        {
            var garageHandler = new Uppgift5_Ludvig_Baummann_Olsson.GarageHandler();
            garageHandler.CreateGarage(1);
            Assert.IsTrue(garageHandler.AddVehicle(new Uppgift5_Ludvig_Baummann_Olsson.Vehicle("ABC123", "Red", 4)));
            Assert.IsNotNull(garageHandler.FindVehicle("ABC123"));
        }

        [TestMethod]
        public void DoesRegistrationNumberExistTest()
        {
            var garageHandler = new Uppgift5_Ludvig_Baummann_Olsson.GarageHandler();
            garageHandler.CreateGarage(1);
            Assert.IsTrue(garageHandler.AddVehicle(new Uppgift5_Ludvig_Baummann_Olsson.Vehicle("ABC123", "Red", 4)));
            Assert.IsTrue(garageHandler.DoesRegistrationNumberExist("ABC123"));
        }

        [TestMethod]
        public void FillGarageTest()
        {
            var garageHandler = new Uppgift5_Ludvig_Baummann_Olsson.GarageHandler();
            garageHandler.CreateGarage(4);
            garageHandler.FillGarage();
            Assert.IsNotNull(garageHandler.FindVehicle("ABC123"));
            Assert.IsNotNull(garageHandler.FindVehicle("DEF456"));
            Assert.IsNotNull(garageHandler.FindVehicle("GHJ789"));
            Assert.IsNotNull(garageHandler.FindVehicle("KLM321"));
        }

        [TestMethod]
        public void CountVehiclesTest()
        {
            var garageHandler = new Uppgift5_Ludvig_Baummann_Olsson.GarageHandler();
            garageHandler.CreateGarage(4);
            garageHandler.FillGarage();
            Assert.AreEqual(garageHandler.CountVehicles(), "Vehicle Counts-> Car: 1| Airplane: 1| Boat: 1| Bus: 1| ");
        }

        [TestMethod]
        public void GetVehicleInfosTest()
        {
            var garageHandler = new Uppgift5_Ludvig_Baummann_Olsson.GarageHandler();
            garageHandler.CreateGarage(1);
            garageHandler.FillGarage();
            Assert.AreEqual(garageHandler.GetVehicleInfos("All"), "Car-> Lisence Plate: ABC123| Color: Blue| Wheels: 4| Fuel Type: Disel|\n");
        }


    }
}
