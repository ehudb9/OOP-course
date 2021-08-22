using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02.LogicGame
{
    public class ComputerPlayer
    {
        public int Sign { get; }
        private int m_Score;
        private readonly int m_maxChosenColumnVal;
        private readonly Random r_random;

        public ComputerPlayer(int i_Sign, int i_MaxChosenColumnVal)
        {
            m_Score = 0;
            Sign = i_Sign;
            m_maxChosenColumnVal = i_MaxChosenColumnVal + 1;
            r_random = new Random();
        }
        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }
        private int pickRandomColumnNumber(Board i_GameBoard)
        {
            int chosenColumn = r_random.Next(1, m_maxChosenColumnVal);
            while (i_GameBoard.IsFullColumn(chosenColumn))
            {
                chosenColumn = r_random.Next(1, m_maxChosenColumnVal);
            }
            Console.WriteLine(chosenColumn);
            return chosenColumn;
        }

        public void MakeComputerMove(Board i_GameBoard)
        {
            int chosenColumn = pickRandomColumnNumber(i_GameBoard);
            i_GameBoard.InsertCellToBoard(chosenColumn, eCellTokenValue.Player2);
        }

        private static bool isValidColumn(int i_ChosenColumn, int i_NumOfColumns, Board i_GameBoard)
        {
            return i_ChosenColumn > 0 && i_ChosenColumn <= i_NumOfColumns && !i_GameBoard.IsFullColumn(i_ChosenColumn);
        }
    }
}
