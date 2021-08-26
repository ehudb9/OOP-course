using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private Car m_Car = new Car();
        private const float k_MaxFuel = 50;
        private const eFuelType k_FuelType = eFuelType.Octan95;

        public FuelCar() : base(k_FuelType, k_MaxFuel, Car.k_NumberOfWheels, Car.k_MaxAirPressure)
        {

        }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            m_Car.Init(i_DataDictionary);
            base.Init(i_DataDictionary); //Todo - write Init method in Vehicle class 
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> details = new Dictionary<string, VehicleBuilder.InsertDetails>();
            foreach(var detail in Car.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            foreach(var detail in FuelVehicle.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            return details;
        }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("vehicleType", "Fuel car");
            base.GetData(i_DataDictionary);
            m_Car.GetData(i_DataDictionary);
        }
    }
}
