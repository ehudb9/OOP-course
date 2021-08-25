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
        public const int k_MakAirPressure = 30;

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            m_NumberOfDoors = (eDoorNumber)i_DataDictionary["numberOfDoors"];
            m_Color = (eColors)i_DataDictionary["carColor"];
        }

        public static Dictionary<string, VehicleBuilder.RequiredData> RequiredData()
        {
            Dictionary<string, VehicleBuilder.RequiredData> resultFromUser = new Dictionary<string, VehicleBuilder.RequiredData>();
            resultFromUser.Add("numberOfDoors", new VehicleBuilder.RequiredData("Please type how many door your car has: ", typeof(eDoorNumber)));
            resultFromUser.Add("carColor", new VehicleBuilder.RequiredData("Please type your car color: ", typeof(eColors)));
            return resultFromUser;
        }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("numberOfDoors", m_NumberOfDoors.ToString());
            i_DataDictionary.Add("carColor", m_Color.ToString());
        }

    }
}
