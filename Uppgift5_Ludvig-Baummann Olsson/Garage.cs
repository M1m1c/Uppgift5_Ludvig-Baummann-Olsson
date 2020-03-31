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
            Vehicle temp = FindVehicle(input);

            return temp == null ? true : false;
        }

        public Vehicle FindVehicle(string input)
        {
            return Array.Find(vehicles, q => q.RegistrationNumber == input.ToUpper());
        }
    }
}
