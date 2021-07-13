using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {        

        private T[] vehicles;

        int garageCapacity;

        public int GarageCapacity
        {
            get
            {
                return garageCapacity;
            }
            set
            {
                garageCapacity = value;
            }
        }
        public T this[int index] => vehicles[index];
        //{
        //    get
        //    {
        //       return vehicles[index];
        //    } 
        //}

        public Garage(int capacity)
        {
            vehicles = new T[capacity];
            GarageCapacity = capacity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                if (item != null)
                    yield return item;
            }
        }

        public bool Park(T vehicle)
        {            
            for (int i = 0; i < GarageCapacity; i++) 
            {
                if (vehicles[i]==null)
                {
                    vehicles[i] = vehicle;
                    return true;
                }
            }
            return false;
        }

        public bool Unpark(string carRegNum)
        {
            for (int i = 0; i < GarageCapacity; i++)
            {
                if (vehicles[i] == null) continue;

                if (vehicles[i].RegisNumber == carRegNum)
                {
                    vehicles[i] = default (T);//istället för null
                    return true;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
