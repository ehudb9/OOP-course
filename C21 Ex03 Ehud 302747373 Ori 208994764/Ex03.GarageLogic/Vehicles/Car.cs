using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car
    {
        public enum eDoorNumber
        {
            Two,
            Three,
            Four,
            Five
        }
        
        public enum eColors
        {
            Yellow,
            White,
            Black,
            Blue
        }

        private eColors m_Color;
        private eDoorNumber m_NumberOfDoors;
        public const int k_NumberOfWheels = 4;
        public const int k_MaxAirPressure = 30;

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            m_NumberOfDoors = (eDoorNumber)i_DataDictionary["numberOfDoors"];
            m_Color = (eColors)i_DataDictionary["carColor"];
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> detailsToInsert = new Dictionary<string, VehicleBuilder.InsertDetails>();
            detailsToInsert.Add("numberOfDoors", new VehicleBuilder.InsertDetails("Please type how many door your car has: ", typeof(eDoorNumber)));
            detailsToInsert.Add("carColor", new VehicleBuilder.InsertDetails("Please type your car color: ", typeof(eColors)));
            return detailsToInsert;
        }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("numberOfDoors", m_NumberOfDoors.ToString());
            i_DataDictionary.Add("carColor", m_Color.ToString());
        }
    }
}
