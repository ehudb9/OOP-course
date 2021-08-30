using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        public enum eVehicleTypes
        {
            ElectricCar,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            FuelTruck,
        }

        public struct InsertDetails 
        {
            public InsertDetails(string i_Question, Type i_InputType)
            {
                Question = i_Question;
                InputType = i_InputType;
            }

            public string Question { get; set; }

            public Type InputType { get; set; }
        }

        public static Vehicle Create(eVehicleTypes i_UserVehicleChoice, Dictionary<string, object> i_VehicleDataLisDictionary)
        {
            Vehicle newVehicle = null;
            switch(i_UserVehicleChoice)
            {
                case eVehicleTypes.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;

                case eVehicleTypes.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle();
                    break;

                case eVehicleTypes.FuelCar:
                    newVehicle = new FuelCar();
                    break;

                case eVehicleTypes.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle();
                    break;

                case eVehicleTypes.FuelTruck:
                    newVehicle = new FuelTruck();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(i_UserVehicleChoice), i_UserVehicleChoice, null);
            }

            newVehicle.Init(i_VehicleDataLisDictionary);
            return newVehicle;
        }

        public static Dictionary<string, InsertDetails> CreateNeededDataList(eVehicleTypes i_UserVehicleChoice)
        {
            Dictionary<string, InsertDetails> insertedDetails = null;
            switch (i_UserVehicleChoice)
            {
                case eVehicleTypes.ElectricCar:
                    insertedDetails = ElectricCar.InsertDetails();
                    break;

                case eVehicleTypes.ElectricMotorcycle:
                    insertedDetails = ElectricMotorcycle.InsertDetails();
                    break;

                case eVehicleTypes.FuelCar:
                    insertedDetails = FuelCar.InsertDetails();
                    break;

                case eVehicleTypes.FuelMotorcycle:
                    insertedDetails = FuelMotorcycle.InsertDetails();
                    break;

                case eVehicleTypes.FuelTruck:
                    insertedDetails = FuelTruck.InsertDetails();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(i_UserVehicleChoice), i_UserVehicleChoice, null);
            }

            return insertedDetails;
        }
    }
}
