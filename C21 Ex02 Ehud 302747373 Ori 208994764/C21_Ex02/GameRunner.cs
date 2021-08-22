using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C21_Ex02.ConsoleUI;
using C21_Ex02.LogicGame;


namespace C21_Ex02
{
    /// <summary>
    /// Iterate the turns during the game
    /// </summary>
    public class GameRunner
    {
        //מאתתייים פעם החלפתי את השמות וזה חוזר כל הזמן!!למה??????
        private eGameMode m_PlayerVsComputerMode = eGameMode.PlayerVsPlayer;
        private bool m_GameIsAlive = false;
        private bool m_Turn = true;
        private Player m_PlayerOne = null, m_PlayerTwo = null;
        private ComputerPlayer m_ComputerPlayer = null;
        public int m_SizeOfColumns = 0;
        public int m_SizeOfRows = 0;
        private Board m_GameBoard = null;
        private eCellTokenValue m_CurrentPlayer = eCellTokenValue.Empty;

        public GameRunner()
        {
            m_GameIsAlive = true;
            InitGame();
        }
        public void InitGame()
        {

            Prints.WelcomeMessage();
            Console.WriteLine("\tPlease type size of columns (8-4):");
            while (!(int.TryParse(Console.ReadLine(),out m_SizeOfColumns)))
            {
                Prints.ErrorSizeMessage();
            }
            
            Console.WriteLine("\tPlease type size of rows (8-4):");
            while (!(int.TryParse(Console.ReadLine(), out m_SizeOfRows)))
            {
                Prints.ErrorSizeMessage();
            }
            m_GameBoard = new Board(m_SizeOfColumns, m_SizeOfRows);
            m_PlayerOne = new Player(1);
            Prints.CompurerOrPlayerMeggage();
            if(Console.ReadLine().Equals("y"))
            {
                m_PlayerVsComputerMode = eGameMode.PlayerVsComputer;
                m_ComputerPlayer = new ComputerPlayer(2, m_SizeOfColumns);
            }
            else
            {
                m_PlayerTwo = new Player(2);
            }

            Prints.StartMessageQToExit();

        }

        public void ResetBoard()
        {
            m_GameBoard.ResetBoard();
            Prints.StartMessageQToExit();
        }

        public void Run()
        {
            while (m_GameIsAlive)
            {
                //TODO:change path----why twice??
                //ShowBoardUI.ShowBoard(m_gameBoard);
                m_GameBoard.ShowBoard();

                if (m_Turn)
                {
                    m_CurrentPlayer = eCellTokenValue.Player1;
                    Prints.Player1PlayNowMessage();
                    PlayerMove();
                    //Todo - check if someone win
                }
                else if (m_PlayerVsComputerMode == eGameMode.PlayerVsComputer)
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    m_ComputerPlayer.MakeComputerMove(m_GameBoard);
                    //Todo - check if someone win
                }
                else
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    Prints.Player2PlayNowMessage();
                    PlayerMove();
                    //Todo - check if someone win
                }

                if (m_GameBoard.HasWon(m_CurrentPlayer))
                {
                    m_GameBoard.ShowBoard();
                    Console.WriteLine("{0} Won!!!", m_CurrentPlayer);
                    if(m_CurrentPlayer == eCellTokenValue.Player1)
                    {
                        m_PlayerOne.Score++;
                    }
                    else
                    {
                        if(m_PlayerVsComputerMode == eGameMode.PlayerVsPlayer)
                        {
                            m_PlayerTwo.Score++;
                        }
                        else
                        {
                            m_ComputerPlayer.Score++;
                        }
                        
                    }

                    if(m_PlayerVsComputerMode == eGameMode.PlayerVsPlayer)
                    {
                        Console.WriteLine("current score is : \n\tplayer 1: {0}\n\tplayer 2: {1}", m_PlayerOne.Score, m_PlayerTwo.Score);
                    }
                    else
                    {
                        Console.WriteLine("current score is : \n\tplayer: {0}\n\tcomputer: {1}", m_PlayerOne.Score, m_ComputerPlayer.Score);
                    }    
                    EndGame();
                }
                else if (m_GameBoard.BoardIsFull() == true)
                {
                    EndGame();
                }

                m_Turn = !m_Turn;
            }

            m_GameBoard.ShowBoard();
            Prints.ExitGameMessage();
            Console.ReadLine();
        }

        public void PlayerMove()
        {
            Prints.ChooseColumn();
            string chosenColumn = Console.ReadLine();
            int numOfColumnToInsert = 0;
            //ToDo - Why if the user press a number is spit of q and after it try to quit the game?
            if (chosenColumn.Equals("q") || chosenColumn.Equals("Q"))//Todo - add 1 point to the other player - If someone exit from the game, the second player will win
            {
                m_GameIsAlive = false;
                return;
            }
            while (!(int.TryParse(chosenColumn, out numOfColumnToInsert) && IsValidColumn(numOfColumnToInsert)))
            {
                if(m_GameBoard.IsFullColumn(numOfColumnToInsert))
                {
                    Prints.ColumnIsFullMessage();        
                }
                else
                {
                    Prints.ErrorSizeMessage();
                }
                Prints.ChooseColumn();
                chosenColumn = Console.ReadLine();
            }
            m_GameBoard.InsertCellToBoard(numOfColumnToInsert, m_CurrentPlayer);
        }

        public bool IsValidColumn(int i_ChosenColumn)
        {
            return i_ChosenColumn > 0  && i_ChosenColumn <= m_SizeOfColumns && !m_GameBoard.IsFullColumn(i_ChosenColumn);
        }

        private void EndGame()
        {
            bool isValidAnswer = false;
            while (!isValidAnswer)
            {
                Prints.ReatsrtGameOfferMessage();
                string userAnswer = Console.ReadLine();
                if (userAnswer.Equals("y"))
                {
                    ResetBoard();
                    isValidAnswer = true;
                }
                else if (userAnswer.Equals("q"))
                {
                    m_GameIsAlive = false;
                    isValidAnswer = true;
                }
            }
        }
    }
}
