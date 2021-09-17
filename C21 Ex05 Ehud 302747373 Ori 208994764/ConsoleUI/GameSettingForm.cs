using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleUI
{
    public partial class GameSettingForm : Form
    {
        private const string k_ComputerName = "Computer";
        private bool m_StartButtonSelected;

        public bool StartButtonSelected
        {
            get => m_StartButtonSelected;
        }

        public GameSettingForm()
        {
            m_StartButtonSelected = false;
            InitializeComponent();
        }

        private void startButton_Click(object i_Sender, EventArgs i_Event)
        {
            if(m_Player1TextBox.Text == string.Empty || m_Player2TextBox.Text == string.Empty)
            {
                OutputPrinter.PrintNoNameError();
            }
            else
            {
                m_StartButtonSelected = true;
                Close();
            }
        }

        private void player2CheckBox_CheckedChanged(object i_Sender, EventArgs i_Event)
        {
            m_Player2TextBox.Text = m_Player2TextBox.Enabled ? k_ComputerName : string.Empty;
            m_Player2TextBox.Enabled = !m_Player2TextBox.Enabled;
        }

        private void gameSettingForm_Load(object i_Sender, EventArgs i_Event)
        {

        }
    }
}
