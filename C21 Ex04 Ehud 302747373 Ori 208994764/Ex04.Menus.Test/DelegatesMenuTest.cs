using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenuTest
    {
        MainMenu m_MainMenu;

        public DelegatesMenuTest(string i_Title)
        {
            m_MainMenu = new MainMenu(i_Title);
        }

        public void Run()
        {
            m_MainMenu.AddItemToMenu("Version and Spaces");
            m_MainMenu.TrySetLevelDown(0);
            m_MainMenu.AddExecutableItem("Show Version", ShowVersion);
            m_MainMenu.AddExecutableItem("Count Spaces", CountSpaces);
            m_MainMenu.SetLevelToMainMenuLevel();
            m_MainMenu.AddItemToMenu("Show Date/Time");
            m_MainMenu.TrySetLevelDown(1);
            m_MainMenu.AddExecutableItem("Show Time", ShowTime);
            m_MainMenu.AddExecutableItem("Show Date", ShowDate);
            m_MainMenu.SetLevelToMainMenuLevel();
            m_MainMenu.Show();
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
            foreach (char c in inputText)
            {
                if (char.IsWhiteSpace(c))
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
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
    }
}
