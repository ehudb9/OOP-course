using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItemNode : MenuItem
    {
        private readonly List<MenuItem> r_ListOfMenuItems = new List<MenuItem>();

        public MenuItemNode(string i_ItemTitle, MenuItemNode i_ItemRoot) : base(i_ItemTitle, i_ItemRoot)
        {

        }

        public List<MenuItem> MenuItems
        {
            get => r_ListOfMenuItems;
        }

        public void AddItemToLevelList(MenuItem i_MenuItem)
        {
            r_ListOfMenuItems.Add(i_MenuItem);
        }

        public void Show()
        {
            int counter = 1;
            Console.WriteLine(Title);
            foreach(MenuItem item in r_ListOfMenuItems)
            {
                Console.WriteLine("{0} - {1}", counter, item.Title);
                counter++;
            }
            Console.WriteLine("0 - {0}\n", r_ListOfMenuItems[0].Parent.Level);
        }
    }
}
