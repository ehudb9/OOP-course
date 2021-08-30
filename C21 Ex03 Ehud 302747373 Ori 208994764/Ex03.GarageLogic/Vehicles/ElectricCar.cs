using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private readonly Car r_Car = new Car();
        private const float k_MaxBatteryTimeInHours = 2.8f;

        public ElectricCar() : base(k_MaxBatteryTimeInHours, Car.k_NumberOfWheels, Car.k_MaxAirPressure)
        {

        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            r_Car.Init(i_DataDictionary);
            base.Init(i_DataDictionary);
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> details = new Dictionary<string, VehicleBuilder.InsertDetails>();
            foreach (KeyValuePair<string, VehicleBuilder.InsertDetails> detail in Car.InsertDetails())
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
            r_Car.GetData(i_DataDictionary);
        }
    }
}
