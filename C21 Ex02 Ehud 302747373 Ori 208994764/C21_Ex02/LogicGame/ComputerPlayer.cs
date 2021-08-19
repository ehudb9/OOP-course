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
        private readonly Random r_random;

        public ComputerPlayer(int i_sign, int i_maxChosenColumnVal)
        {
            m_Score = 0;
            Sign = i_sign;
            m_maxChosenColumnVal = i_maxChosenColumnVal;
            r_random = new Random();
        }
        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }
        private int pickRandomColumnNumber(Board i_GameBoard)
        {
            
            int chosenColumn = r_random.Next(0, m_maxChosenColumnVal);
            while (i_GameBoard.IsFullColumn(chosenColumn))
            {
                chosenColumn = r_random.Next(0, m_maxChosenColumnVal);
            }
            return chosenColumn;
        }

        public void MakeComputerMove(Board i_GameBoard)
        {
            int chosenColumn = pickRandomColumnNumber(i_GameBoard);
            i_GameBoard.InsertCellToBoard(chosenColumn, eCellTokenValue.Player2);
        }
    }
}
