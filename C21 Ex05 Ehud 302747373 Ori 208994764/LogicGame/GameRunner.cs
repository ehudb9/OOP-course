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
        public bool v_PlayerWantsToQuitGame = false;
        private bool m_Turn = true;
        private const int k_SignPlayer1 = 1;
        private const int k_SignPlayer2 = 2;
        private Player m_PlayerOne = null, m_PlayerTwo = null;
        private ComputerPlayer m_ComputerPlayer = null;
        public int m_SizeOfColumns = 0;
        public int m_SizeOfRows = 0;
        private Board m_GameBoard = null;
        private eCellTokenValue m_CurrentPlayer = eCellTokenValue.Empty;

        public GameRunner()
        {
            v_GameIsAlive = true;
            //InitGame();
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
            //ConsolePrinter.StartMessageQToExit();
        }

        //Todo - need to be change according to this game
        public void Run()
        {
            /*
            while (v_GameIsAlive)
            {
                ShowBoardUI.ShowBoard(m_GameBoard);

                if (m_Turn)
                {
                    m_CurrentPlayer = eCellTokenValue.Player1;
                    ConsolePrinter.Player1PlayNowMessage();
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
                    ConsolePrinter.Player2PlayNowMessage();
                    PlayerMove();
                }

                ShowBoardUI.ShowBoard(m_GameBoard);

                if (v_PlayerWantsToQuitGame)
                {

                    ConsolePrinter.PrintWinner(m_CurrentPlayer == eCellTokenValue.Player1 ? eCellTokenValue.Player2 : eCellTokenValue.Player1);
                    printCurrentScore();
                    endGame();
                }
                else if (m_GameBoard.HasWon(m_CurrentPlayer))
                {
                    ConsolePrinter.PrintWinner(m_CurrentPlayer);
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

                    printCurrentScore();
                    endGame();
                }
                else if (m_GameBoard.BoardIsFull())
                {
                    ConsolePrinter.ItsATie();
                    printCurrentScore();
                    endGame();
                }

                m_Turn = !m_Turn;
            }

            ConsolePrinter.ExitGameMessage();
            Console.ReadLine();
            */
        }

        public void PlayerMove()
        {
            //Todo - need to be change according to this game
            /*
            int playerChoseColumnToInsert = 0;
            bool v_isValidInput = false;
            playerChoseColumnToInsert = ConsoleInputValidator.GetUserColumnInput();
            while (!v_isValidInput)
            {
                if (playerChoseColumnToInsert == ConsoleInputValidator.k_PlayerWantsToQuit)
                {
                    playerWantsToQuit();
                    v_isValidInput = true;
                }
                else
                {
                    if (!m_GameBoard.IsValidColumn(playerChoseColumnToInsert))
                    {
                        if (m_GameBoard.IsFullColumn(playerChoseColumnToInsert))
                        {
                            ConsolePrinter.ColumnIsFullMessage();
                        }
                        else
                        {
                            ConsolePrinter.ErrorSizeMessage();
                        }

                        playerChoseColumnToInsert = ConsoleInputValidator.GetUserColumnInput();
                    }
                    else
                    {
                        m_GameBoard.InsertCellToBoard(playerChoseColumnToInsert, m_CurrentPlayer);
                        v_isValidInput = true;
                    }
                }
            }
            */
        }

        private void endGame()
        {
            string resetOrQuit = "";
            //resetOrQuit = ConsoleInputValidator.GetUserResetOrQuitChoice();

            if (resetOrQuit.Equals("y"))
            {
                ResetGame();
            }
            else
            {
                v_GameIsAlive = false;
            }
        }

        private void printCurrentScore()
        {
            //ConsolePrinter.PrintCurrentPlayerScore(m_PlayerOne.Score, m_PlayerVsComputerMode == eGameMode.PlayerVsPlayer ? m_PlayerTwo.Score : m_ComputerPlayer.Score);
        }

        private void scoreAfterPlayerWantsToQuit()
        {
            if (m_CurrentPlayer == eCellTokenValue.Player1)
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

        private void playerWantsToQuit()
        {
            scoreAfterPlayerWantsToQuit();
            v_GameIsAlive = false;
            v_PlayerWantsToQuitGame = true;
            printCurrentScore();
        }
    }
}
