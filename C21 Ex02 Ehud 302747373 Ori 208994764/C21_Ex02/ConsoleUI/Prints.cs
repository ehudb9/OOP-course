using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02.ConsoleUI
{
    public class Prints
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello and welcome!!! :)\n ");
            Console.WriteLine("Please type size of board to start the game");
        }

        public static void ErrorSizeMessage()
        {
            Console.WriteLine("Please try again type a single int in range of 4-8:");
        }

        public static void ComputerOrPlayerMeggage()
        {
            Console.WriteLine("Thank you, now type 'y' if you wish to play against the computer , 'n' to play with player 2:");

        }

        public static void ColumnIsFullMessage()
        {
            Console.WriteLine("the column you chose is full, please try a different column");

        }

        public static void StartMessageQToExit()
        {
            Console.WriteLine("At any time - press 'q' and enter");
        }

        public static void ChooseColumn()
        {
            Console.WriteLine("Type the number of the column you want to insert");

        }

        public static void ReatsrtGameOfferMessage()
        {
            Console.WriteLine("GAME END \nFor restart the game type 'y'\nto exit the game type 'q'");

        }

        public static void ExitGameMessage()
        {
            Console.WriteLine("Thank you for playing our game! Please press 'Enter' to exit");
        }

        public static void Player1PlayNowMessage()
        {
            Console.WriteLine("Player 1 Turn:");
        }

        public static void Player2PlayNowMessage()
        {
            Console.WriteLine("Player 2 Turn:");
        }

        public static void ItsATie()
        {
            Console.WriteLine("It's a Tie!");
        }
    }
}
