using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private const float k_MinAirOressure = 0;
        public float m_MaxAirPressure { get;}
        public float m_MinAirPressure = 0;

        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate()
        {

        }

        public string ToString()
        {
            return "";
        }
    }
}
