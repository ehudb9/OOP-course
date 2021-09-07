using System;

namespace Ex04.Menus.Delegates
{
    public class ExecutableMenuItem : MenuItem
    {
        public event Action ExecuteUserChoice;

        public ExecutableMenuItem(string i_Title, MenuShowItem i_Root, Action i_ExecuteChoice) : base(i_Title, i_Root)
        {
            ExecuteUserChoice += i_ExecuteChoice;
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