using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Bus : Vehicle
    {
        private int numberOfSeats;
        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats;
            }
            set
            {
                numberOfSeats = value;
            }
        }

        public  Bus()
        {

        }

        public Bus(string regNum, string color, int tires, string carType, int numSeats) : base(regNum, color, carType, tires)
        {


        }
    }
}
