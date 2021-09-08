namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Title;
        private MenuItemNode m_Parent;
        private eMenuLevelZeroOption m_Level;

        public MenuItem(string i_Title, MenuItemNode i_Parent)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
            if (m_Parent == null)
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

        public MenuItemNode Parent
        {
            get => m_Parent;
        }

        public eMenuLevelZeroOption Level
        {
            get => m_Level;
        }
    }
}
