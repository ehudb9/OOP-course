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
        public const int k_PlayerWantsToQuit = 0;

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
                ConsolePrinter.RestartGameOfferMessage();
                userAnswer = Console.ReadLine();
                if (userAnswer.Equals("y") || userAnswer.Equals("Q"))
                {
                    isValidAnswer = true;
                }
            }

            return userAnswer;
        }

        public static int GetUserColumnInput()
        {
            string chosenColumnStr;
            bool v_isValidUserInput = false;
            bool v_isRowDigit = false;
            int numOfColumnToInsert = 0;

            ConsolePrinter.ChooseColumn();
            chosenColumnStr = Console.ReadLine();
            v_isValidUserInput = isPlayerTypedQ(ref numOfColumnToInsert, chosenColumnStr);

            while (!v_isValidUserInput)
            {
                if (string.IsNullOrEmpty(chosenColumnStr))
                {
                    ConsolePrinter.EmptyInput();
                    chosenColumnStr = Console.ReadLine();
                    v_isValidUserInput = isPlayerTypedQ(ref numOfColumnToInsert, chosenColumnStr);
                }
                else if (chosenColumnStr.Length < 2)
                {
                    v_isRowDigit = char.IsDigit(char.Parse(chosenColumnStr));

                    if (v_isRowDigit)
                    {
                        if (int.TryParse(chosenColumnStr, out numOfColumnToInsert))
                        {
                            v_isValidUserInput = true;
                        }
                        else
                        {
                            ConsolePrinter.ErrorInput();
                            chosenColumnStr = Console.ReadLine();
                            v_isValidUserInput = isPlayerTypedQ(ref numOfColumnToInsert, chosenColumnStr);
                        }
                    }
                    else
                    {
                        ConsolePrinter.InvalidColumnNumberErrorMessage();
                        chosenColumnStr = Console.ReadLine();
                        v_isValidUserInput = isPlayerTypedQ(ref numOfColumnToInsert, chosenColumnStr);
                    }
                }
                else
                {
                    ConsolePrinter.InvalidColumnNumberErrorMessage();
                    ConsolePrinter.ChooseColumn();
                    chosenColumnStr = Console.ReadLine();
                    v_isValidUserInput = isPlayerTypedQ(ref numOfColumnToInsert, chosenColumnStr);
                }
            }

            return numOfColumnToInsert;
        }

        private static bool isPlayerTypedQ(ref int i_NumOfColumnToInsert, string i_ChosenColumn)
        {
            bool v_isValidUserInput = false;

            if (i_ChosenColumn.Equals("Q"))
            {
                v_isValidUserInput = true;
                i_NumOfColumnToInsert = k_PlayerWantsToQuit;
            }

            return v_isValidUserInput;
        }
    }
}
