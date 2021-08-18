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
    /// Iterate the turns douring the game
    /// </summary>
    public class GameRunner
    {
        bool m_PlayerVsComputerMode = false;
        private bool m_GameIsAlive = false;
        private bool m_Turn = true;
        Player m_PlayerOne = null, m_PlayerTwo = null;
        //ComputerPlay ComputerPlayer = null;
        int m_SizeOfColumns = 0;
        int m_SizeOfRows = 0;
        Board m_GameBoard = null;

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
            //m_GameBoard = new Board(m_SizeOfColumns, m_SizeOfRows);
            m_PlayerOne = new Player();
            Console.WriteLine("\n Thank you, now type 'y' if you wish to play against the computer , 'n' to play with player 2:");
            if(Console.ReadLine().Equals("y"))
            {
                m_PlayerVsComputerMode = true;
                //ComputerPlay = new ComputerPlay();
            }
            else
            {
                m_PlayerTwo = new Player();
            }

            Prints.StartMessageQToExit();

        }

        public static void ReSetGame()
        {
            //m_gameBoard.ReSet();
            Prints.StartMessageQToExit();
        }

        public void Run()
        {
            
            while (m_GameIsAlive)
            {
                /// m_GameBoard.ShowBoard();
                if (m_Turn)
                {
                    playerMove();
                }
                else if (m_PlayerVsComputerMode)
                {
                    //ComputerPlay.computerMove();
                }
                else
                {
                    playerMove(1);
                }
                
                if (m_GameBoard.CheckEndGame())
                {
                    if (m_GameBoard.)
                    {
                        /// printWinner
                        /// printScores
                        /// askto end of game -->restart or exit. 
                    }

                }

                m_Turn = !m_Turn;
                
                m_GameIsAlive = false;
            }
        }
                           
        private void playerMove(int i_player = 0)
        {
            Prints.ChooseColumn();
            string ChosenColumn = Console.ReadLine();
            int numOfColumnToInsert = 0;
            if (ChosenColumn.Equals("q") || ChosenColumn.Equals("q"))
            {
                m_GameIsAlive = false;
                return;
            }
            while (!(int.TryParse(ChosenColumn, out numOfColumnToInsert) || isValidColumn(numOfColumnToInsert)))
            {
                Prints.ErrorSizeMessage();
            }
            //m_GameBoard.InsertCell(numOfColumnToInsert, i_player); 
        }

        private bool isValidColumn(int i_ChosenColumn)
        {
            return i_ChosenColumn > 0  && i_ChosenColumn <= m_SizeOfColumns && !m_GameBoard.IsFullColumn(i_ChosenColumn);
        }

    }
}
