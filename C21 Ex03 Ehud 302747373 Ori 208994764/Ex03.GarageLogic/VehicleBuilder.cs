using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        enum eVehicleTypes
        {
            ElectricCar,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            FuelTruck,
        }

        public struct InsertDetails //Todo - Think to change this name
        {
            public InsertDetails(string i_Question, Type i_InputType)
            {
                Question = i_Question;
                InputType = i_InputType;
            }

            public string Question { get; set; }

            public Type InputType { get; set; }
        }

        public Vehicle Create()
        {
            return new Vehicle();
        }
    }
}
