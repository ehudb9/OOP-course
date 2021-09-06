using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class ExecutableMenuItem : MenuItem
    {
        public event Action ExecuteUserChoice;

        public ExecutableMenuItem(string i_Title, MenuItem i_Root, Action i_ExecuteChoice) : base(i_Title, i_Root)
        {
            ExecuteUserChoice += i_ExecuteChoice;
        }

        public void InvokeWhenChoose()
        {
            OnChoose(); // no need for (this)??
        }

        protected virtual void OnChoose()
        {
            if (ExecuteUserChoice != null)
            {
                ExecuteUserChoice.Invoke();
            }
        }
    }
}