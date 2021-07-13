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
    public class GarageTests
    {
        private Garage<Vehicle> garageTest = new Garage<Vehicle>(2);
        

        [TestMethod()]
        public void Parking_Car_In_Garage_Test()
        {
            //Arrange
            bool expected = true;
            Vehicle vehicle = new Vehicle("aa11", "red", "sedan", 4);

            //act
            expected = garageTest.Park(vehicle);
            //Assert
            Assert.IsTrue(expected);
        }
        [TestMethod()]
        public void UnPark_Car_From_Garage_Test()
        {
            //Arrange
            Vehicle vehicle = new Vehicle("aa11", "red", "sedan", 4);
            bool expected = true;
            garageTest.Park(vehicle);

            //act
            expected = garageTest.Unpark("aa11");
            //Assert
            Assert.IsTrue(expected);
        }

    }
}