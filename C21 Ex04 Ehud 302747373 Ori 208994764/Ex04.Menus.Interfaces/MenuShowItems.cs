using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuShowItems : MenuItem //Todo - think on a new name for this class 
    {
        public MenuShowItems(string i_ItemTitle, MenuShowItems i_ItemRoot) : base(i_ItemTitle, i_ItemRoot)
        {

        }
    }
}
