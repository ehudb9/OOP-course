using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
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
        private int pickRandomColumnNumber(Board i_gameBoard)
        {
            
            int chosenColumn = r_random.Next(0, m_maxChosenColumnVal);
            FieldInfo boardNumColumnInfo = typeof(GameRunner).GetField("m_sizeOfColumns");
            while (i_gameBoard.IsFullColumn(chosenColumn) && (isValidColumn(chosenColumn, (int)boardNumColumnInfo.GetValue(null), i_gameBoard)))
            {
                chosenColumn = r_random.Next(0, m_maxChosenColumnVal);
            }
            return chosenColumn;
        }

        public void MakeComputerMove(Board i_gameBoard)
        {
            int chosenColumn = pickRandomColumnNumber(i_gameBoard);
            i_gameBoard.InsertCellToBoard(chosenColumn, eCellTokenValue.Player2);
        }

        private static bool isValidColumn(int i_chosenColmn, int i_numOfColumns, Board i_gameBoard)
        {
            return i_chosenColmn > 0 && i_chosenColmn <= i_numOfColumns && !i_gameBoard.IsFullColumn(i_chosenColmn);
        }
    }
}
