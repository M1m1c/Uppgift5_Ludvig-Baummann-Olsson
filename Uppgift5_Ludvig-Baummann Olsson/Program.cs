using System;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    class Program
    {
        static UI ui = new UI();
        static GarageHandler garageHandeler = new GarageHandler();
        static void Main(string[] args)
        {
            while (true)
            {
                ui.Clear();
                ui.Print("Main Menu\n" +
                    "----------------\n" +
                    "0. to exit application\n" +
                    "1. to create a garage\n" +
                    "2. to add default vehicles to garage\n" +
                    "3. to print vehicles in garage\n" +
                    "4. to add a new vehicle to the garage\n");
                ui.PrintMessageLog();
                ui.ClearMessageLog();
                string input = ui.ReadLine();
                char selection = input.Length > 0 ? input[0] : ' ';
                switch (selection)
                {
                    case '0':
                        Environment.Exit(0);
                        break;
                    case '1':
                        CreateGarage();
                        break;
                    case '2':
                        FillGarageWithDefault();
                        break;
                    case '3':
                        PrintVehiclesInGarage();
                        break;
                    case '4':
                        AddVehicle();
                        break;
                    default:
                        ui.Print("Please enter a valid selection");
                        break;
                }

            }
        }

        private static void AddVehicle()
        {
            if (garageHandeler.HasGarage())
            {
                while (true)
                {
                    ui.Print("Enter one of the following to create a vehicle of that type:\n" +
                             "Airplane\n" +
                             "Motorcycle\n" +
                             "Car\n" +
                             "Bus\n" +
                             "Boat\n");

                    string input = ui.ReadLine();

                    Vehicle vehicle = CreateNewVehicle(input);

                    if (garageHandeler.AddVehicle(vehicle))
                    {
                        ui.AddToMessageLog("Vehicle added to garage successfully");
                        break;
                    }
                    //Determine type
                    //enter registration number
                    //enter color
                    //enter wheels
                    //enter any extra variables
                }
            }
            else
            {
                ui.AddToMessageLog("Create a garage before adding vehicles to it");
            }
            
          

        }
        static public Vehicle CreateNewVehicle(string input)
        {
            var retValue = new Vehicle("0", "0", 0);
            switch (input.ToLower())
            {
                case "airplane":
                    retValue = new Airplane(
                        CreateRegistration().ToUpper(),
                        SetString("Please enter a color:"),
                        ParseANumber("Please enter how many wheels the vehicle has:"),
                        ParseANumber("Please enter how many engines the plane has:"));
                    break;
                case "motorcycle":
                    //TODO
                    break;
                case "car":
                    //TODO
                    break;
                case "bus":
                    //TODO
                    break;
                case "boat":
                    //TODO
                    break;
            }
            return retValue;
        }


        private static int ParseANumber(string message)
        {
            int retInt;
            while (true)
            {
                string input = SetString(message);
                if (int.TryParse(input,out retInt))
                {
                    break;
                }
                ui.Print("Invalid amount, make sure to only use numbers");
            }
            return retInt;
        }

        private static string SetString(string message)
        {
            ui.Print(message);
            return ui.ReadLine();
        }

        private static string CreateRegistration()
        {
            string retString;
            while (true)
            {
                ui.Print("Enter a new registration number");
                string input = ui.ReadLine();
                if (garageHandeler.DoesRegistrationNumberExist(input) == false)
                {
                    retString = input;
                    break;
                }
                ui.Print("Registration number already exists in garage, each registration number must be unique");
            }
            return retString; 
        }

        private static void PrintVehiclesInGarage()
        {
            if (garageHandeler.HasGarage())
            {
                ui.Print("Enter one of the following commands to see vehicles of that type:\n" +
              "All\n" +
              "Airplane\n" +
              "Motorcycle\n" +
              "Car\n" +
              "Bus\n" +
              "Boat\n");
                ui.AddToMessageLog(garageHandeler.GetVehicleInfos(ui.ReadLine()));
                ui.AddToMessageLog(garageHandeler.CountVehicles());
            }
            else
            {
                ui.AddToMessageLog("Create a garage first");
            }    
        }

        private static void FillGarageWithDefault()
        {
            if (garageHandeler.HasGarage())
            {
                garageHandeler.FillGarage();
                ui.AddToMessageLog("Added some default vehicles to the garage");
            }
            else
            {
                ui.AddToMessageLog("Create a garage before adding vehicles to it");
            }
        }

        private static void CreateGarage()
        {
            while (true)
            {
                int capacity;
                ui.Print("Enter a number to determine the capacity of the garage");
                if (int.TryParse(ui.ReadLine(), out capacity) && capacity != 0) 
                {
                    garageHandeler.CreateGarage(capacity);
                    ui.AddToMessageLog($"A garage with a capcity for {capacity} vehicles has been created");
                    break;
                }
                else
                {
                    ui.Print("Please enter a valid selection");
                }
            }
        }
    }
}
