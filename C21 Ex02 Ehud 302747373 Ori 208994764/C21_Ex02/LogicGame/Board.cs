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
        private int[] m_RowsIndex;
        private int m_CurrentCellRowIndex = 0;
        private int m_CurrentCellColumnIndex = 0;


        public Board(int i_boardColumnSize, int i_boardRowSize)
        {
            m_boardCells = new BoardCell[i_boardRowSize, i_boardColumnSize];
            m_NumOfRows = i_boardRowSize;
            m_NumOfColumns = i_boardColumnSize;
            initializeBoard();
            m_RowsIndex = new int[m_NumOfColumns]; //Todo - Think that this is the right version and not array with size of m_NomOfRows
            resetColumnIndex();
        }

        private void initializeBoard()
        {
            for (int i = 0; i < m_NumOfRows; i++)
            {
                for (int j = 0; j < m_NumOfColumns; j++)
                {
                    m_boardCells[i, j] = new BoardCell();
                }
            }
        }

        private void resetColumnIndex()
        {
            for (int i = 0; i < m_RowsIndex.Length; i++)
            {
                m_RowsIndex[i] = m_NumOfRows;
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
       
        public void InsertCellToBoard(int i_column, eCellTokenValue i_playerTokenValue)
        {
            //Todo - Why we get 0 to i_column in the computer turn
            //if(i_column != 0)
            //{
                m_CurrentCellColumnIndex = i_column - 1;
                m_CurrentCellRowIndex = m_RowsIndex[m_CurrentCellColumnIndex] - 1;
                m_boardCells[m_CurrentCellRowIndex, m_CurrentCellColumnIndex].CellTokenValue = i_playerTokenValue;
                m_RowsIndex[m_CurrentCellColumnIndex]--;
           // }
            //else
           // {
           //     Console.WriteLine("Computer chose 0");
           // }
        }
        public bool IsFullColumn(int i_Column)
        {
            if(i_Column > m_NumOfColumns)
            {
                return false;
            }
            return m_RowsIndex[i_Column - 1] == 0;
        }
        public bool BoardIsFull()
        {
            foreach(int index in m_RowsIndex)
            {
                if(index != 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool HasWon(eCellTokenValue i_CellToken)
        {
            if (checkVertically(i_CellToken))  
            {
                return true;
            }
            
            if (checkHorizontally(i_CellToken))
            {
                return true;
            }
            
            if (checkDiagonallyDown(i_CellToken)) 
            {
                return true;
            }

            if(checkDiagonallyUp(i_CellToken))
            {
                return true;
            }

            return false;
        }

        private bool checkVertically(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int rowNum = m_CurrentCellRowIndex;
            while (rowNum < m_NumOfRows && prevValue == m_boardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue;
                rowNum++;
            }
            rowNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (rowNum >= 0 && prevValue == m_boardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue;
                rowNum--;
            }
            if (sameValueCounter == 4)
            {
                return true;
            }
            return false;
        }

        private bool checkHorizontally(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex;
            while (columnNum < m_NumOfColumns && prevValue == m_boardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue;
                columnNum++;
            }
            columnNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && prevValue == m_boardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue;
                columnNum--;
            }
            if (sameValueCounter == 4)
            {
                return true;
            }
            return false;
        }

        private bool checkDiagonallyDown(eCellTokenValue i_CellToken)
        {

            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex;
            int rowNum = m_CurrentCellRowIndex;

            while (columnNum < m_NumOfColumns && rowNum < m_NumOfRows && prevValue == m_boardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, columnNum].CellTokenValue;
                columnNum++;
                rowNum++;
            }
            columnNum = m_CurrentCellRowIndex - 1;
            rowNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && prevValue == m_boardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, columnNum].CellTokenValue;
                columnNum--;
                rowNum--;
            }
            if (sameValueCounter == 4)
            {
                return true;
            }
            return false;
        }

        private bool checkDiagonallyUp(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex;
            int rowNum = m_CurrentCellRowIndex;

            while (columnNum < m_NumOfColumns && rowNum >= 0 && prevValue == m_boardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, columnNum].CellTokenValue;
                columnNum++;
                rowNum--;
            }
            columnNum = m_CurrentCellRowIndex - 1;
            rowNum = m_CurrentCellRowIndex + 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && rowNum < m_NumOfRows && prevValue == m_boardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_boardCells[rowNum, columnNum].CellTokenValue;
                columnNum--;
                rowNum++;
            }
            if (sameValueCounter == 4)
            {
                return true;
            }
            return false;
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
                    eCellTokenValue cellValue = m_boardCells[i, j].CellTokenValue;
                    if(cellValue != eCellTokenValue.Empty)
                    {
                        char cellTokenIcon;
                        if(cellValue == eCellTokenValue.Player1)
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
