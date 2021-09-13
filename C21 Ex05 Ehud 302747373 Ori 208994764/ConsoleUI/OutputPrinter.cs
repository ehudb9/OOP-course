using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleUI
{
    class OutputPrinter
    {
        private static void printMessageToUser(string i_Message, string i_Caption)
        {
            MessageBox.Show(i_Message, i_Caption);
        }

        public static void PrintNoNameError()
        {
            System.Media.SystemSounds.Exclamation.Play();
            printMessageToUser("Please select a player name","Name Not Selected!");
        }
    }
}
