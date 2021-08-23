using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C21_Ex02.LogicGame;

namespace C21_Ex02.ConsoleUI
{
    public class ConsoleInputValidator
    {
        private const int k_MinBoardSize = 4;
        private const int k_MaxBoardSize = 8;

        public static int GetNumOfColumnsFromUser()
        {
            int numOfColumns = 0;

            Console.WriteLine("Please type size of columns (8-4):");
            while (!(int.TryParse(Console.ReadLine(), out numOfColumns) && numOfColumns >= k_MinBoardSize && numOfColumns <= k_MaxBoardSize))
            {
                ConsolePrinter.ErrorSizeMessage();
            }

            return numOfColumns;
        }

        public static int GetNumOfRowsFromUser()
        {
            int numOfRows = 0;

            Console.WriteLine("Please type size of rows (8-4):");
            while (!(int.TryParse(Console.ReadLine(), out numOfRows) && numOfRows >= k_MinBoardSize && numOfRows <= k_MaxBoardSize))
            {
                ConsolePrinter.ErrorSizeMessage();
            }

            return numOfRows;
        }

        public static eGameMode GetGameModeFromUser()
        {
            eGameMode chosenGameMode;
            ConsolePrinter.ComputerOrPlayerMessage();
            string userChoice = Console.ReadLine();

            if(userChoice != null && userChoice.Equals("y"))
            {
                chosenGameMode = eGameMode.PlayerVsComputer;
            }
            else
            {
                chosenGameMode = eGameMode.PlayerVsPlayer;
            }
            return chosenGameMode;
        }

        public static string GetUserResetOrQuitChoice()
        {
            string userAnswer = "";
            bool isValidAnswer = false;

            while (!isValidAnswer)
            {
                ConsolePrinter.RestarttGameOfferMessage();
                userAnswer = Console.ReadLine();
                if (userAnswer.Equals("y") || userAnswer.Equals("Q"))
                {
                    isValidAnswer = true;
                }
            }

            return userAnswer;
        }

        public static string GetUserColumnInput()
        {
            string chosenColumnStr = "";
            ConsolePrinter.ChooseColumn();
            chosenColumnStr = Console.ReadLine();
            return chosenColumnStr;
        }
    }
}
