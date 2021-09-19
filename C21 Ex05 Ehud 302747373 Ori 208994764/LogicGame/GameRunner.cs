using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGame
{
    public class GameRunner
    {
        public eBoardGameStatus m_BoardStatus = eBoardGameStatus.ContinuePlay;
        private eGameMode m_PlayerVsComputerMode = eGameMode.PlayerVsPlayer;
        private bool m_Turn = true;
        private const eCellTokenValue k_SignPlayer1 = eCellTokenValue.X;
        private const eCellTokenValue k_SignPlayer2 = eCellTokenValue.O;
        private Player m_PlayerOne = null, m_PlayerTwo = null;
        private ComputerPlayer m_ComputerPlayer = null;
        public int m_SizeOfColumns = 0;
        public int m_SizeOfRows = 0;
        public Board m_GameBoard = null;
        private eCellTokenValue m_CurrentPlayer = eCellTokenValue.Empty;
        public int m_CohsenColumn;
        public int m_CurrentRow;
        private int m_player2Score = 0;

        public GameRunner()
        {
        }

        public bool Turn
        {
            get => m_Turn;
            set
            {
                m_Turn = value;
            }
        }

        public string Player1Score
        {
            get => m_PlayerOne.Score.ToString();
        }

        public string Player2Score
        {
            get => m_player2Score.ToString();
        }

        public void InitGame(int i_BoardRowNumber, int i_BoardColNumber, eGameMode i_GameMode)
        {
            m_SizeOfColumns = i_BoardColNumber;
            m_SizeOfRows = i_BoardRowNumber;
            m_player2Score = 0;
            m_GameBoard = new Board(m_SizeOfColumns, m_SizeOfRows);
            m_PlayerOne = new Player(k_SignPlayer1);

            if (i_GameMode == eGameMode.PlayerVsComputer)
            {
                m_ComputerPlayer = new ComputerPlayer(k_SignPlayer2, m_SizeOfColumns);
            }
            else
            {
                m_PlayerTwo = new Player(k_SignPlayer2);
            }
        }

        public void ResetGame()
        {
            m_GameBoard.ResetBoard();
            m_BoardStatus = eBoardGameStatus.ContinuePlay;
        }

        public void PlayerMove()
        {
            m_GameBoard.InsertCellToBoard(m_CohsenColumn, m_Turn ? eCellTokenValue.X : eCellTokenValue.O);
            m_CurrentRow = m_GameBoard.CurrentRow[m_CohsenColumn-1];
        }

        public void ComputerMove()
        {
            m_CohsenColumn = m_ComputerPlayer.MakeComputerMove(m_GameBoard);
            m_CurrentRow = m_GameBoard.CurrentRow[m_CohsenColumn - 1];
        }
        
        public eBoardGameStatus CheckBoard()
        {
            if (m_GameBoard.HasWon(m_Turn ? eCellTokenValue.X : eCellTokenValue.O))
            {
                if (m_Turn)
                {
                    m_PlayerOne.Score++;
                }
                else
                {
                    m_player2Score++;
                }
                m_BoardStatus = eBoardGameStatus.Winner;
            }
            else if (m_GameBoard.BoardIsFull())
            {
                m_BoardStatus = eBoardGameStatus.Tie;
            }

            return m_BoardStatus;
        }
    }
}
