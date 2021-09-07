using System;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        public MenuShowItem m_CurrentItem;
        private readonly MenuShowItem r_RootMenuItem;

        public MainMenu(string i_MainTitle)
        {
            r_RootMenuItem = new MenuShowItem(i_MainTitle, null);
            m_CurrentItem = r_RootMenuItem;
        }

        public MenuShowItem CurrentMenu
        {
            get => m_CurrentItem;
            set
            {
                m_CurrentItem = value;
            }
        }

        public void LevelUp() // why do we need up and down level
        {
            if (CurrentMenu.Level == eMenuLevelZeroOption.Exit)
            {
                throw new ArgumentOutOfRangeException("no upper level");
            }
            else
            {
                CurrentMenu = CurrentMenu.Parent;
            }
        }
        public void LevelDown(int i_Index)
        {
            if (CurrentMenu.MenuItems[i_Index] is MenuShowItem) 
            {
                CurrentMenu = (MenuShowItem)CurrentMenu.MenuItems[i_Index];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddItemToMenu(string i_Title)
        {
            MenuShowItem showMenuItem = new MenuShowItem(i_Title, CurrentMenu);
            CurrentMenu.AddMenuItem(showMenuItem);
        }

        public void AddExecutableItem(string i_Title, IExecutable i_Executable)
        {
            ExecutableMenuItem executeItem = new ExecutableMenuItem(i_Title, CurrentMenu, i_Executable);
            CurrentMenu.AddMenuItem(executeItem);
        }

        public void Show()
        {
            int userInput;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                CurrentMenu.Show();
                Console.WriteLine("Please select option:");
                userInput = getValidNumber();
                if (userInput == 0)
                {
                    try
                    {
                        Console.Clear();
                        LevelUp();
                        CurrentMenu.Show();
                    }
                    catch (Exception ex)
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
                        ExecutableMenuItem executableItem = (ExecutableMenuItem)CurrentMenu.MenuItems[userInput - 1];
                        Console.Clear();
                        executableItem.InvokeWhenChoose();
                        Console.WriteLine("To go back to menu press any key");
                        Console.ReadLine();
                    }
                }
            }
        }

        private int getValidNumber()
        {
            int o_UserChoise = 0;
            string userInput = "";
            bool isValid = false;

            while (!isValid)
            {
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out o_UserChoise))
                {
                    if ((o_UserChoise >= 0) && (o_UserChoise <= CurrentMenu.MenuItems.Count()))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number between 0 and {0}", CurrentMenu.MenuItems.Count());
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            }

            return o_UserChoise;
        }

        public void GoBackToMainMenu()
        {
            CurrentMenu = r_RootMenuItem;
        }
    }
}
