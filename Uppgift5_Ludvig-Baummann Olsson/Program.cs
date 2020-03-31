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
                    "3. to print vehicles in garage\n");
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
                    default:
                        ui.Print("Please enter a valid selection");
                        break;
                }

            }
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
            ui.AddToMessageLog(garageHandeler.GetVehicleInfos(ui.ReadLine()));
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
