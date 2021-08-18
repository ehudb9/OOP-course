using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02.LogicGame
{
    class ComputerPlayer
    {
        public int Sign { get; }
        private int m_Score;
        private readonly int m_maxChosenColumnVal;

        public ComputerPlayer(int i_sign, int i_maxChosenColumnVal)
        {
            m_Score = 0;
            Sign = i_sign;
        }

        public static int PickColumnNumber()
        {
            return 0;
        }
    }
}
