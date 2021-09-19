namespace LogicGame
{
    public class BoardCell
    {
        public eCellTokenValue CellTokenValue
        {
            get;
            set;
        }

        public BoardCell()
        {
            CellTokenValue = eCellTokenValue.Empty;
        }
    }
}
