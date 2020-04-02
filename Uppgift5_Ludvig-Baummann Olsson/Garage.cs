using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;

        public Garage(int capacity)
        {
            vehicles = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tempArray = Array.FindAll(vehicles, q => q is T && q != null);
            foreach (T item in tempArray)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool AddVehicle(T vehicle)
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
            if (!string.IsNullOrEmpty(input))
            {
                var temp = vehicles[Array.FindIndex(vehicles, q => q.RegistrationNumber == input)];

                if (temp != null)
                {
                    retFlag = true;
                    temp = null;
                }
            }
            return retFlag;
        }
    }
}
