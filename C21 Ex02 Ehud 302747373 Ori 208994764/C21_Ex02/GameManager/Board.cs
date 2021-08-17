using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02.GameManager
{
    public class Board
    {
        private readonly BoardCell[,] m_boardCells;

        public Board(int i_boardColumnSize, int i_boardRowSize)
        {
            m_boardCells = new BoardCell[i_boardColumnSize, i_boardRowSize];
        }
    }
}
