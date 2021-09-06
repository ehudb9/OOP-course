using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class ExecutableMenuItem : MenuItem
    {
        public event Action ExecuteUserChoise;

        public ExecutableMenuItem(string i_Title, MenuShowItems i_Root, Action i_ExecuteChoise) : base(i_Title, i_Root)
        {
            ExecuteUserChoise += i_ExecuteChoise;
        }

        public void InvokeWhenChoose()
        {
            OnChoose(); // no need for (this)??
        }

        protected virtual void OnChoose()
        {
            if(ExecuteUserChoise != null)
            {
                ExecuteUserChoise.Invoke();
            }
        }
    }
}
