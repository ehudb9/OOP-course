using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const int k_MinEnergyPercent = 0;
        private const int k_MaxEnergyPercent = 100;
        private string m_ModelName;
        private float m_EnergyPercent;
        private readonly List<Wheel> r_Wheels = new List<Wheel>();

        public string PlateNumber { get; set; }

        public float EnergyPercent
        {
            get => m_EnergyPercent;
            set
            {
                if(m_EnergyPercent < k_MinEnergyPercent || m_EnergyPercent > k_MaxEnergyPercent)
                {
                    throw new ValueOutOfRangeException("Energy percent out of range. It's need to be between 0 to 100", k_MinEnergyPercent, k_MaxEnergyPercent);
                }

                m_EnergyPercent = value;
            }
        }

        protected Vehicle(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            for(int i = 0; i < i_NumberOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public virtual void Init(Dictionary<string, object> i_DataDictionary)
        {
            m_ModelName = (string)i_DataDictionary["modelName"];
            PlateNumber = (string)i_DataDictionary["plateNumber"];
            foreach(Wheel wheel in r_Wheels)
            {
                wheel.Init(i_DataDictionary);
            }
        }

        public void InflateWheels(float i_AmountToAdd)
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.Inflate(i_AmountToAdd);
            }
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> details = new Dictionary<string, VehicleBuilder.InsertDetails>();
            details.Add("modelName", new VehicleBuilder.InsertDetails("Please type your vehicle model name: ", typeof(string)));
            details.Add("plateNumber", new VehicleBuilder.InsertDetails("Please type your vehicle plate number: ", typeof(string)));
            foreach (KeyValuePair<string, VehicleBuilder.InsertDetails> detail in Wheel.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            return details;
        }

        public virtual void GetData(Dictionary<string, string> i_DataDictionary)
        {
            StringBuilder wheelsData = new StringBuilder();
            int i = 1;
            wheelsData.Append($"In the vehicle there are {r_Wheels.Count} wheels, and this is their data:");
            foreach(Wheel wheel in r_Wheels)
            {
                wheelsData.Append(Environment.NewLine);
                wheelsData.Append($"Wheel number {i} - {wheel.ToString()}");
                i++;
            }

            i_DataDictionary.Add("wheelsData", wheelsData.ToString());
            i_DataDictionary.Add("modelName", m_ModelName);
            i_DataDictionary.Add("energyPercents", $"{EnergyPercent:0.00}%");
            i_DataDictionary.Add("plateNumber", PlateNumber.ToString());
        }
    }
}
