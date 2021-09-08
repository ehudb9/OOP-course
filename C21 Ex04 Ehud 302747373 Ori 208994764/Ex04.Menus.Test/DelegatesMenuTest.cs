using System;
using Ex04.Menus.Delegates;
using Ex04.Menus.Test.MenuTestFunctunality;

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
            buildTestMenu();
            m_MainMenu.Show();
        }

        private void buildTestMenu()
        {
            m_MainMenu.AddItemToMenu("Version and Spaces");
            m_MainMenu.TrySetLevelDown(0);
            m_MainMenu.AddExecutableItem("Show Version", new ShowVersion().Execute);
            m_MainMenu.AddExecutableItem("Count Spaces", new CountSpaces().Execute);
            m_MainMenu.SetLevelToMainMenuLevel();
            m_MainMenu.AddItemToMenu("Show Date/Time");
            m_MainMenu.TrySetLevelDown(1);
            m_MainMenu.AddExecutableItem("Show Time", new ShowTime().Execute);
            m_MainMenu.AddExecutableItem("Show Date", new ShowDate().Execute);
            m_MainMenu.SetLevelToMainMenuLevel();
        }
    }
}
