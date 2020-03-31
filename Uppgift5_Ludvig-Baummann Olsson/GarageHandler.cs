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
            string retString="Could not find any vehicles mathcing that type";
            switch (input.ToLower())
            {
                case "airplane":
                    retString=garage.GetVehicleInfos<Airplane>();
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
            return retString;
        }

    }
}
