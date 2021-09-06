using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class MenuShowItems : MenuItem // Into the class MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MenuShowItem(string i_Title, MenuShowItem i_Root) : base(i_Title, i_Root) { }

        public void Show()
        {
            int counter = 1;

            Console.WriteLine(Title);
            if (Level == 0)
            {
                Console.WriteLine("0. >>>>> Exit");
            }
            else
            {
                Console.WriteLine("0. >>>>> Back");
            }
            foreach (MenuItem item in r_MenuItems)
            {
                Console.WriteLine(counter + ". >>>>> " + item.ToString());
                counter++;
            }
        }

        public List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        public void AddMenuItem(MenuItem i_menuItem)
        {
            r_MenuItems.Add(i_menuItem);
        }

        public void RemoveMenuItem(MenuItem i_menuItem)
        {
            r_MenuItems.Remove(i_menuItem);
        }
    }
}
