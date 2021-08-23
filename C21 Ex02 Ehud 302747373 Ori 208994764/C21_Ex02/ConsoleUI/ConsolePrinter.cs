using System;

namespace C21_Ex02.ConsoleUI
{
    public class ConsolePrinter
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

        public static void ComputerOrPlayerMessage()
        {
            Console.WriteLine("Thank you, now type 'y' if you wish to play against the computer, or any other key to play with another player:");
        }

        public static void InvalidColumnNumberErrorMessage()
        {
            Console.WriteLine("You typed invalid number. Please type the number of the column you want to insert");
        }

        public static void ColumnIsFullMessage()
        {
            Console.WriteLine("The column you chose is full, please try a different column");
        }

        public static void StartMessageQToExit()
        {
            Console.WriteLine("At any time - if you want to quit press 'Q' and enter");
        }

        public static void ChooseColumn()
        {
            Console.WriteLine("Type the number of the column you want to insert");

        }

        public static void RestarttGameOfferMessage()
        {
            Console.WriteLine("GAME END \nFor restart the game type 'y'\nto exit the game type 'Q'");

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
