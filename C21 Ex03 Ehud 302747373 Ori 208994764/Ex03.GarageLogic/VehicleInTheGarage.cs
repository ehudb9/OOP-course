using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInTheGarage
    {
        private readonly Owner r_VehicleOwner;
        public Vehicle Vehicle { get; }

        public GarageManager.eGarageVehicleStatus VehicleStatus { get; set; }

        public VehicleInTheGarage(Owner i_Owner, Vehicle i_Vehicle)
        {
            r_VehicleOwner = i_Owner;
            Vehicle = i_Vehicle;
            VehicleStatus = GarageManager.eGarageVehicleStatus.InRepair;
        }

        public string GetPlateNumber()
        {
            return Vehicle.PlateNumber;
        }

        public virtual void GetData(Dictionary<string, string> i_DataDictionary)
        {
            r_VehicleOwner.GetData(i_DataDictionary);
            Vehicle.GetData(i_DataDictionary);
            i_DataDictionary.Add("vehicleStatus", VehicleStatus.ToString());
        }
    }
}
