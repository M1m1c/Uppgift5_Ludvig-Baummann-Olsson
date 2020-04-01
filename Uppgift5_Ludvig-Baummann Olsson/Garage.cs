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
            return vehicles.GetEnumerator() as IEnumerator<T>;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
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
            Vehicle temp = FindVehicle(input.ToUpper());
            if (temp != null)
            {
                retFlag = true;
                vehicles[Array.FindIndex(vehicles, q => q == temp)] = null;
            }
            return retFlag;
        }       
        
       
        public bool DoesRegistrationNumberExist(string input)
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
            return temp;
        }

        public List<Vehicle> GetVehiclesOfType<TVehicle>() where TVehicle : Vehicle
        {
            var tempArray = Array.FindAll(vehicles, q => q is TVehicle);

            var retlist= new List<Vehicle>();

            foreach (TVehicle item in tempArray)
            {
                if (item!=null) retlist.Add(item);
            }

            return retlist;
        }

        public void FillGarage()
        {
            var temp1 = new Car("ABC123", "Blue", 4, "Disel");
            if (!DoesRegistrationNumberExist(temp1.RegistrationNumber))
            {
                AddVehicle(temp1);
            }

            var temp2 = new Airplane("DEF456", "Blue", 6, 4);
            if (!DoesRegistrationNumberExist(temp2.RegistrationNumber))
            {
                AddVehicle(temp2);
            }

            var temp3 = new Boat("GHJ789", "Blue", 0, 8.5);
            if (!DoesRegistrationNumberExist(temp3.RegistrationNumber))
            {
                AddVehicle(temp3);
            }

            var temp4 = new Bus("KLM321", "Blue", 6, 20);
            if (!DoesRegistrationNumberExist(temp4.RegistrationNumber))
            {
                AddVehicle(temp4);
            }
        }
    }
}
