namespace C21_Ex02.LogicGame
{
    class Player
    {
        public int Sign { get; }
        private int m_Score;

        public Player(int i_sign)
        {
            m_Score = 0;
            Sign = i_sign;
        }
        public int Score
        {
            get => m_Score;
            set => m_Score = value;
        }
    }
}
