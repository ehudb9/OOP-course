using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class MenuItem
    {
        private eMenuLevelZeroOption m_LevelZeroOption { get; }
        private string m_ItemTitle;
        private string m_Root;
        public List<IExecutable> m_ExecutableList { get; set; }
        public List<MenuItem> m_MenuItemsList { get; set; }
        public CmdUIManager m_Ui = new CmdUIManager();//how to make it nicer?


        public MenuItem(string i_Title)
        {
            m_ItemTitle = i_Title;
        }
        
        public string ItemTitle
        {
            get { return m_ItemTitle; }
        }

        public void Show()
        {
            if (m_MenuItemsList == null) // is a leaf
            {
                execute();
            }
            else
            {
                showMenu();
            }
        }

        private void execute()
        {
            foreach (IExecutable startable in m_ExecutableList)
            {
                startable.Execute();
            }
        }
        public static void InputHandler()
        {
            ///
        }

        private void showMenu()
        {
            bool userWantsMenu = true;
            m_Ui.PrintMenuOptions(m_ItemTitle, m_MenuItemsList, eMenuLevelZeroOption.Back);
            while (userWantsMenu)
            {
                int userInput = m_Ui.GetUserChoice(m_MenuItemsList.Count); // to try to fix this calling
                if (userInput == 0)
                {
                    userWantsMenu = false;
                }
                else
                {
                    excecuteUserChoice(userInput);
                }
            }
        }

        private void excecuteUserChoice(int i_UserChoice)
        {
            MenuItem chosenItem = m_MenuItemsList[i_UserChoice - 1];

            if (chosenItem.m_MenuItemsList == null)
            {
                chosenItem.execute();
            }
            else
            {
                chosenItem.showMenu();
            }
        }

    }
}
