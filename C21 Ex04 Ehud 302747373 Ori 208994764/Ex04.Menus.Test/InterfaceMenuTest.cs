using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenuTest
    {
        /// 1 - version and spaces
        /// count spaces
        /// show version
        /// 
        /// 2 - show date/time
        /// show time
        /// show date 
        ///
        /// 
        public static void RunTestWithInterface()
        {
            MainMenu currentMenu = new MainMenu();
            currentMenu.AddShowItemToMenu("Version and Spaces");
            currentMenu.AddShowItemToMenu("Show Date/Time");
            currentMenu.LevelDown(0);
            currentMenu.AddExecuteableItem("Show Version", new ShowVersion());
            currentMenu.AddExecuteableItem("Count Spaces", new CountSpaces());
            currentMenu.LevelUp();
            currentMenu.LevelDown(1);
            currentMenu.AddExecuteableItem("Show Time", new ShowTime());
            currentMenu.AddExecuteableItem("Show Date", new ShowDate());
            currentMenu.goBackToMainMenu();
            currentMenu.Show();
            Console.WriteLine(currentMenu.CurrentMenu.Title);
        }
    }
}
