using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    interface IGarage
    {
        void ParkCar();//Parkerar ett fordom i G.
        void carOut();//Tar bort bilar från garaget
        void CheckGarageStatus();//Tittar om det finns lediga platser

    }
}
