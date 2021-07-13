using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Truck : Vehicle
    {
        int cargoCapacity;
        public int CargoCapacity
        {
            get
            {
                return cargoCapacity;
            }
            set
            {
                cargoCapacity = value;
            }
        }

        public Truck() 
        {

        }
        
        public Truck(string regNum, string color, int tires, string carType , int capacity) : base(regNum, color, carType, tires)
        {
            CargoCapacity = capacity;
        }
    }
}
