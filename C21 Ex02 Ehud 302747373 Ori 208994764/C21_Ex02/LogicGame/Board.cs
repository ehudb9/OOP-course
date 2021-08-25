namespace C21_Ex02.LogicGame
{
    public class Board
    {
        public int m_NumOfRows;
        public int m_NumOfColumns;
        public readonly BoardCell[,] r_BoardCells;
        private readonly int[] r_RowsIndex; 
        private int m_CurrentCellRowIndex = 0;
        private int m_CurrentCellColumnIndex = 0;
        private const int k_NumOfCellsToWin = 4;
        private bool v_HasWon = true; 

        public Board(int i_BoardColumnSize, int i_BoardRowSize)
        {
            r_BoardCells = new BoardCell[i_BoardRowSize, i_BoardColumnSize];
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
                    r_BoardCells[i, j] = new BoardCell();
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
            foreach (BoardCell cell in r_BoardCells)
            {
                cell.CellTokenValue = eCellTokenValue.Empty;
            }
            resetColumnIndex();
        }
       
        public void InsertCellToBoard(int i_Column, eCellTokenValue i_PlayerTokenValue)
        {
            m_CurrentCellColumnIndex = i_Column - 1;
            m_CurrentCellRowIndex = r_RowsIndex[m_CurrentCellColumnIndex] - 1;
            r_BoardCells[m_CurrentCellRowIndex, m_CurrentCellColumnIndex].CellTokenValue = i_PlayerTokenValue;
            r_RowsIndex[m_CurrentCellColumnIndex]--;
        }

        public bool IsFullColumn(int i_Column)
        {
            bool isColumnFull = i_Column <= m_NumOfColumns && r_RowsIndex[i_Column - 1] == 0 && (i_Column <= m_NumOfColumns);
            return isColumnFull;
        }

        public bool IsValidColumn(int i_Column)
        {
            return i_Column > 0 && i_Column <= m_NumOfColumns && !IsFullColumn(i_Column);
        }

        public bool BoardIsFull()
        {
            bool v_BoardIsFull = true;
            foreach(int index in r_RowsIndex)
            {
                if(index != 0)
                {
                    v_BoardIsFull = false;
                    break;
                }
            }
            return v_BoardIsFull;
        }
        
        public bool HasWon(eCellTokenValue i_CellToken)
        {
            v_HasWon = checkVertically(i_CellToken) || checkDiagonallyDown(i_CellToken) || checkHorizontally(i_CellToken) || checkDiagonallyUp(i_CellToken);
            return v_HasWon;
        }

        private bool checkVertically(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 1;
            bool foundSequenceVertically = true;
            eCellTokenValue prevValue = i_CellToken;
            int rowNum = m_CurrentCellRowIndex + 1;

            while (rowNum < m_NumOfRows && prevValue == r_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue;
                rowNum++;
            }

            rowNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (rowNum >= 0 && prevValue == r_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[rowNum, m_CurrentCellColumnIndex].CellTokenValue;
                rowNum--;
            }

            if (sameValueCounter < k_NumOfCellsToWin)
            {
                foundSequenceVertically = false;
            }

            return foundSequenceVertically;
            
        }

        private bool checkHorizontally(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 1;
            bool foundSequenceHorizontally = true;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex + 1;

            while (columnNum < m_NumOfColumns && prevValue == r_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue;
                columnNum++;
            }

            columnNum = m_CurrentCellColumnIndex - 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && prevValue == r_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[m_CurrentCellRowIndex, columnNum].CellTokenValue;
                columnNum--;
            }

            if (sameValueCounter < k_NumOfCellsToWin)
            {
                foundSequenceHorizontally = false;
            }

            return foundSequenceHorizontally;
        }

        private bool checkDiagonallyDown(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 1;
            bool foundSequenceDiagonallyDown = true;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex + 1;
            int rowNum = m_CurrentCellRowIndex + 1;

            while (columnNum < m_NumOfColumns && rowNum < m_NumOfRows && prevValue == r_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum++;
                rowNum++;
            }

            columnNum = m_CurrentCellColumnIndex - 1;
            rowNum = m_CurrentCellRowIndex - 1;
            prevValue = i_CellToken;
            while (columnNum >= 0 && rowNum >= 0 && prevValue == r_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum--;
                rowNum--;
            }

            if (sameValueCounter < k_NumOfCellsToWin)
            {
                foundSequenceDiagonallyDown = false;
            }

            return foundSequenceDiagonallyDown;
        }

        private bool checkDiagonallyUp(eCellTokenValue i_CellToken)
        {
            int sameValueCounter = 1;
            bool foundSequenceDiagonallyUp = true;
            eCellTokenValue prevValue = i_CellToken;
            int columnNum = m_CurrentCellColumnIndex + 1;
            int rowNum = m_CurrentCellRowIndex - 1;

            while (columnNum < m_NumOfColumns && rowNum >= 0 && prevValue == r_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum++;
                rowNum--;
            }

            columnNum = m_CurrentCellColumnIndex - 1;
            rowNum = m_CurrentCellRowIndex + 1;
            prevValue = i_CellToken;
            while(columnNum >= 0 && rowNum < m_NumOfRows && prevValue == r_BoardCells[rowNum, columnNum].CellTokenValue)
            {
                sameValueCounter++;
                prevValue = r_BoardCells[rowNum, columnNum].CellTokenValue;
                columnNum--;
                rowNum++;
            }

            if (sameValueCounter < k_NumOfCellsToWin)
            {
                foundSequenceDiagonallyUp = false;
            }

            return foundSequenceDiagonallyUp;
        }
    }
}
