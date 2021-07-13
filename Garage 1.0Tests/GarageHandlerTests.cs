using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage_1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Tests
{
    [TestClass()]
    public class GarageHandlerTests
    {
        GarageHandler GH = new GarageHandler();

        [TestMethod()]
        public void Garage_Empty_Status_Test()
        {
            Garage<Vehicle> vehicles = new Garage<Vehicle>(2);
            GH.CreateGarage(2);
            string expected = GH.GarageStatus();

            Assert.AreEqual(expected, "Garaget är tom");
        }

        [TestMethod()]
        public void Dearch_Car_By_Reg_Number()
        {
            //Garage<Vehicle> vehicles = new Garage<Vehicle>(2);
            //Vehicle vehicle = new Vehicle("aa11", "red", "sedan", 4);
            var vehicle2 = new Truck("aa11", "Red", 10, "V8", 10);

            //vehicles.Park(vehicle);
            GH.CreateGarage(2);
            GH.ParkTruck("aa11", "Red", "Firetruck", 10, 10);
            var expected = GH.SearchCarByRegNumber("aa11");

            Assert.AreEqual(expected.VehicleType, "Firetruck");
        }
    }
}