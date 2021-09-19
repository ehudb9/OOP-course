using System;
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
        public int m_CohsenColumn;
        public int m_CurrentRow;

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
            Height = r_FormRowsSize * 65;
            Width = r_FormColsSize * 45;
            buildButtonMatrix();
            initPlayerLabels();
        }

        private void buildButtonMatrix()
        {
            XOBoardButton xoBoardButton;
            ColumnNumberButton columnNumberButton;
            for(int i = 1; i <= r_FormColsSize; i++)
            {
                columnNumberButton = new ColumnNumberButton(i);
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
            int currentXPlace = Width/6;
            int currentYPlace = Height - 55;
            Player1Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player1Label.Location.X + Player1Label.Width;
            Player1ScoreLabel.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = (Width/2);
            Player2Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player2Label.Location.X + Player2Label.Width;
            Player2ScoreLabel.Location = new Point(currentXPlace, currentYPlace);
            makeCurrentPlayerLabelFontBold();
        }

        private void makeCurrentPlayerLabelFontBold()  
        {
            if(r_GameRunner.Turn)
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Bold);
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Regular);
            }
            else
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Regular);
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Bold);
            }
        }

        private void boardColumnButton_Click(object sender, EventArgs i_Event)
        {
            m_CohsenColumn = (sender as ColumnNumberButton).ColumnNumberValue;
            r_GameRunner.m_CohsenColumn = m_CohsenColumn;
            r_GameRunner.PlayerMove();
            m_XOButtonsTableLayout.GetControlFromPosition(m_CohsenColumn-1, r_GameRunner.m_CurrentRow).Text = r_GameRunner.Turn ? "X" : "O";
            // move to function
            if (r_GameRunner.m_GameBoard.IsFullColumn(m_CohsenColumn))
            {
                (sender as ColumnNumberButton).OnFullColumn(m_CohsenColumn);
            }
            eBoardGameStatus boardStatus = r_GameRunner.CheckBoard();
            if (boardStatus != eBoardGameStatus.ContinuePlay)
            {
                string winnerName = r_GameRunner.Turn ? Player1Label.Text.Substring(0, Player1Label.Text.Length - 1) : Player2Label.Text.Substring(0, Player2Label.Text.Length - 1);
                if (!OutputPrinter.AskForAnotherRound(boardStatus == eBoardGameStatus.Tie, winnerName))
                {
                    Close();
                }
                else
                {
                    resetGame();
                }
            }

            if (r_UserChoiceOfGameMode == eGameMode.PlayerVsComputer)
            {
                r_GameRunner.Turn = !r_GameRunner.Turn;
                makeCurrentPlayerLabelFontBold();
                r_GameRunner.ComputerMove();
                m_CohsenColumn = r_GameRunner.m_CohsenColumn;
                m_XOButtonsTableLayout.GetControlFromPosition(m_CohsenColumn - 1, r_GameRunner.m_CurrentRow).Text = r_GameRunner.Turn ? "X" : "O";
                ///to make a diff function
                if (r_GameRunner.m_GameBoard.IsFullColumn(m_CohsenColumn))
                {
                    (m_ColNumberButtonsTableLayout.GetControlFromPosition(m_CohsenColumn, 0)).Enabled = false;
                }
                boardStatus = r_GameRunner.CheckBoard();
                if (boardStatus != eBoardGameStatus.ContinuePlay)
                {
                    string winnerName = r_GameRunner.Turn ? Player1Label.Text.Substring(0, Player1Label.Text.Length - 1) : Player2Label.Text.Substring(0, Player2Label.Text.Length - 1);
                    if (!OutputPrinter.AskForAnotherRound(boardStatus == eBoardGameStatus.Tie, winnerName))
                    {
                        Close();
                    }
                    else
                    {
                        resetGame();
                    }
                }
            }
            r_GameRunner.Turn = !r_GameRunner.Turn;
            makeCurrentPlayerLabelFontBold();
        }

        private void playTurn()
        {

        }

        private void updateScore()
        {
            Player1ScoreLabel.Text = r_GameRunner.Player1Score;
            Player2ScoreLabel.Text = r_GameRunner.Player2Score;
        }
       
        private void checkBoard(object sender)
        {
            if (r_GameRunner.m_GameBoard.IsFullColumn(m_CohsenColumn))
            {
                (sender as ColumnNumberButton).OnFullColumn(m_CohsenColumn);
            }
            eBoardGameStatus boardStatus = r_GameRunner.CheckBoard();
            if (boardStatus != eBoardGameStatus.ContinuePlay)
            {
                string winnerName = r_GameRunner.Turn ? Player1Label.Text.Substring(0, Player1Label.Text.Length - 1) : Player2Label.Text.Substring(0, Player2Label.Text.Length - 1);
                if (!OutputPrinter.AskForAnotherRound(boardStatus == eBoardGameStatus.Tie, winnerName))
                {
                    Close();
                }
                else
                {
                    resetGame();
                }
            }
        }

        private void resetGame()
        {
            updateScore();
            r_GameRunner.ResetGame();
            foreach (ColumnNumberButton columnButton in m_ColNumberButtonsTableLayout.Controls)
            {
                columnButton.Enabled = true;
            }
            for (int i = 0; i < r_FormColsSize; i++)
            {
                if (m_ColNumberButtonsTableLayout.GetControlFromPosition(i, 0) != null)
                {
                    m_ColNumberButtonsTableLayout.GetControlFromPosition(i, 0).Enabled = true;
                }
                for (int j = 0; j < r_FormRowsSize; j++)
                {
                    m_XOButtonsTableLayout.GetControlFromPosition(i, j).Text = "";
                }
            }
        }
        
        private void boardGameForm_Load(object i_Sender, EventArgs i_Event)
        {

        }
    }
}
