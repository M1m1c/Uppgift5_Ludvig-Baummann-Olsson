namespace Uppgift5_Ludvig_Baummann_Olsson
{
    public interface IHandler
    {
        public bool AddVehicle(Vehicle vehicle);

        public bool RemoveVehicle(string input);

        public Vehicle FindVehicle(string input);

        public string CountVehicles();

        public string GetVehicleInfos(string input);
    }
}