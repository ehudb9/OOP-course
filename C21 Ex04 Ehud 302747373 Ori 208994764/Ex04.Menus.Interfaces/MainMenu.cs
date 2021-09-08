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

        public void LevelUp()
        {
            if (CurrentLevelMenu.Level == eMenuLevelZeroOption.Exit)
            {
                throw new ArgumentOutOfRangeException("No upper level");
            }
            else
            {
                CurrentLevelMenu = CurrentLevelMenu.Parent;
            }
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
                Console.WriteLine("Please select option:");
                userInput = getValidInput();
                if (userInput == 0)
                {
                    try
                    {
                        Console.Clear();
                        LevelUp();
                        CurrentLevelMenu.Show();
                    }
                    catch
                    {
                        exit = true;
                    }
                }
                else
                {
                    try
                    {
                        LevelDown(userInput - 1);
                        Console.Clear();
                    }
                    catch
                    {
                        MenuItemFunction executableItem = (MenuItemFunction)CurrentLevelMenu.MenuItems[userInput - 1];
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
                        Console.WriteLine("Please enter a number between 0 and {0}", CurrentLevelMenu.MenuItems.Count());
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an int - number");
                }
            }

            return o_UserChoise;
        }
    }
}
