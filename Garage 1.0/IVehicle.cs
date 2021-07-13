using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public interface IVehicle
    {
        string RegisNumber { get; set; }
        string CarColor { get; set; }
        int CarTyresCuantity { get; set; }
        string VehicleType { get; set; }
    }
}
