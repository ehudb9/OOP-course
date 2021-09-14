using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicGame;

namespace ConsoleUI
{
    public partial class BoardGameForm : Form
    {
        private readonly eGameMode r_UserChoiceOfGameMode;
        private readonly int r_FormRowsSize;
        private readonly int r_FormColsSize;
        private readonly GameRunner r_GameRunner;

        public BoardGameForm(string i_Player1Name, string i_Player2Name, GameRunner i_GameRunner, eGameMode i_GameMode)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            r_UserChoiceOfGameMode = i_GameMode;
            InitializeComponent();
            r_GameRunner = i_GameRunner;
            Player1Label.Text = i_Player1Name; //Todo - need to check why when the app run we don't see text in labels
            Player2Label.Text = i_Player2Name; //Todo - need to check why when the app run we don't see text in labels
            r_FormRowsSize = i_GameRunner.m_SizeOfRows;
            r_FormColsSize = i_GameRunner.m_SizeOfColumns;
            Height = r_FormRowsSize * 75;
            Width = r_FormColsSize * 75;
            buildButtonMatrix();
            initPlayerLabels();
        }

        private void buildButtonMatrix()
        {
            //Todo - need to implement
        }

        private void initPlayerLabels()
        {
            //Todo - need to implement
        }
    }
}
