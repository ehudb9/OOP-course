using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenuTest
    {
        public static void Run()
        {
            Console.WriteLine("TEST USING DELEGATES");
            MainMenu currentMenu = new MainMenu();
            currentMenu.AddShowItemToMenu("Version and Spaces");
            currentMenu.AddShowItemToMenu("Show Date/Time");
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
            //Todo - Implement this method
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
