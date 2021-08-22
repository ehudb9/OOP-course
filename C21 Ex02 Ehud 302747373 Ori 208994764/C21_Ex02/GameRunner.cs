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
        private eGameMode m_playerVsComputerMode = eGameMode.PlayerVsPlayer;
        private bool m_gameIsAlive = false;
        private bool m_turn = true;
        private Player m_playerOne = null, m_playerTwo = null;
        private ComputerPlayer m_computerPlayer = null;
        public int m_sizeOfColumns = 0;
        public int m_sizeOfRows = 0;
        private Board m_gameBoard = null;
        private eCellTokenValue m_CurrentPlayer = eCellTokenValue.Empty;

        public GameRunner()
        {
            m_gameIsAlive = true;
            InitGame();
        }
        public void InitGame()
        {

            Prints.WelcomeMessage();
            Console.WriteLine("\tPlease type size of columns (8-4):");
            while (!(int.TryParse(Console.ReadLine(),out m_sizeOfColumns)))
            {
                Prints.ErrorSizeMessage();
            }
            
            Console.WriteLine("\tPlease type size of rows (8-4):");
            while (!(int.TryParse(Console.ReadLine(), out m_sizeOfRows)))
            {
                Prints.ErrorSizeMessage();
            }
            m_gameBoard = new Board(m_sizeOfColumns, m_sizeOfRows);
            m_playerOne = new Player(1);
            Prints.CompurerOrPlayerMeggage();
            if(Console.ReadLine().Equals("y"))
            {
                m_playerVsComputerMode = eGameMode.PlayerVsComputer;
                m_computerPlayer = new ComputerPlayer(2, m_sizeOfColumns);
            }
            else
            {
                m_playerTwo = new Player(2);
            }

            Prints.StartMessageQToExit();

        }

        public void ResetBoard()
        {
            m_gameBoard.ResetBoard();
            Prints.StartMessageQToExit();
        }

        public void Run()
        {
            while (m_gameIsAlive)
            {
                m_gameBoard.ShowBoard();

                if (m_turn)
                {
                    m_CurrentPlayer = eCellTokenValue.Player1;
                    Prints.Player1PlayNowMessage();
                    PlayerMove();
                    //Todo - check if someone win
                }
                else if (m_playerVsComputerMode == eGameMode.PlayerVsComputer)
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    m_computerPlayer.MakeComputerMove(m_gameBoard);
                    //Todo - check if someone win
                }
                else
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    Prints.Player2PlayNowMessage();
                    PlayerMove();
                    //Todo - check if someone win
                }

                if (m_gameBoard.HasWon(m_CurrentPlayer))
                {
                    m_gameBoard.ShowBoard();
                    Console.WriteLine("{0} Won!!!", m_CurrentPlayer);
                    if(m_CurrentPlayer == eCellTokenValue.Player1)
                    {
                        m_playerOne.Score++;
                    }
                    else
                    {
                        if(m_playerVsComputerMode == eGameMode.PlayerVsPlayer)
                        {
                            m_playerTwo.Score++;
                        }
                        else
                        {
                            m_computerPlayer.Score++;
                        }
                        
                    }

                    if(m_playerVsComputerMode == eGameMode.PlayerVsPlayer)
                    {
                        Console.WriteLine("current score is : \n\tplayer 1: {0}\n\tplayer 2: {1}", m_playerOne.Score, m_playerTwo.Score);
                    }
                    else
                    {
                        Console.WriteLine("current score is : \n\tplayer: {0}\n\tcomputer: {1}", m_playerOne.Score, m_computerPlayer.Score);
                    }    
                    EndGame();
                }
                else if (m_gameBoard.BoardIsFull() == true)
                {
                    EndGame();
                }

                m_turn = !m_turn;
            }

            m_gameBoard.ShowBoard();
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
                m_gameIsAlive = false;
                return;
            }
            while (!(int.TryParse(chosenColumn, out numOfColumnToInsert) && IsValidColumn(numOfColumnToInsert)))
            {
                if(m_gameBoard.IsFullColumn(numOfColumnToInsert))
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
            m_gameBoard.InsertCellToBoard(numOfColumnToInsert, m_CurrentPlayer);
        }

        public bool IsValidColumn(int i_ChosenColumn)
        {
            return i_ChosenColumn > 0  && i_ChosenColumn <= m_sizeOfColumns && !m_gameBoard.IsFullColumn(i_ChosenColumn);
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
                    m_gameIsAlive = false;
                    isValidAnswer = true;
                }
            }
        }
    }
}
