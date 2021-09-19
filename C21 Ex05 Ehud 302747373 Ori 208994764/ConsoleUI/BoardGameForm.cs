﻿using System;
using System.Drawing;
using System.Windows.Forms;
using LogicGame;

namespace WindowUI
{
    public partial class BoardGameForm : Form
    {
        private readonly eGameMode r_UserChoiceOfGameMode;
        private readonly int r_FormRowsSize;
        private readonly int r_FormColsSize;
        private readonly GameRunner r_GameRunner;
        private bool v_IsPlayerOneTurn = true;

        public BoardGameForm(string i_Player1Name, string i_Player2Name, GameRunner i_GameRunner, eGameMode i_GameMode)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            r_UserChoiceOfGameMode = i_GameMode;
            InitializeComponent();
            r_GameRunner = i_GameRunner;
            Player1Label.Text = i_Player1Name; 
            Player2Label.Text = i_Player2Name; 
            r_FormRowsSize = i_GameRunner.m_SizeOfRows;
            r_FormColsSize = i_GameRunner.m_SizeOfColumns;
            Height = r_FormRowsSize * 75;
            Width = r_FormColsSize * 75;
            buildButtonMatrix();
            initPlayerLabels();
        }

        private void buildButtonMatrix()
        {
            XOBoardButton xoBoardButton;
            ColumnNumberButton columnNumberButton;
            for(int i = 0; i < r_FormColsSize; i++)
            {
                columnNumberButton = new ColumnNumberButton(i + 1);
                columnNumberButton.Click += boardColumnButton_Click;
                m_ColNumberButtonsTableLayout.Controls.Add(columnNumberButton, i, 0);
            }

            for(int i = 0; i < r_FormRowsSize; i++)
            {
                for(int j = 0; j < r_FormColsSize; j++)
                {
                    xoBoardButton = new XOBoardButton(i, j);
                    xoBoardButton.CellValue = r_GameRunner.m_GameBoard.r_BoardCells[i, j].CellTokenValue;
                    m_XOButtonsTableLayout.Controls.Add(xoBoardButton, j, i);
                }
            }

            Controls.Add(m_ColNumberButtonsTableLayout);
            Controls.Add(m_XOButtonsTableLayout);
        }

        private void initPlayerLabels()
        {
            int currentXPlace = m_ColNumberButtonsTableLayout.Location.X + 80;
            int currentYPlace = Height - 55;
            Player1Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player1Label.Location.X + Player1Label.Width;
            Player1ScoreLabel.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player1ScoreLabel.Location.X + Player1ScoreLabel.Width + 10;
            Player2Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player2Label.Location.X + Player2Label.Width;
            Player2ScoreLabel.Location = new Point(currentXPlace, currentYPlace);
            makeCurrentPlayerLabelFontBold();
        }

        private void makeCurrentPlayerLabelFontBold()
        {
            if(v_IsPlayerOneTurn)
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Bold);
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Regular);
            }
            else
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Regular);
                Player2Label.Font = new Font(Player1Label.Font, FontStyle.Bold);
            }
        }

        private void boardColumnButton_Click(object sender, EventArgs i_Event)
        {
            //Todo - need to implement
        }

        private void boardGameForm_Load(object i_Sender, EventArgs i_Event)
        {

        }
    }
}