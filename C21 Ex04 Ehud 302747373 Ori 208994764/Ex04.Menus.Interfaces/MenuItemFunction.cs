namespace Ex04.Menus.Interfaces
{
    class MenuItemFunction : MenuItem
    {
        private IExecutable m_ExecuteFunction;
        public MenuItemFunction(string i_Title, MenuItemNode i_Root, IExecutable i_FunctionName) : base(i_Title, i_Root)
        {
            m_ExecuteFunction = i_FunctionName;
        }

        public void InvokeWhenChoose()
        {
            m_ExecuteFunction.Execute();
        }
    }
}
