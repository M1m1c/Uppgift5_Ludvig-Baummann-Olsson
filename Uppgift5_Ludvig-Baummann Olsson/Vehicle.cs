using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5_Ludvig_Baummann_Olsson
{

    public class Vehicle
    {
        public Vehicle(string regN, string color, int wheels)
        {
            RegNo = regN;
            Color = color;
            Wheels = wheels;
        }

        public Vehicle(Vehicle vehicle)
        {
            RegNo = vehicle.RegNo;
            Color = vehicle.Color;
            Wheels = vehicle.Wheels;
        }

        public string RegNo { get; set; }

        public string Color { get; set; }

        public int Wheels { get; set; }

        public override string ToString()
        {
            return ($"{this.GetType().Name}-> Lisence Plate: {RegNo}| Color: {Color}| Wheels: {Wheels}|");
        }
    }

    class Airplane : Vehicle
    {
        public Airplane(string regN, string color, int wheels, int numEngines) : base(regN, color, wheels)
        {
            NumberOfEngines = numEngines;
        }

        public Airplane(Vehicle vehicle, int numEngines) : base(vehicle)
        {
            NumberOfEngines = numEngines;
        }

        public int NumberOfEngines { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Engines: {NumberOfEngines}|";
        }
    }

    class Motorcycle : Vehicle
    {
        public Motorcycle(string regN, string color, int wheels, int cylVolume) : base(regN, color, wheels)
        {
            CylinderVolume = cylVolume;
        }

        public Motorcycle(Vehicle vehicle, int cylVolume) : base(vehicle)
        {
            CylinderVolume = cylVolume;
        }

        public int CylinderVolume { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Cylinder Volume: {CylinderVolume}|";
        }
    }

    class Car : Vehicle
    {
        public Car(string regN, string color, int wheels, string fuelType) : base(regN, color, wheels)
        {
            FuelType = fuelType;
        }

        public Car(Vehicle vehicle, string fuelType) : base(vehicle)
        {
            FuelType = fuelType;
        }

        public string FuelType { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Fuel Type: {FuelType}|";
        }
    }

    class Bus : Vehicle
    {
        public Bus(string regN, string color, int wheels, int numSeats) : base(regN, color, wheels)
        {
            NumberOfSeats = numSeats;
        }

        public Bus(Vehicle vehicle, int numSeats) : base(vehicle)
        {
            NumberOfSeats = numSeats;
        }

        public int NumberOfSeats { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Seats: {NumberOfSeats}|";
        }
    }

    class Boat : Vehicle
    {
        public Boat(string regN, string color, int wheels, double length) : base(regN, color, wheels)
        {
            Length = length;
        }

        public Boat(Vehicle vehicle, double length) : base(vehicle)
        {
            Length = length;
        }

        public double Length { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Length: {Length} meters|";
        }
    }
}
