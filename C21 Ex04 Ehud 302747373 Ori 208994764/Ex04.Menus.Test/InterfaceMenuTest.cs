using System;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.MenuTestFunctunality;

namespace Ex04.Menus.Test
{
    public class InterfaceMenuTest
    {
        MainMenu m_MainMenu;

        public InterfaceMenuTest(string i_Title)
        {
            m_MainMenu = new MainMenu(i_Title);
        }

        public void Run()
        {
            m_MainMenu.AddItemToMenu("Version and Spaces");
            m_MainMenu.TrySetLevelDown(0);
            m_MainMenu.AddExecutableItem("Show Version", new ShowVersion());
            m_MainMenu.AddExecutableItem("Count Spaces", new CountSpaces());
            m_MainMenu.SetLevelToMainMenuLevel();
            m_MainMenu.AddItemToMenu("Show Date/Time");
            m_MainMenu.TrySetLevelDown(1);
            m_MainMenu.AddExecutableItem("Show Time", new ShowTime());
            m_MainMenu.AddExecutableItem("Show Date", new ShowDate());
            m_MainMenu.SetLevelToMainMenuLevel();
            m_MainMenu.Show();
        }
    }
}
