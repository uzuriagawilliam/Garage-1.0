using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Motorcycle : Vehicle
    {
        private string vehicleBrand;

        public string VehicleBrand
        {
            get
            {
                return vehicleBrand;
            }
            set
            {
                vehicleBrand = value;
            }
        }
        public Motorcycle()
        {

        }
        public Motorcycle(string regNumber, string vehicleColor, string vehicleType, int tires, string vehicleBrand) : base(regNumber, vehicleColor, vehicleType, tires)
        {

        }
    }
}
