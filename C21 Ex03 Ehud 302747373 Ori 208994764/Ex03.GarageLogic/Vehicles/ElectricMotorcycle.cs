using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private readonly Motorcycle r_Motorcycle = new Motorcycle();
        private const float k_MaxBatteryTimeInHours = 1.6f;

        public ElectricMotorcycle() : base(k_MaxBatteryTimeInHours, Car.k_NumberOfWheels, Car.k_MaxAirPressure)
        {

        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            r_Motorcycle.Init(i_DataDictionary);
            base.Init(i_DataDictionary);
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> details = new Dictionary<string, VehicleBuilder.InsertDetails>();
            foreach (KeyValuePair<string, VehicleBuilder.InsertDetails> detail in Motorcycle.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            foreach (KeyValuePair<string, VehicleBuilder.InsertDetails> detail in ElectricVehicle.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            return details;
        }

        public override void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("vehicleType", "Electric car");
            base.GetData(i_DataDictionary);
            r_Motorcycle.GetData(i_DataDictionary);
        }
    }
}
