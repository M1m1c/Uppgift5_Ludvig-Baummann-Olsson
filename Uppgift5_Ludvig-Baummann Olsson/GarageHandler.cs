using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public bool DoesRegistrationNumberExist(string input)
        {
            return garage.DoesRegistrationNumberExist(input);
        } 
        public Vehicle FindVehicle(string input)
        {
            return garage.FindVehicle(input);
        }

        public string CountVehicles()
        {
            VehicleCount[] vehicleCounts = new VehicleCount[] {
                new VehicleCount("All",0),
                new VehicleCount("Airplane",0),
                new VehicleCount("Motorcycle",0),
                new VehicleCount("Car",0),
                new VehicleCount("Bus",0),
                new VehicleCount("Boat",0)};

            StringBuilder retString = new StringBuilder();
            retString.Append("Vehicle Counts-> ");
            foreach (var item in vehicleCounts)
            {
                item.Amount = TypeSorter(item.TypeName).Count;
                retString.Append($"{item.TypeName}: {item.Amount}| ");
            }
            return retString.ToString();
        }
       
        public string GetVehicleInfos(string input)
        {
            string retString = "";

            List<Vehicle> vehicles = TypeSorter(input);
            retString = BuildVehicleInfo(vehicles);

            retString = string.IsNullOrEmpty(retString) ? "Could not find any vehicles mathcing that type" : retString;

            return retString;
        }

        public string BuildVehicleInfo(List<Vehicle> vehicles)
        {
            StringBuilder retString = new StringBuilder();

            foreach (var item in from item in vehicles
                                 where item != null
                                 select item)
            {
                retString.Append(item + "\n");
            }

            return retString.ToString();
        }

        public List<Vehicle> TypeSorter(string input)
        {
            var retList = new List<Vehicle>();
            switch (input.ToLower())
            {
                case "airplane":
                    retList = garage.GetVehiclesOfType<Airplane>();
                    break;
                case "motorcycle":
                    retList = garage.GetVehiclesOfType<Motorcycle>();
                    break;
                case "car":
                    retList = garage.GetVehiclesOfType<Car>();
                    break;
                case "bus":
                    retList = garage.GetVehiclesOfType<Bus>();
                    break;
                case "boat":
                    retList = garage.GetVehiclesOfType<Boat>();
                    break;
                case "all":
                    retList = garage.GetVehiclesOfType<Vehicle>();
                    break;
            }
            return retList;
        }
     
        public void FillGarage()
        {
            garage.FillGarage();
        }
    }
}
