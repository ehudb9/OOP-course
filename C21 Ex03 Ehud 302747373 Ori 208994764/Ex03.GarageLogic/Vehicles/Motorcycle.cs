using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle
    {
        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        readonly int r_EngieneCapacityInCC;
        readonly eLicenseType r_LicenseType;
        bool m_IsElecric;  //why not readonly and why here?

        public Motorcycle()
        {

        }

    }
}
