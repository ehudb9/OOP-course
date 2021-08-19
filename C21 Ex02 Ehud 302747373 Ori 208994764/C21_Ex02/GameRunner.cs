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
        private bool m_GameIsAlive = false;
        private bool m_Turn = true;
        Player m_PlayerOne = null, m_PlayerTwo = null;
        ComputerPlayer m_computerPlayer = null;
        int m_SizeOfColumns = 0;
        int m_SizeOfRows = 0;
        Board m_GameBoard = null;
        eCellTokenValue m_CurrentPlayer = eCellTokenValue.Empty;

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
            while (!(int.TryParse(Console.ReadLine(), out m_SizeOfColumns)))
            {
                Prints.ErrorSizeMessage();
            }
            m_GameBoard = new Board(m_SizeOfColumns, m_SizeOfRows);
            m_PlayerOne = new Player(1);
            Prints.CompurerOrPlayerMeggage();
            if(Console.ReadLine().Equals("y"))
            {
                m_playerVsComputerMode = eGameMode.PlayerVsComputer;
                m_computerPlayer = new ComputerPlayer(2, m_SizeOfColumns);
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
                m_GameBoard.ShowBoard();

                if (m_Turn)
                {
                    m_CurrentPlayer = eCellTokenValue.Player1;
                    PlayerMove();
                }
                else if (m_playerVsComputerMode == eGameMode.PlayerVsComputer)
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    m_computerPlayer.MakeComputerMove(m_GameBoard);
                }
                else
                {
                    m_CurrentPlayer = eCellTokenValue.Player2;
                    PlayerMove();
                }

                // must be checked!
                if (m_GameBoard.HasWon(m_CurrentPlayer))
                {
                    Console.WriteLine("{0} Won!!!", m_CurrentPlayer);
                    //TODO: print the scores and score of the computer it there is ---- ORI
                    Console.WriteLine("current score is : \n\t{0} player 1\n\t {1} player 2", m_CurrentPlayer);
                    EndGame();
                }
                else if (m_GameBoard.BoardIsFull())
                {
                    EndGame();
                }

                m_Turn = !m_Turn;
            }
            //TODO: close the console..../// ---> TO LEAVE TO THE END

        }

 
                           
        public void PlayerMove()
        {
            Prints.ChooseColumn();
            string chosenColumn = Console.ReadLine();
            int numOfColumnToInsert = 0;
            if (chosenColumn.Equals("q") || chosenColumn.Equals("Q"))
            {
                m_GameIsAlive = false;
                return;
            }
            while (!(int.TryParse(chosenColumn, out numOfColumnToInsert) || isValidColumn(numOfColumnToInsert)))
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

        private bool isValidColumn(int i_ChosenColumn)
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
