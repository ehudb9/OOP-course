using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private const float k_MinBatteryTimeInHours = 0;
        private float m_BatteryTimeRemainInHours = 0;
        public float MaxBatteryTimeInHours { get; }

        public float BatteryTimeRemainInHours
        {
            get => m_BatteryTimeRemainInHours;

            set
            {
                if (value > MaxBatteryTimeInHours || value < k_MinBatteryTimeInHours)
                {
                    throw new ValueOutOfRangeException($"You cant charge your vehicle to {value} remain hours.", k_MinBatteryTimeInHours, MaxBatteryTimeInHours);
                }

                m_BatteryTimeRemainInHours = value;
                EnergyPercent = (value / MaxBatteryTimeInHours) * 100;
            }
        }

        protected ElectricVehicle(float i_MaxBatteryTimeInHours, int i_NumberOfWheels, float i_MaxAirPressure) : base(i_NumberOfWheels, i_MaxAirPressure)
        {
            MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
        }

        public void Recharge(float i_AmountToAdd)
        {
            BatteryTimeRemainInHours += i_AmountToAdd;
        }

        public override void Init(Dictionary<string, object> i_DataDictionary)
        {
            BatteryTimeRemainInHours = (float)i_DataDictionary["currentFuelAmountInLiter"];
            EnergyPercent = (m_BatteryTimeRemainInHours / MaxBatteryTimeInHours) * 100;
            base.Init(i_DataDictionary);
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> details = new Dictionary<string, VehicleBuilder.InsertDetails>();
            details.Add("batteryTimeRemainInHours", new VehicleBuilder.InsertDetails("Please type the current battery remain time in hours: ", typeof(float)));
            foreach (var detail in Vehicle.InsertDetails())
            {
                details.Add(detail.Key, detail.Value);
            }

            return details;
        }

        public override void GetData(Dictionary<string, string> i_DataDictionary)
        {
            base.GetData(i_DataDictionary);
            i_DataDictionary.Add("batteryTimeRemainInHours", BatteryTimeRemainInHours.ToString());
            i_DataDictionary.Add("maxBatteryTimeInHours", MaxBatteryTimeInHours.ToString());
        }
    }
}
