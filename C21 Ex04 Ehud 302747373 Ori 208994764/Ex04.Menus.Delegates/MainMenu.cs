using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        public MenuItem m_CurrentItem;
        readonly MenuItem m_RootMenuItem;
        
        public MainMenu(string i_MainTitle) 
        {
            m_RootMenuItem = new MenuShowItem(i_MainTitle, null);
            m_CurrentItem = m_RootMenuItem;
        }

        public MenuItem CurrentMenu
        {
            get { return m_CurrentItem; }
            set { m_CurrentItem = value; } // when can we do {get;} { set;}??
        }

        public void LevelUp() // why do we need up and down level
        {
            if (CurrentMenu.Level == 0)
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
            if(CurrentMenu.MenuItems[i_Index] is MenuItem)
            {
                CurrentMenu = (MenuItem)urrentMenu.MenuItems[i_Index];
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

        public void AddExecuteableItem(string i_Title, Action i_Excuteable) 
        {
            ExecutableMenuItem executeItem = new ExecutableMenuItem(i_Title, CurrentMenu, i_Excuteable);
            CurrentMenu.AddMenuItem(executeItem);
        }
        
        /*public void RemoveItemFromMenu(string i_Title)
        {
            foreach (MenuItem itemToRemove in CurrentMenu.MenuItems)
            {
                if (itemToRemove.Title == i_Title)
                {
                    CurrentMenu.AddMenuItem(itemToRemove);
                }
            }
        }*/

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
                if(userInput == 0)
                {
                    try
                    {
                        Console.Clear();
                        LevelUp();
                        CurrentMenu.Show();
                    }
                    catch (Exception ex)
                    {
                        runnig = false;
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
                        MenuExecuteableItem executeableItem = (MenuExecuteableItem)CurrentMenu.MenuItems[userInput - 1];
                        Console.Clear();
                        executeableItem.InvokeWhenChosen();
                        Console.WriteLine("To go back to menu press any key");
                        Console.ReadLine();
                    }
                }
            }
        }

        private int getValidNumber() {
            int o_Number = 0;
            string userInput = "";
            bool isValid = false;

            while (!isValid)
            {
                userInput = Console.ReadLine();
                if(int.TryParse(isUserInput, out o_Number))
                {
                    if((o_Number >= 0) && (o_Number <= CurrentMenu.MenuItems.Count()))
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

            return o_Number;
        }

        public void goBackToMainMenu()
        {
            CurrentMenu = m_RootMenuItem;
        }
        
        /*public MainMenu()
        {

        }

        public object CurrentMenu { get; set; } //Todo - change object to real class name

        public void AddShowItemToMenu(string i_VersionAndSpaces)
        {
            throw new NotImplementedException();
        }

        public void LevelDown(int i_P0)
        {
            throw new NotImplementedException();
        }

        public void LevelUp()
        {
            throw new NotImplementedException();
        }

        public void AddExecutableItem(string i_ShowTime, IExecutable i_Executable)
        {
            throw new NotImplementedException();
        }

        public void GoBackToMainMenu()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }*/
    }
}
