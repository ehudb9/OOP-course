using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class MenuItem
    {
        readonly string m_Title;
        readonly MenuShowItem m_Root;
        readonly int m_Level;
        
        public MenuItem(string i_Title, MenuShowItem i_Root)
        {
            m_Title = i_Title;
            m_Root = i_Root;
            if(m_Root == null)
                {
                    m_Level = 0;
                }
            else
                {
                    m_Level = Root.m_Level + 1;
                }
        }
        
        public string Title
        {
            get { return m_Title; }
        }
        
        public MenuShowItem Root
        {
            get { return m_Root; }
        }
        
        public int Level
        {
            get { return m_Level; }
        }
    }
}
