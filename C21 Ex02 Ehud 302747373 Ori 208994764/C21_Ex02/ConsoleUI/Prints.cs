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
            Console.WriteLine("\tHello and welcome!!! :) ");
            Console.WriteLine("\tPlease type size of board to start the game");
        }
        public static void ErrorSizeMessage()
        {
            Console.WriteLine("\tPlease try again type a single int :");
        }

        public static void CompurerOrPlayerMeggage()
        {
            Console.WriteLine("\n Thank you, now type 'y' if you wish to play against the computer , 'n' to play with player 2:");

        }

        public static void ColumnIsFullMessage()
        {
            Console.WriteLine("the column you choosed is full, please try a different column");

        }

        public static void StartMessageQToExit()
        {
            Console.WriteLine("At any time- perss 'q' and enter");
        }

        public static void ChooseColumn()
        {
            Console.WriteLine("Type the number of the column you want to insert");

        }

        public static void ReatsrtGameOfferMessage()
        {
            Console.WriteLine("GAME END \nFor restart the game type 'y'\n to exit the game type 'q'");

        }

        public static void ExitGameMessage()
        {
            Console.WriteLine("Thank you for playing our game! Please press any key to exit");
        }

        public static void Player1PlayNowMessage()
        {
            Console.WriteLine("Player 1 Turn:");
        }

        public static void Player2PlayNowMessage()
        {
            Console.WriteLine("Player 2 Turn:");
        }
    }
}
