using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGame
{
    class Player
    {
        public int Sign { get; }
        private int m_Score;

        public Player(int i_Sign)
        {
            m_Score = 0;
            Sign = i_Sign;
        }
        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }
    }
}
