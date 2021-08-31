using System;
using System.Collections.Generic;


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
            currentMenu.AddExecuteableItem("Show Version", ShowVersion);
            currentMenu.AddExecuteableItem("Count Spaces", CountSpaces);
            currentMenu.LevelUp();
            currentMenu.LevelDown(1);
            currentMenu.AddExecuteableItem("Show Time", ShowTime);
            currentMenu.AddExecuteableItem("Show Date", ShowDate);
            currentMenu.goBackToMainMenu();
            currentMenu.Show();
            Console.WriteLine(currentMenu.CurrentMenu.Title);
        }
    }
}
