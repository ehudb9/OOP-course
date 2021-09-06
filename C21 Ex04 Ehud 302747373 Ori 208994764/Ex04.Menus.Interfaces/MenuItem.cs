namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private int m_ItemLevel;
        private MenuShowItems m_ItemRoot;
        private string m_ItemTitle;

        public MenuItem(string i_ItemTitle, MenuShowItems i_ItemRoot)
        {
            m_ItemTitle = i_ItemTitle;
            m_ItemRoot = i_ItemRoot;
            if(ItemRoot == null)
            {
                m_ItemLevel = 0;
            }
            else
            {
                m_ItemLevel = ItemRoot.m_ItemLevel + 1;
            }
        }

        public MenuShowItems ItemRoot
        {
            get => m_ItemRoot;
        }

        public string ItemTitle
        {
            get => m_ItemTitle;
        }

        public int ItemLevel
        {
            get => m_ItemLevel;
        }
    }
}
