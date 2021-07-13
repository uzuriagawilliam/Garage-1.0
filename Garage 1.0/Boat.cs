using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Boat : Vehicle
    {
        private string boatType;
        public string BoatType
        {
            get
            {
                return boatType;
            }
            set 
            {
                boatType = value;
            } 
        }
        public Boat()
        {

        }
        public Boat(string regNumber, string vehicleColor, string vehicleType, int tires, string boatTypes) : base(regNumber, vehicleColor, vehicleType, tires)
        {
            boatType = boatTypes;
        }
    }
}
