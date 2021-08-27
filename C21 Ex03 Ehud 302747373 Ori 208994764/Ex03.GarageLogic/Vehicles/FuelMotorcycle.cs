using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        private readonly Motorcycle r_Motorcycle = new Motorcycle();
        private const float k_MaxFuel = 5.5f;
        private const eFuelType k_FuelType = eFuelType.Octan98;

        public FuelMotorcycle() : base(k_FuelType, k_MaxFuel, Motorcycle.k_NumberOfWheels, Motorcycle.k_MaxAirPressure)
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

            foreach (KeyValuePair<string, VehicleBuilder.InsertDetails> detail in FuelVehicle.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            return details;
        }

        public override void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("vehicleType", "Fuel motorcycle");
            base.GetData(i_DataDictionary);
            r_Motorcycle.GetData(i_DataDictionary);
        }
    }
}
