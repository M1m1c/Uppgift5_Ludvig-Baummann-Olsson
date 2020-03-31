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
                    "2. to add default vehicles to garage\n");
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
                        while (true)
                        {
                            ui.PrintMessageLog();
                            int capacity;
                            ui.Print("Enter a number to determine the capacity of the garage");
                            if (int.TryParse(ui.ReadLine(), out capacity))
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
                       
                       
                        
                        break;
                    default:
                        ui.Print("Please enter a valid selection");
                        break;
                }

            }
        }
    }
}
