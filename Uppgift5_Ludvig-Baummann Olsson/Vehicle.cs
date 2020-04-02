using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5_Ludvig_Baummann_Olsson
{

    public class Vehicle
    {
        public Vehicle(string regN, string color, int wheels)
        {
            RegistrationNumber = regN;
            Color = color;
            Wheels = wheels;
        }

        public string RegistrationNumber { get; set; }

        public string Color { get; set; }

        public int Wheels { get; set; }

        public override string ToString()
        {
            return ($"{this.GetType().Name}-> Lisence Plate: {RegistrationNumber}| Color: {Color}| Wheels: {Wheels}|");
        }
    }

    class Airplane : Vehicle
    {
        public Airplane(string regN, string color, int wheels, int numEngines) : base(regN, color, wheels)
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

        public double Length { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Length: {Length} meters|";
        }
    }
}
