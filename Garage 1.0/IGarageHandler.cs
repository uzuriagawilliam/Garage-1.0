namespace Garage_1._0
{
    public interface IGarageHandler
    {
        string GarageStatus();
        bool ParkCar(string RegisNumber, string CarColor, string vehicleType, int CarTyresCuantity);
        bool ParkTruck(string regNumber, string carColor, string carType, int tires, int truckCapacity);
        bool ParkBuss(string regNumber, string carColor, string carType, int tires, int numSeats);
        bool ParkMc(string regNumber, string carColor, string carType, int tires, string vehicleBrand);
        bool ParkBoat(string regNumber, string carColor, string carType, int tires, string boatTypes);
        void CreateGarage(int v);
        Vehicle[] SearchByCarType(string carType);
        Vehicle[] SearchCarByColor(string carColor);
        Vehicle SearchCarByRegNumber(string carRegNumber);
        string TakeCarOutOfGarage(string carRegNum);
        void TestSearch(string[] searchCriteria);
    }
}