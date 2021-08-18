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
        Player m_PlayerOne = null, m_PlayerTwo = null;
        ComputerPlayer m_computerPlayer = null;
        int m_SizeOfColumns = 0;
        int m_SizeOfRows = 0;
        Board m_GameBoard = null;

        public GameRunner()
        {
            m_gameIsAlive = true;
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
            Console.WriteLine("\n Thank you, now type 'y' if you wish to play against the computer , 'n' to play with player 2:");
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

        public static void ReSetGame()
        {
            //m_gameBoard.ReSet();
            Prints.StartMessageQToExit();
        }

        public void Run()
        {
            
            while (m_gameIsAlive)
            {
                m_GameBoard.ShowBoard();

                if (m_turn)
                {
                    playerMove();
                }
                else if (m_playerVsComputerMode == eGameMode.PlayerVsComputer)
                {
                    m_computerPlayer.MakeComputerMove(m_GameBoard);
                }
                else
                {
                    playerMove(2);
                }
                
                if (m_GameBoard.CheckEndGame())
                {
                    //TODO: who played in the last turn. for now I'm check it for player1, we need to change it for generic checking
                    if (m_GameBoard.HasWon(eCellTokenValue.Player1))
                    {
                        /// printWinner
                        /// printScores
                        /// askto end of game -->restart or exit. 
                    }

                }

                m_turn = !m_turn;
                
                m_gameIsAlive = false;
            }
        }
                           
        private void playerMove(int i_player = 1)
        {
            Prints.ChooseColumn();
            string chosenColumn = Console.ReadLine();
            int numOfColumnToInsert = 0;
            if (chosenColumn.Equals("q") || chosenColumn.Equals("q"))
            {
                m_gameIsAlive = false;
                return;
            }
            while (!(int.TryParse(chosenColumn, out numOfColumnToInsert) || isValidColumn(numOfColumnToInsert)))
            {
                Prints.ErrorSizeMessage();
            }

            m_GameBoard.InsertCellToBoard(numOfColumnToInsert, i_player == 1 ? eCellTokenValue.Player1 : eCellTokenValue.Player2);
        }

        private bool isValidColumn(int i_ChosenColumn)
        {
            return i_ChosenColumn > 0  && i_ChosenColumn <= m_SizeOfColumns && !m_GameBoard.IsFullColumn(i_ChosenColumn);
        }

    }
}
