using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGame
{
    public class GameRunner
    {
        private eGameMode m_PlayerVsComputerMode = eGameMode.PlayerVsPlayer;
        public bool v_GameIsAlive = false;
        public bool v_PlayerWantsToQuitGame = false;    /// D
        private bool m_Turn = true;
        private const eCellTokenValue k_SignPlayer1 = eCellTokenValue.X;
        private const eCellTokenValue k_SignPlayer2 = eCellTokenValue.O;
        private Player m_PlayerOne = null, m_PlayerTwo = null;
        private ComputerPlayer m_ComputerPlayer = null;
        public int m_SizeOfColumns = 0;
        public int m_SizeOfRows = 0;
        public Board m_GameBoard = null;
        private eCellTokenValue m_CurrentPlayer = eCellTokenValue.Empty;

        public GameRunner()
        {
            v_GameIsAlive = true;
            //InitGame();
        }

        public void InitGame(int i_BoardRowNumber, int i_BoardColNumber, eGameMode i_GameMode)
        {
            Console.WriteLine("" + i_BoardRowNumber +  i_BoardColNumber); // ---D
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
            //ConsolePrinter.StartMessageQToExit(); // TBC -- REset Dialog
        }

        public void Run()
        {
            Console.WriteLine("RUNNNN"); // ---D

            /*
            while (v_GameIsAlive)
            {
                ShowBoardUI.ShowBoard(m_GameBoard); ///d

                if (m_Turn)
                {
                    m_CurrentPlayer = eCellTokenValue.Player1;
                    ConsolePrinter.Player1PlayNowMessage(); ///D
                    PlayerMove();    
                }
                else if (m_PlayerVsComputerMode == eGameMode.PlayerVsComputer)
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    m_ComputerPlayer.MakeComputerMove(m_GameBoard);
                }
                else
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    ConsolePrinter.Player2PlayNowMessage();   //// D
                    PlayerMove();
                }

                ShowBoardUI.ShowBoard(m_GameBoard);   ////  D

                if (m_GameBoard.HasWon(m_CurrentPlayer))
                {
                    ConsolePrinter.PrintWinner(m_CurrentPlayer);   //// TBC ---  widow print of winner with the UI
                    if (m_CurrentPlayer == eCellTokenValue.Player1)
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
                    ConsolePrinter.ItsATie();
                    printCurrentScore();     //// TBC ---  widow print of winner with the UI
                    endGame();
                }

                m_Turn = !m_Turn;
            }

            ConsolePrinter.ExitGameMessage();       ///// D
            Console.ReadLine();       /////D
            */
        }

        public void PlayerMove()
        {
            //Todo - need to be change according to this game
            /*
            int playerChoseColumnToInsert = 0;
            bool v_isValidInput = false;
            //// TBC : playerChoseColumnToInsert = ConsoleInputValidator.GetUserColumnInput();  /// tbc --- from the board
            
            m_GameBoard.InsertCellToBoard(playerChoseColumnToInsert, m_CurrentPlayer);
 
            */
        }

        private void endGame()   /// TBC according to dialog end game  window
        {
            string resetOrQuit = "";
            //resetOrQuit = ConsoleInputValidator.GetUserResetOrQuitChoice();   //// TBC  reset window UI

            if (resetOrQuit.Equals("y"))    
            {
                ResetGame();
            }
            else
            {
                v_GameIsAlive = false;
            }
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
