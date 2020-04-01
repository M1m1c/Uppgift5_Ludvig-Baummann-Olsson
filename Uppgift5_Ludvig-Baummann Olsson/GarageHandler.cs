using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    class GarageHandler
    {
        private Garage<Vehicle> garage;
        public void CreateGarage(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }
        public bool HasGarage()
        {
            return garage != null ? true : false;
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            return garage.AddVehicle(vehicle);
        }

        public bool RemoveVehicle(string input)
        {        
            return garage.RemoveVehicle(input);
        }

        public string GetVehicleInfos(string input)
        {
            string retString="";
            switch (input.ToLower())
            {
                case "airplane":
                    retString = garage.GetVehicleInfos<Airplane>();
                    break;
                case "motorcycle":
                    retString = garage.GetVehicleInfos<Motorcycle>();
                    break;
                case "car":
                    retString = garage.GetVehicleInfos<Car>();
                    break;
                case "bus":
                    retString = garage.GetVehicleInfos<Bus>();
                    break;
                case "boat":
                    retString = garage.GetVehicleInfos<Boat>();
                    break;
                case "all":
                    retString = garage.GetVehicleInfos<Vehicle>();
                    break;
            }

            retString = string.IsNullOrEmpty(retString) ? "Could not find any vehicles mathcing that type" : retString;
            
            return retString;
        }

        public string GetVehicleAmounts()
        {
            return garage.CountVehicles();
        }

        public void FillGarage()
        {
            garage.AddVehicle(new Car("ABC123", "Blue", 4, "Disel"));
            garage.AddVehicle(new Airplane("DEF456", "Blue", 6, 4));
            garage.AddVehicle(new Boat("GHJ789", "Blue", 0, 8.5));
            garage.AddVehicle(new Bus("KLM321", "Blue", 6, 20));
        }

    }
}
