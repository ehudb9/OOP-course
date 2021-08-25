using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle //Todo - Think if this class need to be an abstract class or static class
    {
        string m_ModelName;
        string m_PlateNumber;
        float m_EnergyPrecent;
        readonly List<Wheel> r_Wheels;

        public Vehicle()
        {
            
        }

        public float EnergyPercent
        {
            get => m_EnergyPrecent;
            set
            {

            }
        }
    }
}
