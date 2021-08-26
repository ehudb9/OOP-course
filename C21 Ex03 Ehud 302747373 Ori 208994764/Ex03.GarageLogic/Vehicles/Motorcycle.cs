using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        public const int k_NumberOfWheels = 2;
        public const float k_MaxAirPressure = 28;
        public int EngineCapacityInCc { get; set; }

        public eLicenseType LicenseType { get; set; }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            LicenseType = (eLicenseType)i_DataDictionary["licenseType"];
            EngineCapacityInCc = (int)i_DataDictionary["engineCapacity"];
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> detailsToInsert = new Dictionary<string, VehicleBuilder.InsertDetails>();
            detailsToInsert.Add("licenseType", new VehicleBuilder.InsertDetails("Please type your motorcycle license: ", typeof(eLicenseType)));
            detailsToInsert.Add("engineCapacity", new VehicleBuilder.InsertDetails("Please type your car color: ", typeof(int)));
            return detailsToInsert;
        }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("licenseType", LicenseType.ToString());
            i_DataDictionary.Add("engineCapacity", EngineCapacityInCc.ToString());
        }
    }

}
}
