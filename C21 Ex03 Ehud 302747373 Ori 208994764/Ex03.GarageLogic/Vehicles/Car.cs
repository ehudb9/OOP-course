using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car
    {
        public enum eDoorNumber
        {
            Two,
            Three,
            Four,
            Five
        }
        
        public enum eColors
        {
            Yellow,
            White,
            Black,
            Blue,
        }

        readonly eColors r_Color;
        readonly eDoorNumber r_DoorNumber; // NumberOfDoors better name
        readonly bool r_IsElectric; //Why not in Vehicle- why here 

        public Char()
        {

        }

    }
}
