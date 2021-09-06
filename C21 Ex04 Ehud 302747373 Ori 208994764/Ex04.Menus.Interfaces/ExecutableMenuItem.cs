using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class ExecutableMenuItem : MenuItem
    {
        private IExecutable m_Execute;
        public ExecutableMenuItem(string i_Title, MenuItem i_Root, IExecutable i_ExecuteChoice) : base(i_Title, i_Root)
        {
            m_Execute = i_ExecuteChoice;
        }

        public void InvokeWhenChoose()
        {
            m_Execute.Execute();
        }
    }
}
