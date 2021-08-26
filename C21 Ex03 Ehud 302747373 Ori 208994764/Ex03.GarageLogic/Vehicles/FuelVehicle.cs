using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;
        private float m_CurrentFuelAmountInLiter;
        private readonly float r_MaxFuelAmountInLiter;
        private const float k_MinFuelAmountInLiter = 0;

        protected FuelVehicle(eFuelType i_FuelType, float i_MaxFuelAmountInLiter, int i_NumberOfWheels, float i_MaxAirPressure) : base (i_NumberOfWheels, i_MaxAirPressure)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelAmountInLiter = i_MaxFuelAmountInLiter;
        }

        public void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException($"This vehicle runs on {r_FuelType.ToString()} only");
            } //Todo - Need else statement?

            CurrentFuelAmountInLiter += i_AmountToAdd;
        }

        public float CurrentFuelAmountInLiter
        {
            get => m_CurrentFuelAmountInLiter;
            set
            {
                if (value > r_MaxFuelAmountInLiter || value < k_MinFuelAmountInLiter)
                {
                    throw new ValueOutOfRangeException($"You cant put {value} liters in this vehicle", k_MinFuelAmountInLiter, r_MaxFuelAmountInLiter);
                }

                EnergyPercent = (value / r_MaxFuelAmountInLiter) * 100;
                m_CurrentFuelAmountInLiter = value;
            }
        }

        public static Dictionary<string, VehicleBuilder.InsertDetails> InsertDetails()
        {
            Dictionary<string, VehicleBuilder.InsertDetails> details = new Dictionary<string, VehicleBuilder.InsertDetails>();
            details.Add("currentFuelAmountInLiter", new VehicleBuilder.InsertDetails("Please type the current fuel amount in liters: ", typeof(float)));
            return details;
        }

        public void GetData(Dictionary<string, string> i_DataDictionary)
        {
            base.GetData(i_DataDictionary); //Todo - write GetData method in Vehicle class
            i_DataDictionary.Add("fuelType", r_FuelType.ToString());
            i_DataDictionary.Add("currentFuelAmountInLiter", m_CurrentFuelAmountInLiter.ToString());
            i_DataDictionary.Add("maxFuelAmountInLiter", r_MaxFuelAmountInLiter.ToString());
        }
    }
}
