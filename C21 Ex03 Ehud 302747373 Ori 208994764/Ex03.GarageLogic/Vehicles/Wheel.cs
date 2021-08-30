using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const float k_MinAirPressure = 0;
        private float m_CurrentAirPressure;
        public float MaxAirPressure { get; }

        public string Manufacturer { get; set; }

        public float CurrentAirPressure
        {
            get => m_CurrentAirPressure;
            set
            {
                if (value > MaxAirPressure || value < k_MinAirPressure)
                {
                    throw new ValueOutOfRangeException($"You cant inflate vehicle's tires by {value}", k_MinAirPressure, MaxAirPressure);
                }

                m_CurrentAirPressure = value;
            }
        }

        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
        }

        public void Init(Dictionary<string, object> i_DataDictionary)
        {
            CurrentAirPressure = (float)i_DataDictionary["currentAirPressure"];
            Manufacturer = (string)i_DataDictionary["manufacturerName"];
        }

        public void Inflate(float i_AmountToAdd)
        {
            CurrentAirPressure += i_AmountToAdd;
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> detailsToInsert = new Dictionary<string, VehicleBuilder.InsertDetails>();
            detailsToInsert.Add("currentAirPressure", new VehicleBuilder.InsertDetails("Please type wheel's current air pressure: ", typeof(float)));
            detailsToInsert.Add("manufacturerName", new VehicleBuilder.InsertDetails("Please type wheel's manufacturer name: ", typeof(string)));
            return detailsToInsert;
        }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            i_DataDictionary.Add("currentAirPressure", m_CurrentAirPressure.ToString());
            i_DataDictionary.Add("manufacturerName", Manufacturer);
        }

        public override string ToString()
        {
            string wheelDetailStr = $"manufacturer name: {Manufacturer}, max air pressure {MaxAirPressure}, current air pressure: {CurrentAirPressure}";
            return wheelDetailStr;
        }
    }
}
