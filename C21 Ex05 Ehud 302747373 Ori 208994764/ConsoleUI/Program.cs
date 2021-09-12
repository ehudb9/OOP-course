using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        [STAThread] //Todo - just in order to debug without running error
        public static void Main()
        {
            //Todo - Just for initial debugging
            GameSettingForm gameSettingForm = new GameSettingForm();
            gameSettingForm.ShowDialog();
        }
    }
}
