namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        readonly string m_Title;
        readonly MenuShowItem m_Parent;
        readonly eMenuLevelZeroOption m_Level;

        public MenuItem(string i_Title, MenuShowItem i_Parent)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
            if(m_Parent == null)
            {
                    m_Level = eMenuLevelZeroOption.Exit;
            }
            else
            {
                    m_Level = eMenuLevelZeroOption.Back;
            }
        }
        
        public string Title
        {
            get => m_Title;
        }
        
        public MenuShowItem Parent
        {
            get => m_Parent;
        }
        
        public eMenuLevelZeroOption Level
        {
            get => m_Level;
        }
    }
}
