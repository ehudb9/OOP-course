using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C21_Ex02.ConsoleUI;

namespace C21_Ex02
{
    /// <summary>
    /// Iterate the turns douring the game
    /// </summary>
    public class GameRunner
    {
        bool m_GameIsAlive = false;
        bool m_turn = false;

        public GameRunner()
        {
            m_GameIsAlive = true;
            StartGame();
           
        }
        public static void StartGame()
        {
            
            /// 1.welocome
            /// 2. get size
            /// 3. Set booard according to input size-- gameBoard
            /// 4. get mode game
            /// 5. initilaize players/player+computer
        }

        public static void InitGame()
        {
            /// 1.welocome
            /// 2. get size
            /// 3. Set booard according to input size-- gameBoard -------ORI
            /// 4. get mode game
            /// 5. initilaize players/player+computer
        }

        public static void Run()
        {
            
            while (m_GameIsAlive)
            {

                /// gameBoard.ShowBoard(); -------------EHUD
                /// if(turn) --> userMove(); ------------EHUD
                /// else if (comuterMode) --> computerMove() ------------ORI
                ///else -- player2Move();  -------------EHUD
                //////
                ///////
                /// checkBoardStatus();--> if end of game -->restart or exit.  -------ORi

                /// turn = !turn;

                m_GameIsAlive = false;
            }
        }
        
        
    }
}
