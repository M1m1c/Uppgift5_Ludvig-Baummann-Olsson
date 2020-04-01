using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    class VehicleCount
    {
        public VehicleCount(string name,int amount)
        {
            TypeName = name;
            Amount = amount;
        }
        public string TypeName { get;}
        public int Amount { get; set; }
    }
}
