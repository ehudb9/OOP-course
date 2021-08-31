using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class CmdUIManager  /// ToDo maybe change to abstract/Interface??
    {
        private const int k_MenuOptionZero = 0;
        private const int k_MenuOptionOne = 1;
        private const int k_MenuOptionTwo = 2;

        public int GetUserChoice(int i_MaxIndexMenuOption)
        {
            bool isValidChoise = false;
            int ChosenIndex = 0;

            while (!isValidChoise)
            {
                Console.WriteLine("\nPlease select option:");
                string userInput = Console.ReadLine();
                isValidChoise = int.TryParse(userInput, out ChosenIndex) && isValidIndex(ChosenIndex, i_MaxIndexMenuOption);
            }

            return ChosenIndex;
        }

        private bool isValidIndex(int i_ChosenIndex, int i_MaxMenuOptionIdex)
        {
            return i_ChosenIndex <= i_MaxMenuOptionIdex && i_ChosenIndex >= k_MenuOptionZero;
        }

        public void PrintMenuOptions(string i_ItemName, List<MenuItem> i_MenuOptions, eMenuLevelZeroOption i_OptionZero)
        {
            Console.Clear();
            Console.WriteLine("{0}", i_ItemName);
            for (int i = 1; i <= i_MenuOptions.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, i_MenuOptions[i - 1].ItemTitle);
            }
            Console.WriteLine("0. {0}", i_OptionZero);
        }
        public void PrintExitMessage()
        {
            Console.WriteLine("Goodby!");
        }
    }
}
