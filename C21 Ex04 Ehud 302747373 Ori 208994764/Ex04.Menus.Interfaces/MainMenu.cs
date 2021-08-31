using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{ 
    public class MainMenu
    {
        private String m_MenuTitle;
        private List<MenuItem> m_MenuItems;
        private CmdUIManager m_Ui;
        private const int k_MenuOptionZero = 0;

        public MainMenu(string i_Title, List<MenuItem> i_MenuItems)
        {
            m_MenuTitle = i_Title;
            m_MenuItems = i_MenuItems;
            m_Ui = new CmdUIManager();
        }
        
        public string Title
        {
            set { m_MenuTitle = value; }
        }

        public void Show() // ToDo : Fix Methods calling and naming
        {
            bool exit = false;
            int userChoise = -1;
            while (!exit)
            {
                m_Ui.PrintMenuOptions(m_MenuTitle, m_MenuItems, eMenuLevelZeroOption.Exit);
                userChoise = m_Ui.GetUserChoice(m_MenuItems.Count);
                if (userChoise == k_MenuOptionZero)
                {
                    m_Ui.PrintExitMessage();
                    exit = true;
                }
                else
                {
                    m_MenuItems[userChoise - 1].Show();
                }
            }
        }
    }
}