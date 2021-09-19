using System;

namespace WindowUI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Ui gameUi = new Ui();
            gameUi.RunGame();
        }
    }
}
