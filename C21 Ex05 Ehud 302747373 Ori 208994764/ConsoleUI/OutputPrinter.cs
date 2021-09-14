using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

        private static void playWinSound()
        {
            UnmanagedMemoryStream winSound = Properties.Resources.win;
            playSound(winSound);
        }

        private static void playSound(UnmanagedMemoryStream i_ResourceToPlay)
        {
            SoundPlayer soundPlayer = new System.Media.SoundPlayer();
            soundPlayer.Stream = i_ResourceToPlay;
            soundPlayer.Play();
        }

        public static bool AskForAnotherRound(bool i_IsTie, string i_WinnerName)
        {
            bool userWantsAnotherRound;
            if(i_IsTie)
            {
                userWantsAnotherRound = printGameResult("Tie!!", "A Tie!");
            }
            else
            {
                playWinSound();
                string winnerStatement = $"{i_WinnerName} Won!!";
                userWantsAnotherRound = printGameResult(winnerStatement, "A Win!");
            }

            return userWantsAnotherRound;
        }

        private static bool printGameResult(string i_Statement, string i_Title)
        {
            bool selectedYesButton = false;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string toPrint = $@"{i_Statement}
Another Round?";
            DialogResult result = MessageBox.Show(toPrint, i_Title, buttons);
            if(result == DialogResult.Yes)
            {
                selectedYesButton = true;
            }

            return selectedYesButton;
        }
    }
}
