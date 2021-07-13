using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Vehicle : IVehicle
    {
        private string regisNumber;
        private string carColor;
        private int carTyresCuantity;
        private string vehicleType;//sedan , coupe (two door),convertibles , pickup , TRUCK, BUS, boat, motorcykel

        public string RegisNumber
        {
            get
            {
                return regisNumber;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Not valid input");
                }
                else
                    regisNumber = value;
            }
        }
        public string CarColor
        {
            get
            {
                return carColor;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Not valid input");
                }

                else
                {
                    carColor = value;
                }
            }            
        }
        public int CarTyresCuantity
        {
            get
            {
                return carTyresCuantity;
            }
            set
            {
                carTyresCuantity = value;
            }
        }
        public string VehicleType
        {
            get
            {
                return vehicleType;
            }
            set
            {
                vehicleType = value;
            } 
        }
        public Vehicle() //Defaul consructor
        {
        
        }
        public Vehicle(string regNum, string color, string vehicletype, int tyres) 
        {
            RegisNumber = regNum;
            CarColor = color;
            CarTyresCuantity = tyres;
            vehicleType = vehicletype;
        }
               
    }
}
