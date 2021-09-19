using LogicGame;

namespace WindowUI
{
    class Ui
    {
        private readonly GameSettingForm r_gameSettingForm;
        private BoardGameForm m_boardGameForm;

        public Ui()
        {
            r_gameSettingForm = new GameSettingForm();
        }

        public void RunGame()
        {
            r_gameSettingForm.ShowDialog();
            if(r_gameSettingForm.StartButtonSelected)
            {
                buildGameFromSetting();
                m_boardGameForm.ShowDialog();
            }
        }

        private void buildGameFromSetting()
        {
            int userSelectedBoardRowsNumber = r_gameSettingForm.RowsUpDown;
            int userSelectedBoardColsNumber = r_gameSettingForm.ColumnsUpDown;
            eGameMode userChoiceGameMode = eGameMode.PlayerVsPlayer;
            if(!r_gameSettingForm.Player2CheckBox)
            {
                userChoiceGameMode = eGameMode.PlayerVsComputer;
            }

            GameRunner gameRunner = new GameRunner();
            gameRunner.InitGame(userSelectedBoardRowsNumber, userSelectedBoardColsNumber, userChoiceGameMode);
            string name1 = $"{r_gameSettingForm.Player1TextBox}:";
            string name2 = $"{r_gameSettingForm.Player2TextBox}:";
            m_boardGameForm = new BoardGameForm(name1, name2, gameRunner, userChoiceGameMode);
        }
    }
}
