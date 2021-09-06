using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Title;
        private MenuShowItem m_Parent;
        private eMenuLevelZeroOption m_Level;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MenuItem(string i_Title, MenuShowItem i_Parent)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
            if (m_Parent == null)
            {
                m_Level = eMenuLevelZeroOption.Exit;
            }
            else
            {
                m_Level = eMenuLevelZeroOption.Back;
            }
        }

        public string Title
        {
            get => m_Title;
        }

        public MenuShowItem Parent
        {
            get => m_Parent;
        }

        public eMenuLevelZeroOption Level
        {
            get => m_Level;
        }

        public List<MenuItem> MenuItems
        {
            get => r_MenuItems;
        }

        public void Show()
        {
            int counter = 1;
            Console.WriteLine(Title);

            foreach (MenuItem item in r_MenuItems)
            {
                Console.WriteLine("{0} - {1}", counter, item.Title);
                counter++;
            }
            Console.WriteLine("0 - {0}", m_Level);
            Console.WriteLine();
        }

        public void AddMenuItem(MenuItem i_menuItem)
        {
            r_MenuItems.Add(i_menuItem);
        }
    }
}
