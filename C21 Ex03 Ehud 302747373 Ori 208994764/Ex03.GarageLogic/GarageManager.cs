using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        public enum eGarageVehicleStatus
        {
            InRepair,
            Repaired,
            Paid
        }

        private readonly Dictionary<string, VehicleInTheGarage> r_VehicleInTheGarageDictionary;

        public GarageManager()
        {
            r_VehicleInTheGarageDictionary = new Dictionary<string, VehicleInTheGarage>();
        }

        public void InsertNewVehicle(Vehicle i_VehicleToInsert, Owner i_NewVehicleOwner)
        {
            if(r_VehicleInTheGarageDictionary.ContainsKey(i_VehicleToInsert.PlateNumber))
            {
                r_VehicleInTheGarageDictionary[i_VehicleToInsert.PlateNumber].VehicleStatus = eGarageVehicleStatus.InRepair; 
                throw new ArgumentException("This vehicle is already in the garage");
            }

            r_VehicleInTheGarageDictionary.Add(i_VehicleToInsert.PlateNumber, new VehicleInTheGarage(i_NewVehicleOwner, i_VehicleToInsert));
        }

        public void PresentVehiclesInTheGarageList(List<string> i_VehiclesPlateNumber)
        {
            foreach(KeyValuePair<string, VehicleInTheGarage> vehicleInTheGarage in r_VehicleInTheGarageDictionary)
            {
                i_VehiclesPlateNumber.Add(vehicleInTheGarage.Value.GetPlateNumber());
            }
        }

        public void PresentVehiclesInTheGarageListFiltered(List<string> i_VehiclesPlateNumber, GarageManager.eGarageVehicleStatus i_FilerStatusBy)
        {
            foreach(KeyValuePair<string, VehicleInTheGarage> vehicleInTheGarage in r_VehicleInTheGarageDictionary)
            {
                if(vehicleInTheGarage.Value.VehicleStatus == i_FilerStatusBy)
                {
                    i_VehiclesPlateNumber.Add(vehicleInTheGarage.Value.GetPlateNumber());
                }
            }
        }

        public void EditVehicleStatus(string i_VehiclePlateNumber, eGarageVehicleStatus i_VehicleNewStatus)
        {
            getVehicleInGarage(i_VehiclePlateNumber, out VehicleInTheGarage vehicleInTheGarage);
            vehicleInTheGarage.VehicleStatus = i_VehicleNewStatus;
        }

        public void InflateVehicleTires(string i_VehiclePlateNumber, float i_AmountToInflate)
        {
            getVehicleInGarage(i_VehiclePlateNumber, out VehicleInTheGarage vehicleInTheGarage);
            vehicleInTheGarage.Vehicle.InflateWheels(i_AmountToInflate);
        }

        public void RefuelVehicle(string i_VehiclePlateNumber, FuelVehicle.eFuelType i_TypeOfFuel, float i_AmountOfFuel)
        {
            getVehicleInGarage(i_VehiclePlateNumber, out VehicleInTheGarage vehicleInTheGarage);
            if (vehicleInTheGarage.Vehicle is FuelVehicle fuelVehicle)
            {
                fuelVehicle.Refuel(i_AmountOfFuel, i_TypeOfFuel);
            }
            else
            {
                throw new ArgumentException("You have an error! This vehicle is not fuel based vehicle");
            }
        }

        public void RechargeVehicle(string i_VehiclePlateNumber, float i_AmountOfMinutesForCharge)
        {
            getVehicleInGarage(i_VehiclePlateNumber, out VehicleInTheGarage vehicleInTheGarage);
            if (vehicleInTheGarage.Vehicle is ElectricVehicle fuelVehicle)
            {
                fuelVehicle.Recharge(i_AmountOfMinutesForCharge);
            }
            else
            {
                throw new ArgumentException("You have an error! This vehicle is not electric based vehicle");
            }
        }

        public Dictionary<string, string> ShowVehicleData(string i_VehiclePlateNumber)
        {
            Dictionary<string, string> vehicleDataDictionary = new Dictionary<string, string>();
            getVehicleInGarage(i_VehiclePlateNumber, out VehicleInTheGarage vehicleInTheGarage);
            vehicleInTheGarage.GetData(vehicleDataDictionary);
            return vehicleDataDictionary;
        }

        public eGarageVehicleStatus GetVehicleStatus(string i_VehiclePlateNumber)
        {
            getVehicleInGarage(i_VehiclePlateNumber, out VehicleInTheGarage vehicleInTheGarage);
            return vehicleInTheGarage.VehicleStatus;
        }

        private void getVehicleInGarage(string i_VehiclePlateNumber, out VehicleInTheGarage i_VehicleInTheGarage)
        {
            if (!r_VehicleInTheGarageDictionary.TryGetValue(i_VehiclePlateNumber, out i_VehicleInTheGarage))
            {
                throw new ArgumentException("The required vehicle not found");
            }
        }
    }
}
