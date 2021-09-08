using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItemFunction : MenuItem
    {
        public event Action ExecuteUserChoice;

        public MenuItemFunction(string i_Title, MenuItemNode i_Root, Action i_FunctionName) : base(i_Title, i_Root)
        {
            ExecuteUserChoice += i_FunctionName;
        }

        public void InvokeWhenChoose()
        {
            OnChoose();
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