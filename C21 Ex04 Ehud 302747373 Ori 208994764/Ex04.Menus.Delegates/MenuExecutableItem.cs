using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class MenuExecutableItem : MenuItem
    {
        public event Action ExecuteItemDelegate;

        public MenuExecutableItem(string i_Title, MenuShowItems i_Root, Action i_Executeable) : base(i_Title, i_Root)
        {
            ExecuteItemDelegate += i_Executeable;
        }

        public void InvokeWhenChoose()
        {
            ExecuteItemEventHandler();
        }

        protected virtual void ExecuteItemEventHandler()
        {
            if(ExecuteItemDelegate != null)
            {
                ExecuteItemDelegate.Invoke();
            }
        }
    }
}
