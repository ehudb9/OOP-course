using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGame
{
    class ComputerPlayer
    {
        public eCellTokenValue Sign { get; }
        private int m_Score;
        private readonly int r_MaxChosenColumnVal;
        private readonly Random r_Random;

        public ComputerPlayer(eCellTokenValue i_Sign, int i_MaxChosenColumnVal)
        {
            m_Score = 0;
            Sign = i_Sign;
            r_MaxChosenColumnVal = i_MaxChosenColumnVal + 1;
            r_Random = new Random();
        }
        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }
        private int pickRandomColumnNumber(Board i_GameBoard)
        {
            int chosenColumn = r_Random.Next(1, r_MaxChosenColumnVal);
            while (i_GameBoard.IsFullColumn(chosenColumn))
            {
                chosenColumn = r_Random.Next(1, r_MaxChosenColumnVal);
            }
            Console.WriteLine(chosenColumn);
            return chosenColumn;
        }

        public int MakeComputerMove(Board i_GameBoard)
        {
            int chosenColumn = pickRandomColumnNumber(i_GameBoard);
            i_GameBoard.InsertCellToBoard(chosenColumn, eCellTokenValue.O);
            
            return chosenColumn;
        }

        private static bool isValidColumn(int i_ChosenColumn, int i_NumOfColumns, Board i_GameBoard)
        {
            return i_ChosenColumn > 0 && i_ChosenColumn <= i_NumOfColumns && !i_GameBoard.IsFullColumn(i_ChosenColumn);
        }
    }
}
