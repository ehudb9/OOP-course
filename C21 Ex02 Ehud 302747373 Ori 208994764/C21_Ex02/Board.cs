using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C21_Ex02.ConsoleUI;


namespace C21_Ex02
{
    public enum BoardCellValue
    {
        Player1,
        Player2,
        Empty
    }
    class Board
    {
        public readonly int m_NumOfRows;
        public readonly int m_NumOfColumns;
        private readonly BoardCellValue[,] m_boardCells;
        public Board()
        {
           

        }
        public static void SetBoard()
        {
            Prints.WelcomeMessage();
            int m_NumOfColumns = int.Parse(Console.ReadLine());
            int m_NumOfRows = int.Parse(Console.ReadLine());

            //m_boardCells = new BoardCellValue[m_NumOfRows, m_NumOfColumns];
        }


        public static void ShowBoard()
        { 
            ///TBC
        }

    }

}

