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
        public bool v_GameIsAlive = false;
        public bool v_PlayerWantsToQuitGame = false;
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
        public bool v_IsPlayerMoved = false;


        public GameRunner()
        {
            v_GameIsAlive = true;
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
            get
            {
                string score = "0";
                if (m_PlayerVsComputerMode == eGameMode.PlayerVsPlayer)
                {
                    if (m_PlayerTwo != null)
                    {
                        score = m_PlayerTwo.Score.ToString();
                    }
                }
                else
                {
                    if (m_ComputerPlayer != null)
                    {
                        score = m_ComputerPlayer.Score.ToString();
                    }
                }
                return score;
            }
        }

        public string SymbolPlayer
        {
            get => m_CurrentPlayer.ToString();
        }

        public void InitGame(int i_BoardRowNumber, int i_BoardColNumber, eGameMode i_GameMode)
        {
            m_SizeOfColumns = i_BoardColNumber;
            m_SizeOfRows = i_BoardRowNumber;
            
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
            v_GameIsAlive = true;
            v_PlayerWantsToQuitGame = false;
            m_BoardStatus = eBoardGameStatus.ContinuePlay;
        }

        public void Run()
        {
            Console.WriteLine("RUNNNN"); // ---D
            
            
            /*while (v_GameIsAlive)
            {
                //ShowBoardUI.ShowBoard(m_GameBoard); ///d

                if (m_Turn)
                {
                        m_CurrentPlayer = eCellTokenValue.X;
                        //ConsolePrinter.Player1PlayNowMessage(); ///D
                        PlayerMove();                       
                }
                else if (m_PlayerVsComputerMode == eGameMode.PlayerVsComputer)
                {
                    m_CurrentPlayer = eCellTokenValue.O;
                    m_CohsenColumn = m_ComputerPlayer.MakeComputerMove(m_GameBoard);
                }
                else
                {
                    m_CurrentPlayer = eCellTokenValue.O;
                    //ConsolePrinter.Player2PlayNowMessage();   //// D
                    PlayerMove();
                }

                //ShowBoardUI.ShowBoard(m_GameBoard);   ////  D

                if (m_GameBoard.HasWon(m_CurrentPlayer)) // fit it 
                {
                    //ConsolePrinter.PrintWinner(m_CurrentPlayer);   //// TBC ---  widow print of winner with the UI
                    if (m_CurrentPlayer == eCellTokenValue.X)
                    {
                        m_PlayerOne.Score++;
                    }
                    else
                    {
                        if (m_PlayerVsComputerMode == eGameMode.PlayerVsPlayer)
                        {
                            m_PlayerTwo.Score++;
                        }
                        else
                        {
                            m_ComputerPlayer.Score++;
                        }
                    }

                    printCurrentScore();   ////////TBC  update the form lable with the scores
                    endGame();
                }
                else if (m_GameBoard.BoardIsFull())
                {
                    //ConsolePrinter.ItsATie(); //TBC -- Tie dialog
                    printCurrentScore();     //// TBC ---  widow print of winner with the UI
                    endGame();
                }

                m_Turn = !m_Turn;
            }*/

            //ConsolePrinter.ExitGameMessage();       ///// D
            // Console.ReadLine();       /////D
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
                    if (m_PlayerVsComputerMode == eGameMode.PlayerVsPlayer)
                    {
                        if(m_PlayerTwo != null)
                        {
                            m_PlayerTwo.Score++;
                        }
                    }
                    else
                    {
                        if (m_ComputerPlayer != null)
                        {
                            m_ComputerPlayer.Score++;
                        }
                    }
                }
                m_BoardStatus = eBoardGameStatus.Winner;
            }
            else if (m_GameBoard.BoardIsFull())
            {
                m_BoardStatus = eBoardGameStatus.Tie;
            }
            return m_BoardStatus;
        }
        private void printCurrentScore()    // TBC - --- send to the lable the value of the scores
        {
            //ConsolePrinter.PrintCurrentPlayerScore(m_PlayerOne.Score, m_PlayerVsComputerMode == eGameMode.PlayerVsPlayer ? m_PlayerTwo.Score : m_ComputerPlayer.Score);
        }

        private void scoreAfterPlayerWantsToQuit()  //// ---D
        {
            if (m_CurrentPlayer == eCellTokenValue.X)
            {
                if (m_PlayerVsComputerMode == eGameMode.PlayerVsComputer)
                {
                    m_ComputerPlayer.Score++;
                }
                else
                {
                    m_PlayerTwo.Score++;
                }
            }
            else
            {
                m_PlayerOne.Score++;
            }
        }

        private void playerWantsToQuit()   ///  ---D
        {
            scoreAfterPlayerWantsToQuit();
            v_GameIsAlive = false;
            v_PlayerWantsToQuitGame = true;
            printCurrentScore();
        }
    }
}
