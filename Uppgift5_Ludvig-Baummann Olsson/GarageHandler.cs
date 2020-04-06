using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    public class GarageHandler : IHandler
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
           return DoesRegistrationNumberExist(vehicle.RegNo) ? false : garage.AddVehicle(vehicle);
        }

        public bool RemoveVehicle(string input)
        {
            var temp = FindVehicleRegNo(input);
            
            return garage.RemoveVehicle(temp != null ? temp.RegNo : "") ;
        }

        public bool DoesRegistrationNumberExist(string input)
        {        
            Vehicle temp = FindVehicleRegNo(input);
            return temp != null ? true : false;  
        } 

        public Vehicle FindVehicleRegNo(string input)
        {
            // var v = vehicles.Where(v => v.Color == "Red").Select(v => v.Wheels).Count()
            //var b = garage.Where(v => v.GetType().GetProperty("Color").ToString()=="Blue").ToList();
            return garage.FirstOrDefault(v=> v.RegNo == input.ToUpper());       
        }

        public List<Vehicle> FindVehicles(string property, string value)
        {
            var retList = new List<Vehicle>();
            property = property.ToLower();
            value = value.ToLower();
            foreach (var (vehicle, item) in garage.SelectMany(vehicle => vehicle.GetType().GetProperties()
            .Where(item => item.Name.ToLower() == property).Select(item => (vehicle, item))))
            {
                var type = item.PropertyType;
                if (type.Name == "String")
                {
                    if ((item.GetValue(vehicle) as string).ToLower() == value)
                    {
                        retList.Add(vehicle);
                    }
                }
                else if (type.Name == "Int32")
                {
                    int i;
                    if (int.TryParse(value, out i))
                    {
                        if ((int)item.GetValue(vehicle) == i)
                        {
                            retList.Add(vehicle);
                        }
                    }
                }
            }

            return retList;
        }

        public string CountVehicles()
        {
            StringBuilder retString = new StringBuilder();
            retString.Append("Vehicle Counts-> ");

            var vehicleGroups = garage.GroupBy(v => v.GetType().Name).Select(v => new 
            {
                TypeName = v.Key,
                Count = v.Count()
            });

            foreach (var item in vehicleGroups)
            {
                retString.Append($"{item.TypeName}: {item.Count}| ");
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

        private string BuildVehicleInfo(List<Vehicle> vehicles)
        {
            StringBuilder retString = new StringBuilder();
        
            foreach (var item in vehicles)
            {
                retString.Append(item + "\n");
            }
         
            return retString.ToString();
        }

        private List<Vehicle> TypeSorter(string input)
        {
            var retList = new List<Vehicle>();

            if (input.ToLower() == "all") 
            {
                retList = garage.ToList();
            }
            else
            {
                input = input.First().ToString().ToUpper() + input.Substring(1).ToLower();
                retList = garage.Where(v => v.GetType().Name == input).ToList();
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
