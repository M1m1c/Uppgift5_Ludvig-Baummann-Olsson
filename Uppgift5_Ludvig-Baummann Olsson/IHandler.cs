namespace Uppgift5_Ludvig_Baummann_Olsson
{
    public interface IHandler
    {
        public void CreateGarage(int capacity);

        public bool HasGarage();
        
        public bool AddVehicle(Vehicle vehicle);

        public bool RemoveVehicle(string input);

        public bool DoesRegistrationNumberExist(string input);

        public Vehicle FindVehicle(string input);

        public string CountVehicles();

        public string GetVehicleInfos(string input);

        public void FillGarage();
    }
}