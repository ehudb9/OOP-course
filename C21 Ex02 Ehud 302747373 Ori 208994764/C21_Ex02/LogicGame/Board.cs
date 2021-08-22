using System;
using System.Text;

namespace C21_Ex02.LogicGame
{
    /// <summary>
    /// Create and initialize the board and check its status
    /// </summary>
    public class Board
    {
        //Todo - try to understand if when we use bool variable 
        public int m_NumOfRows;
        public int m_NumOfColumns;
        public readonly BoardCell[,] m_BoardCells;
        private readonly int[] r_RowsIndex; //Todo - Changed to readonly member
        private int m_CurrentCellRowIndex = 0;
        private int m_CurrentCellColumnIndex = 0;
        private bool v_HasWon = true; //Todo - why this member doesn't start with m_?

        public Board(int i_BoardColumnSize, int i_BoardRowSize)
        {
            m_BoardCells = new BoardCell[i_BoardRowSize, i_BoardColumnSize];
            m_NumOfRows = i_BoardRowSize;
            m_NumOfColumns = i_BoardColumnSize;
            initializeBoard();
            r_RowsIndex = new int[m_NumOfColumns];
            resetColumnIndex();
        }

        private void initializeBoard()
        {
            for (int i = 0; i < m_NumOfRows; i++)
            {
                for (int j = 0; j < m_NumOfColumns; j++)
                {
                    m_BoardCells[i, j] = new BoardCell();
                }
            }
        }

        private void resetColumnIndex()
        {
            for (int i = 0; i < r_RowsIndex.Length; i++)
            {
                r_RowsIndex[i] = m_NumOfRows;
            }
        }

        public void ResetBoard()
        {
            foreach (BoardCell cell in m_BoardCells)
            {
                cell.CellTokenValue = eCellTokenValue.Empty;
            }
            resetColumnIndex();
        }
       
        public void InsertCellToBoard(int i_Column, eCellTokenValue i_PlayerTokenValue)
        {
            m_CurrentCellColumnIndex = i_Column - 1;
            m_CurrentCellRowIndex = r_RowsIndex[m_CurrentCellColumnIndex] - 1;
            m_BoardCells[m_CurrentCellRowIndex, m_CurrentCellColumnIndex].CellTokenValue = i_PlayerTokenValue;
            r_RowsIndex[m_CurrentCellColumnIndex]--;
        }
        public bool IsFullColumn(int i_Column)
        {
            return r_RowsIndex[i_Column - 1] == 0 && (i_Column <= m_NumOfColumns);
        }

        public bool BoardIsFull()
        {
            bool v_BoardIsNotFull = true;
            foreach(int index in r_RowsIndex)
            {
                if(index != 0)
                {
                    return v_BoardIsNotFull; 
                }
            }
            return !v_BoardIsNotFull;
        }
        
        public bool HasWon(eCellTokenValue i_CellToken)
        {
            if (checkVertically(i_CellToken) || checkDiagonallyDown(i_CellToken))  
            {
                return v_HasWon;
            }
            
            else if (checkHorizontally(i_CellToken) || checkDiagonallyUp(i_CellToken))
            {
                return v_HasWon;
            }
            
            return !v_HasWon;
        }

        private bool checkVertically(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int rowNum = m_CurrentCellRowIndex;
            while (rowNum < m_NumOfRows && prevValue == m_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue;
                rowNum++;
            }
            rowNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (rowNum >= 0 && prevValue == m_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue;
                rowNum--;
            }
            if (sameValueCounter == 4)
            {
                return v_HasWon;
            }
            return !v_HasWon;
        }

        private bool checkHorizontally(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex;
            while (columnNum < m_NumOfColumns && prevValue == m_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue;
                columnNum++;
            }
            columnNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && prevValue == m_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue;
                columnNum--;
            }
            if (sameValueCounter == 4)
            {
                return v_HasWon;
            }
            return !v_HasWon;
        }

        private bool checkDiagonallyDown(eCellTokenValue i_CellToken)
        {

            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex;
            int rowNum = m_CurrentCellRowIndex;

            while (columnNum < m_NumOfColumns && rowNum < m_NumOfRows && prevValue == m_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum++;
                rowNum++;
            }
            columnNum = m_CurrentCellRowIndex - 1;
            rowNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && prevValue == m_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum--;
                rowNum--;
            }
            if (sameValueCounter == 4)
            {
                return v_HasWon;
            }
            return !v_HasWon;
        }

        private bool checkDiagonallyUp(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 0;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex;
            int rowNum = m_CurrentCellRowIndex;

            while (columnNum < m_NumOfColumns && rowNum >= 0 && prevValue == m_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum++;
                rowNum--;
            }
            columnNum = m_CurrentCellRowIndex - 1;
            rowNum = m_CurrentCellRowIndex + 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && rowNum < m_NumOfRows && prevValue == m_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = m_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum--;
                rowNum++;
            }
            if (sameValueCounter == 4)
            {
                return v_HasWon;
            }
            return !v_HasWon;
        }
        // move to different module
        //Todo - think we need to move it to the Prints module
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
                    eCellTokenValue cellValue = m_BoardCells[i, j].CellTokenValue;
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
