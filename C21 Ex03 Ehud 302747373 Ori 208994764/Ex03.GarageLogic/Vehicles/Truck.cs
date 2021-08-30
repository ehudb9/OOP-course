using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck
    {
        private bool m_IsCarrierHazardousMaterials;
        private float m_CargoVolume;
        public const int k_NumberOfWheels = 16;
        public const int k_MaxAirPressure = 26;

        public bool IsCarrierHazardousMaterials
        {
            get => m_IsCarrierHazardousMaterials;
        }

        public float CargoVolume
        {
            get => m_CargoVolume;
        }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            m_IsCarrierHazardousMaterials = (bool)i_DataDictionary["carrierHazardousMaterials"];
            m_CargoVolume = (float)i_DataDictionary["cargoVolume"];
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> detailsToInsert = new Dictionary<string, VehicleBuilder.InsertDetails>();
            detailsToInsert.Add("carrierHazardousMaterials", new VehicleBuilder.InsertDetails("Please type if your truck carrying hazardous materials: ", typeof(bool)));
            detailsToInsert.Add("cargoVolume", new VehicleBuilder.InsertDetails("Please type the truck cargo volume: ", typeof(float)));
            return detailsToInsert;
        }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("carrierHazardousMaterials", IsCarrierHazardousMaterials ? "Yes" : " No");
            i_DataDictionary.Add("cargoVolume", CargoVolume.ToString());
        }
    }
}
