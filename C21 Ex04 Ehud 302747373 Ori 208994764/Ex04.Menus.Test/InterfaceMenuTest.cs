using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenuTest
    {
        public static void Run()
        {
            Console.WriteLine("TEST USING DELEGATES");
            MainMenu currentMenu = new MainMenu("Main Menu");
            //MainMenu currentMenu = new MainMenu();
            currentMenu.AddItemToMenu("Version and Spaces");
            currentMenu.AddItemToMenu("Show Date/Time");
            currentMenu.LevelDown(0);
            currentMenu.AddExecutableItem("Show Version", new ShowVersion());
            currentMenu.AddExecutableItem("Count Spaces", new CountSpaces());
            currentMenu.LevelUp();
            currentMenu.LevelDown(1);
            currentMenu.AddExecutableItem("Show Time", new ShowTime());
            currentMenu.AddExecutableItem("Show Date", new ShowDate());
            currentMenu.GoBackToMainMenu();
            currentMenu.Show();
            Console.WriteLine(currentMenu.CurrentMenu.Title);
        }

        public class ShowVersion : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Version: 21.3.4.8933");
            }
        }

        public class CountSpaces : IExecutable
        {
            public void Execute()
            {
                string inputText;
                int spacesCounter = 0;

                Console.WriteLine("Please wrote something:");
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
        }

        public class ShowTime : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine(DateTime.Now.TimeOfDay);
            }
        }

        public class ShowDate : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine(DateTime.Now.Date);
            }
        }
    }
}
