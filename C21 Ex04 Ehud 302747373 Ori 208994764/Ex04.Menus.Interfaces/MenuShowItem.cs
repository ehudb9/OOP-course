using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuShowItem : MenuItem //Todo - think on a new name for this class 
    {
        public MenuShowItem(string i_ItemTitle, MenuShowItem i_ItemRoot) : base(i_ItemTitle, i_ItemRoot)
        {

        }
    }
}
