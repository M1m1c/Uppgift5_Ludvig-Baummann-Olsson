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
    }
}
