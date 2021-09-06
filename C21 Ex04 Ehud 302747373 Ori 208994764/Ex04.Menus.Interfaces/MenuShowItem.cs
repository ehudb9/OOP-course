using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuShowItem : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MenuShowItem(string i_ItemTitle, MenuShowItem i_ItemRoot) : base(i_ItemTitle, i_ItemRoot)
        {

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
            Console.WriteLine("0 - {0}", r_MenuItems[0].Level);
            Console.WriteLine();
        }

        public List<MenuItem> MenuItem
        {
            get => r_MenuItems;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }
    }
}
