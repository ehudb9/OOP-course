using System;
using System.Text;

namespace C21_Ex02.LogicGame
{
    /// <summary>
    /// Create and initialize the board and check its status
    /// </summary>
    public class Board
    {
        public int m_NumOfRows;
        public int m_NumOfColumns;
        private readonly BoardCell[,] m_boardCells;

        public Board(int i_boardColumnSize, int i_boardRowSize)
        {
            m_boardCells = new BoardCell[i_boardRowSize, i_boardColumnSize];
            m_NumOfRows = i_boardRowSize;
            m_NumOfColumns = i_boardColumnSize;
        }

        public void InitializeBoard()
        {
            foreach (BoardCell cell in m_boardCells)
            {
                cell.CellTokenValue = eCellTokenValue.Empty;
                {
                    m_boardCells[i, j] = new BoardCell();
                }
            }
        }

        public bool CanAddInColumn(int i_column)
        {
            return m_boardCells[0, i_column].CellTokenValue == eCellTokenValue.Empty;
        }

        public void InsertCellToBoard(int i_column, eCellTokenValue i_playerTokenValue)
        {
            int potentialRowToAdd = 0;

            while((potentialRowToAdd < m_NumOfRows - 1)
                  && (m_boardCells[potentialRowToAdd + 1, i_column].CellTokenValue == eCellTokenValue.Empty))
            {
                potentialRowToAdd = potentialRowToAdd + 1;
            }

            m_boardCells[potentialRowToAdd, i_column].CellTokenValue = i_playerTokenValue;
        }

        public bool HasWon(eCellTokenValue i_CellToken)
        {
            for(int i = 0; i < m_NumOfRows; i ++)
            {
                for(int j = 0; j < m_NumOfColumns; j++)
                {
                    if(checkVertically(i, j, i_CellToken))
                    {
                        return true;
                    }
                    if (checkHorizontally(i, j, i_CellToken))
                    {
                        return true;
                    }
                    if (checkDiagonallyDown(i, j, i_CellToken))
                    {
                        return true;
                    }
                    if (checkDiagonallyUp(i, j, i_CellToken))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool checkVertically(int i_row, int i_column, eCellTokenValue i_CellToken)
        {
            if(i_row + 3 >= m_NumOfRows)
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if(m_boardCells[i_row + i, i_column].CellTokenValue != i_CellToken)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkHorizontally(int i_row, int i_column, eCellTokenValue i_CellToken)
        {
            if (i_column + 3 >= m_NumOfColumns)
            {
                return false;
            }

            for (int i = 0; i < 4; i++)
            {
                if (m_boardCells[i_row, i_column + i].CellTokenValue != i_CellToken)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkDiagonallyDown(int i_row, int i_column, eCellTokenValue i_CellToken)
        {
            if (i_row + 3 >= m_NumOfRows)
            {
                return false;
            }

            if (i_column + 3 >= m_NumOfColumns)
            {
                return false;
            }

            for (int i = 0; i < 4; i++)
            {
                if (m_boardCells[i_row + i, i_column + i].CellTokenValue != i_CellToken)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkDiagonallyUp(int i_row, int i_column, eCellTokenValue i_CellToken)
        {
            if (i_row - 3 < 0)
            {
                return false;
            }

            if (i_column + 3 >= m_NumOfColumns)
            {
                return false;
            }

            for (int i = 0; i < 4; i++)
            {
                if (m_boardCells[i_row - i, i_column + i].CellTokenValue != i_CellToken)
                {
                    return false;
                }
            }
            return true;
        }

        public void ShowBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();

            StringBuilder visualBoard = new StringBuilder();
            for(int i = 0; i < m_NumOfRows; i++)
            {
                visualBoard.AppendFormat("   {0}", i + 1);
            }

            visualBoard.AppendLine();

            for(int i = 0; i < m_NumOfRows; i++)
            {
                visualBoard.AppendFormat("{0}|", i + 1);

                for(int j = 0; j < m_NumOfColumns; j++)
                {
                    int cellValue = (int) m_boardCells[i, j].CellTokenValue;
                    if(cellValue != 0)
                    {
                        char cellTokenIcon;
                        if(cellValue == 1)
                        {
                            cellTokenIcon = 'X';
                        }
                        else
                        {
                            cellTokenIcon = 'O';
                        }
                        visualBoard.AppendFormat(" {0} |", cellTokenIcon);
                    }
                    else
                    {
                        visualBoard.AppendFormat("   |");
                    }
                }

                visualBoard.AppendLine();
                visualBoard.Append(" ");
                visualBoard.Append('=', m_NumOfColumns * 4);
                visualBoard.Append("\n");
            }
            Console.WriteLine(visualBoard.ToString());
        }
    }
}
