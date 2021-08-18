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

        public static void AskForBoardSizeMessage()
        {
            ///TBC
        }

        public static void CompurerOrPlayerMeggage()
        {
            ///TBC
        }

        public static void ColumnIsFullMessage()
        {
            ///TBC
        }

        public static void StartMessageQToExit()
        {
            ///TBC
            Console.WriteLine("At any time- perss 'q' and enter");
        }
        public static void ChooseColumn()
        {
            Console.WriteLine("Type the number of the column you want to insert");

        }
        public static void ReatsrtGameOfferMessage()
        {
            Console.WriteLine("For restart the game type 'y'\n to exit the game type 'q'");

        }
    }
}
