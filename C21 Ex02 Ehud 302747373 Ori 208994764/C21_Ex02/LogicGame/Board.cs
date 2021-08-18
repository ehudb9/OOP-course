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
        private int[] m_ColumnsIndex;

        public Board(int i_boardColumnSize, int i_boardRowSize)
        {
            m_boardCells = new BoardCell[i_boardRowSize, i_boardColumnSize];
            m_NumOfRows = i_boardRowSize;
            m_NumOfColumns = i_boardColumnSize;
            m_ColumnsIndex = new int[m_NumOfRows];
            resetColumnIndex();
        }

        private void resetColumnIndex()
        {
            for (int i = 0; i < m_ColumnsIndex.Length; i++)
            {
                m_ColumnsIndex[i] = m_NumOfRows;
            }
        }
        public void ResetBoard()
        {
            foreach (BoardCell cell in m_boardCells)
            {
                cell.CellTokenValue = eCellTokenValue.Empty;
            }
            resetColumnIndex();
        }

        //FOR WHAT??
        public bool CanAddInColumn(int i_column)
        {
            return m_boardCells[0, i_column].CellTokenValue == eCellTokenValue.Empty;
        }
        ///WHAT????
        public void InsertCellToBoard(int i_column, eCellTokenValue i_playerTokenValue)
        {
            //how to set the value of the cell

            /*
            int potentialRowToAdd = 0;

            while((potentialRowToAdd < m_NumOfRows - 1)
                  && (m_boardCells[potentialRowToAdd + 1, i_column].CellTokenValue == eCellTokenValue.Empty))
            {
                potentialRowToAdd = potentialRowToAdd + 1;
            }
            */
            m_boardCells[m_ColumnsIndex[i_column - 1], i_column].CellTokenValue = i_playerTokenValue;
            m_ColumnsIndex[i_column - 1]--;
        }
        public bool IsFullColumn(int i_Column)
        {
            return m_ColumnsIndex[i_Column] == 0;
        }
        public bool BoardIsFull()
        {
            foreach (int i in m_ColumnsIndex)
            {
                if (i > 0)
                {
                    return false;
                }
                
            }
            return true;
        }
        
        ///=================================================================================================//
        ///all wrong!!!//
        ///most be changed!
        public bool HasWon(eCellTokenValue i_CellToken)
        {
            
            //HOW to get the current cell index????????????
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

            //////////////
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int rowNum = i_row;
            while (rowNum < m_NumOfRows && prevValue == m_boardCells[rowNum++, i_column].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, i_column].CellTokenValue;
            }
            while(rowNum>0 && prevValue == m_boardCells[rowNum--, i_column].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, i_column].CellTokenValue;
            }
            if (sameValueCounter == 4)
            {
                return true;
            }
            return false;
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
            
            
            //////////////
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = i_column;
            while (columnNum < m_NumOfRows && prevValue == m_boardCells[i_row++, columnNum++].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[i_row, i_column].CellTokenValue;
            }
            while (columnNum > 0 && prevValue == m_boardCells[i_row, columnNum--].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[i_row, columnNum].CellTokenValue;
            }
            if (sameValueCounter == 4)
            {
                return true;
            }
            return false;
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
