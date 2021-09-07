using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenuTest
    {
        public static void Run()
        {
            Console.WriteLine("TEST USING DELEGATES");
            MainMenu currentMenu = new MainMenu("Main menu");
            currentMenu.AddItemToMenu("Version and Spaces");
            currentMenu.AddItemToMenu("Show Date/Time");
            currentMenu.LevelDown(0);
            currentMenu.AddExecutableItem("Show Version", ShowVersion);
            currentMenu.AddExecutableItem("Count Spaces", CountSpaces);
            currentMenu.LevelUp();
            currentMenu.LevelDown(1);
            currentMenu.AddExecutableItem("Show Time", ShowTime);
            currentMenu.AddExecutableItem("Show Date", ShowDate);
            currentMenu.GoBackToMainMenu();
            currentMenu.Show();
            Console.WriteLine(currentMenu.CurrentMenu.Title);
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 21.3.4.8933");
        }

        public static void CountSpaces()
        {
            string inputText;
            int spacesCounter = 0;

            Console.WriteLine("Please write something:");
            inputText = Console.ReadLine();
            foreach(char c in inputText)
            {
                if(char.IsWhiteSpace(c))
                {
                    spacesCounter++;
                }
            }

            Console.WriteLine("Number of spaces: {0}", spacesCounter);
        }

        public static void ShowTime()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay);
        }

        public static void ShowDate()
        {
            Console.WriteLine(DateTime.Now.Date);
        }
    }
}
