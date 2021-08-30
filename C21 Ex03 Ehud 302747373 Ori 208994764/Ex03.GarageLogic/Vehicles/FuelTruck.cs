using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTruck : FuelVehicle
    {
        private readonly Truck r_Truck = new Truck();
        private const float k_MaxFuel = 110;
        private const eFuelType k_FuelType = eFuelType.Soler;

        public FuelTruck() : base(k_FuelType, k_MaxFuel, Truck.k_NumberOfWheels, Truck.k_MaxAirPressure)
        {

        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            r_Truck.Init(i_DataDictionary);
            base.Init(i_DataDictionary);
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> details = new Dictionary<string, VehicleBuilder.InsertDetails>();
            foreach (KeyValuePair<string, VehicleBuilder.InsertDetails> detail in Truck.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            foreach (KeyValuePair<string, VehicleBuilder.InsertDetails> detail in FuelVehicle.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            return details;
        }

        public override void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("vehicleType", "Fuel truck");
            base.GetData(i_DataDictionary);
            r_Truck.GetData(i_DataDictionary);
        }
    }
}
