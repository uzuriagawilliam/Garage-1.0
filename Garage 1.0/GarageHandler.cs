using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Garage_1._0
{
    public class GarageHandler : IGarageHandler
    {
        private Garage<Vehicle> garage;        

         public bool ParkCar(string RegisNumber, string CarColor, string vehicleType, int CarTyresCuantity)
        {
            Vehicle tmpVehicle = new Vehicle(RegisNumber, CarColor, vehicleType, CarTyresCuantity);
            
            bool checkParc = garage.Park(tmpVehicle);

            if(checkParc == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GarageStatus()//Returnerar en detallerad sträng av vad som finns i Graget
        {
            int emptyCarPlaces = 0;
            int trucks = 0;
            int sedan = 0;
            int coupe = 0;
            int pickup = 0;
            int convertibles = 0;            
            int bus = 0;
            int mc = 0;
            int boat = 0;

            int garageCap = garage.GarageCapacity;
            int testCounter = garage.Count();

 
            if (testCounter == 0)
            {
                return "Garaget är tom";
            }

            emptyCarPlaces = garageCap - testCounter;

 
            var result = garage.GroupBy(v => v.VehicleType).Select(v => new
            {
                VehicleType = v.Key,
                Count = v.Count()
            });

            for (int i = 0; i < garageCap; i++)
            {
                if (garage[i] == null) continue;
                if (garage[i].VehicleType == "truck") trucks += 1;
                if (garage[i].VehicleType == "sedan") sedan += 1;
                if (garage[i].VehicleType == "coupe") coupe += 1;
                if (garage[i].VehicleType == "pickup") pickup += 1;
                if (garage[i].VehicleType == "convertibles") convertibles += 1;                
                if (garage[i].VehicleType == "bus") bus += 1;
                if (garage[i].VehicleType == "motorcycle") mc += 1;
                if (garage[i].VehicleType == "boat") boat += 1;
            }
            return $"{trucks} Lastbilar, {sedan} Sedan, {coupe} Coupe {pickup} Pickups, {convertibles} Convertibles,\n{bus} bus {mc} Motorcycle {boat} Boats och {emptyCarPlaces} lediga parkerinsplatser";
        }


        void TABORT()
        {
            var input = "ABC123            GUL     4";
            var searchCriteria = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public void TestSearch(string[] searchCriteria)//???????
        {
            var searchResultat = garage.Select(v => v);

            foreach (var item in searchCriteria)
            {
                searchResultat = searchResultat.Where(v => v.RegisNumber == item ||
                                                           v.VehicleType == item ||
                                                           v.CarColor == item);
            }
            searchResultat.ToList();

            int c = searchResultat.Count();

            if (c == 0)
            {
                Console.WriteLine("Ingen bil hittades.");
            }

            foreach (var vehicle in searchResultat)
            {
                Console.WriteLine($"{vehicle.RegisNumber.ToString()}");
            }
        }

        public Vehicle SearchCarByRegNumber(string carRegNumber)
        {    
            var searchResultat = garage.FirstOrDefault(v => v.RegisNumber == carRegNumber);         
            return searchResultat;
        }

        public Vehicle[] SearchCarByColor(string carColor)
        {
            var carByColor = garage.Where(c => c.CarColor == carColor).ToArray();
            return carByColor;
        }

        public Vehicle[] SearchByCarType(string carType)
        {
            var carByType = garage.Where(c => c.VehicleType == carType).ToArray();
            return carByType;
        }
        public string TakeCarOutOfGarage(string carRegNum)
        {

            if (garage.Unpark(carRegNum))
            {
                return $"{carRegNum} found and unparked.";
            }
            else
            {
                return $"{carRegNum} not found.";
            }
            
        }

        public bool ParkTruck(string regNumber, string carColor, string carType, int tires, int truckCapacity)
        {
            Truck tmpTruck = new Truck(regNumber, carColor, tires, carType, truckCapacity);
            tmpTruck.CargoCapacity = truckCapacity;           

            bool checkParc = garage.Park(tmpTruck);

            if (checkParc == false)
            {
                return false;
            }
            else
            {
                return true;
            }         
        }

        public bool ParkBuss(string regNumber, string carColor, string carType, int tires, int numSeats)
        {
            Bus tmpBus = new Bus(regNumber, carColor, tires, carType, numSeats);
            tmpBus.NumberOfSeats = numSeats;

            bool checkParc = garage.Park(tmpBus);

            if (checkParc == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool ParkMc(string regNumber, string carColor, string carType, int tires, string vehicleBrand)
        {
            Motorcycle tmpMc = new Motorcycle(regNumber, carColor, carType, tires, vehicleBrand);
            tmpMc.VehicleBrand = vehicleBrand;

            bool checkParc = garage.Park(tmpMc);

            if (checkParc == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool ParkBoat(string regNumber, string carColor, string carType, int tires, string boatTypes)
        {
            Boat tmpBoat = new Boat(regNumber, carColor, carType, tires, boatTypes);
            tmpBoat.BoatType = boatTypes;

            bool checkParc = garage.Park(tmpBoat);

            if (checkParc == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CreateGarage(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }
    }
}
