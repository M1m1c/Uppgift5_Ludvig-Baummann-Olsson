using System;

namespace Uppgift5_Ludvig_Baummann_Olsson
{
    class Program
    {
        static UI ui = new UI();
        static GarageHandler garageHandler = new GarageHandler();
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
                    "4. to add a new vehicle to the garage\n" +
                    "5. to remove a vehicle from the garage\n" +
                    "6. to search for a vehicle using its registration number\n");
                ui.PrintMessageLog();
                ui.ClearMessageLog();
                string input = ui.ReadLine();
                char selection = input.Length > 0 && input.Length < 2 ? input[0] : ' ';

                if (selection == '0') { Environment.Exit(0); }

                if (selection == '1') { CreateGarage(); }

                if (garageHandler.HasGarage() == true)
                {
                    switch (selection)
                    {
                        case '2':
                            FillGarageWithDefault();
                            break;
                        case '3':
                            PrintVehiclesInGarage();
                            break;
                        case '4':
                            AddVehicle();
                            break;
                        case '5':
                            RemoveVehicle();
                            break;
                        case '6':
                            SearchForVehicle();
                            break;
                    }
                }
                else
                {
                    ui.AddToMessageLog("Create a garage first!");
                }
            }
        }

        private static void SearchForVehicle()
        {
            string tempString = "";
            while (true)
            {
                ui.Print("Write the registration number of the vehicle you want to see");
                string input = ui.ReadLine();
                char selection = input.Length > 0 ? input[0] : ' ';
                if (selection == '0')
                {
                    break;
                }
                Vehicle tempVehicle = garageHandler.FindVehicle(input.ToUpper());
                tempString = tempVehicle != null ? tempVehicle.ToString() : "";
                if (!string.IsNullOrEmpty(tempString))
                {
                    ui.AddToMessageLog(tempString);
                    break;
                }
                ui.Print("Could not find a vehicle with that registration number");
            }

        }

        private static void RemoveVehicle()
        {

            while (true)
            {

                ui.Print("type the registration number of the vehicle you wish to remove. type 0 to exit.");
                string input = ui.ReadLine();
                char selection = input.Length > 0 && input.Length < 2 ? input[0] : ' ';
                if (selection == '0')
                {
                    break;
                }
                else if (garageHandler.RemoveVehicle(input))
                {
                    ui.AddToMessageLog("Vehicle was removed successfully");
                    break;
                }
                ui.Print("Could not find a vehicle with that number in the garage");
            }

        }

        private static void AddVehicle()
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

                if (garageHandler.AddVehicle(vehicle))
                {
                    ui.AddToMessageLog("Vehicle added to garage successfully");
                    break;
                }
            }

        }

        //TODO bryt ut allt som är gemensamt för alla vehicles i en metod, kanske lytta den till garage handeler
        //kanske hämta ut properties dynamiskt
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
                    retValue = new Motorcycle(
                       CreateRegistration().ToUpper(),
                       SetString("Please enter a color:"),
                       ParseANumber("Please enter how many wheels the vehicle has:"),
                       ParseANumber("Please enter the cylidner volume of the motocycle:"));
                    break;
                case "car":
                    retValue = new Car(
                    CreateRegistration().ToUpper(),
                    SetString("Please enter a color:"),
                    ParseANumber("Please enter how many wheels the vehicle has:"),
                    SetString("Please enter what type of fuel the car uses:"));
                    break;
                case "bus":
                    retValue = new Bus(
                    CreateRegistration().ToUpper(),
                    SetString("Please enter a color:"),
                    ParseANumber("Please enter how many wheels the vehicle has:"),
                    ParseANumber("Please enter how many seats the bus has:"));
                    break;
                case "boat":
                    retValue = new Bus(
                    CreateRegistration().ToUpper(),
                    SetString("Please enter a color:"),
                    ParseANumber("Please enter how many wheels the vehicle has:"),
                    ParseANumber("Please enter how long the boat is:"));
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
                if (int.TryParse(input, out retInt))
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
                if (garageHandler.DoesRegistrationNumberExist(input) == false)
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

            ui.Print("Enter one of the following commands to see vehicles of that type:\n" +
          "All\n" +
          "Airplane\n" +
          "Motorcycle\n" +
          "Car\n" +
          "Bus\n" +
          "Boat\n");
            ui.AddToMessageLog(garageHandler.GetVehicleInfos(ui.ReadLine()));
            ui.AddToMessageLog(garageHandler.CountVehicles());

        }

        private static void FillGarageWithDefault()
        {

            garageHandler.FillGarage();
            ui.AddToMessageLog("Added some default vehicles to the garage");

        }

        private static void CreateGarage()
        {
            while (true)
            {
                int capacity;
                ui.Print("Enter a number to determine the capacity of the garage");
                if (int.TryParse(ui.ReadLine(), out capacity) && capacity != 0)
                {
                    garageHandler.CreateGarage(capacity);
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
