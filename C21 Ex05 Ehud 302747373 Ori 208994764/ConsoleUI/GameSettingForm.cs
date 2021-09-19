using System;
using System.Windows.Forms;

namespace WindowUI
{
    public partial class GameSettingForm : Form
    {
        public const string k_ComputerName = "Computer";
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

        private void startButton_Click(object sender, EventArgs e)
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

        private void player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_Player2TextBox.Text = m_Player2TextBox.Enabled ? k_ComputerName : string.Empty;
            m_Player2TextBox.Enabled = !m_Player2TextBox.Enabled;
        }

        private void gameSettingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
