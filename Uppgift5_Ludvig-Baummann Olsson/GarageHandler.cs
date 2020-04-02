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
            return DoesRegistrationNumberExist(vehicle.RegistrationNumber) ? false : garage.AddVehicle(vehicle);
        }

        public bool RemoveVehicle(string input)
        {
            var temp = FindVehicle(input);
            
            return garage.RemoveVehicle(temp != null ? temp.RegistrationNumber : "") ;
        }

        public bool DoesRegistrationNumberExist(string input)
        {        
            Vehicle temp = FindVehicle(input);
            return temp != null ? true : false;  
        } 

        public Vehicle FindVehicle(string input)
        {
            var temp = from v in garage where v.RegistrationNumber == input.ToUpper() select v;
            var g = temp.ToList();           
            return g.Count > 0 ? g.FirstOrDefault() : null;
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

            if (vehicles != null)
            {
                retString = BuildVehicleInfo(vehicles);
            }
            

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
                    retList = garage.Where( v => v is Airplane).ToList();
                    break;
                case "motorcycle":
                    retList = garage.Where(v => v is Motorcycle).ToList();
                    break;
                case "car":
                    retList = garage.Where(v => v is Car).ToList();
                    break;
                case "bus":
                    retList = garage.Where(v => v is Bus).ToList();
                    break;
                case "boat":
                    retList = garage.Where(v => v is Boat).ToList();
                    break;
                case "all":
                    retList = garage.Where( v => v is Vehicle).ToList();
                    break;
            }
            return retList;
        }
     
        public void FillGarage()
        {         
            AddVehicle(new Car("ABC123", "Blue", 4, "Disel"));
            AddVehicle(new Airplane("DEF456", "Blue", 6, 4));
            AddVehicle(new Boat("GHJ789", "Blue", 0, 8.5));
            AddVehicle(new Bus("KLM321", "Blue", 6, 20));        
        }
    }
}
