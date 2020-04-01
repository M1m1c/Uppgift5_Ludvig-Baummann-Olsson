using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private Vehicle[] vehicles;

        public Garage(int capacity)
        {
            vehicles = new Vehicle[capacity];
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       

        //TODO Check so that registration number does not match any exisitng registration number.
        public bool AddVehicle(Vehicle vehicle)
        {
            bool retFlag = false;
            int index = Array.FindIndex(vehicles, q => q == null);
            if (index < vehicles.Length && index != -1) 
            {
                retFlag = true;
                vehicles[index] = vehicle;
            }
            return retFlag;
        }

        public bool RemoveVehicle(string input)
        {
            bool retFlag = false;
            Vehicle temp = FindVehicle(input);
            if (temp != null)
            {
                retFlag = true;
                vehicles[Array.FindIndex(vehicles, q => q == temp)] = null;
            }
            return retFlag;
        }       
        
        public string GetVehicleInfos<TVehicle>() where TVehicle : Vehicle 
        {
            StringBuilder retString = new StringBuilder();
            
            var tempArray = Array.FindAll(vehicles, q => q is TVehicle);

            foreach (var item in tempArray)
            {
                if (item!=null) retString.Append(item + "\n");
            }

            return retString.ToString();
        }

        public bool DoesRegistartionNumberExist(string input)
        {
           
            Vehicle temp = FindVehicle(input.ToUpper());

            return temp != null ? true : false;     
        }

        public Vehicle FindVehicle(string input)
        {
            Vehicle temp = null;
            foreach (var item in vehicles)
            {
                if (item != null && item.RegistrationNumber==input)
                {
                    temp = item;
                }
            }

            //temp = Array.Find(vehicles, q => q.RegistrationNumber == input.ToUpper());
            return temp;
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
                item.Amount = GetVehicleAmountOfType(item.TypeName);
                retString.Append($"{item.TypeName}: {item.Amount}| ");
            }
            return retString.ToString();
        }
        public int GetVehicleAmountOfType(string name)
        {
            int retInt=0;
            switch (name)
            {
                case "Airplane":
                    retInt = CountVehicleType<Airplane>();
                    break;
                case "Motorcycle":
                    retInt = CountVehicleType<Motorcycle>();
                    break;
                case "Car":
                    retInt = CountVehicleType<Car>();
                    break;
                case "Bus":
                    retInt = CountVehicleType<Bus>();
                    break;
                case "Boat":
                    retInt = CountVehicleType<Boat>();
                    break;
                case "All":
                    retInt = CountVehicleType<Vehicle>();
                    break;
            }
            return retInt;
        }
        private int CountVehicleType<TVehicle>() where TVehicle : Vehicle
        {
            int retInt = 0;
            var tempArray = Array.FindAll(vehicles, q => q is TVehicle);
            foreach (var item in tempArray)
            {
                if (item != null) retInt++;
            }
            return retInt;
        }
    }
}
