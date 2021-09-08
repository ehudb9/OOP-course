using System;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        public MenuItemNode m_CurrentItem;
        private readonly MenuItemNode r_RootMenuItem;

        public MainMenu(string i_MainTitle)
        {
            r_RootMenuItem = new MenuItemNode(i_MainTitle, null);
            m_CurrentItem = r_RootMenuItem;
        }

        public MenuItemNode CurrentLevelMenu
        {
            get => m_CurrentItem;
            set
            {
                m_CurrentItem = value;
            }
        }

        public void AddItemToMenu(string i_Title)
        {
            MenuItemNode showMenuItem = new MenuItemNode(i_Title, CurrentLevelMenu);
            CurrentLevelMenu.AddItemToLevelList(showMenuItem);
        }

        public void AddExecutableItem(string i_Title, IExecutable i_Function)
        {
            MenuItemFunction executeItem = new MenuItemFunction(i_Title, CurrentLevelMenu, i_Function);
            CurrentLevelMenu.AddItemToLevelList(executeItem);
        }
        public void SetLevelToMainMenuLevel()
        {
            CurrentLevelMenu = r_RootMenuItem;
        }

        private bool trySetLevelToParent()
        {
            bool isAParent = false;
            if (CurrentLevelMenu.Level == eMenuLevelZeroOption.Back)
            {
                CurrentLevelMenu = CurrentLevelMenu.Parent;
                isAParent = true;
            }

            return isAParent;
        }
        public void LevelDown(int i_Index)
        {
            if (CurrentLevelMenu.MenuItems[i_Index] is MenuItemNode) 
            {
                CurrentLevelMenu = (MenuItemNode)CurrentLevelMenu.MenuItems[i_Index];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Show()
        {
            int userInput;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                CurrentLevelMenu.Show();
                Console.WriteLine("Please select an option:");
                userInput = getValidInput();
                if (userInput == 0)
                {
                    if(trySetLevelToParent())
                    {
                        Console.Clear();
                        CurrentLevelMenu.Show();
                    }
                    else
                    {
                        exit = true;
                    }
                }
                else
                {
                    userInput--;
                    try
                    {
                        LevelDown(userInput);
                    }
                    catch
                    {
                        MenuItemFunction executableItem = (MenuItemFunction)CurrentLevelMenu.MenuItems[userInput];
                        Console.Clear();
                        executableItem.InvokeWhenChoose();
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                    }
                }
            }
        }

        private int getValidInput()
        {
            int o_UserChoise = 0;
            string userInput = "";
            bool isValidInput = false;

            while (!isValidInput)
            {
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out o_UserChoise))
                {
                    if ((o_UserChoise >= 0) && (o_UserChoise <= CurrentLevelMenu.MenuItems.Count()))
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number between 0 and {0}\nPlease select an option:", CurrentLevelMenu.MenuItems.Count());
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an int - number\nPlease select an option:");
                }
            }

            return o_UserChoise;
        }
    }
}
