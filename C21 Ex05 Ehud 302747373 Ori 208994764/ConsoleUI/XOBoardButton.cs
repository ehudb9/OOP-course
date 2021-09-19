using System.Windows.Forms;
using LogicGame;

namespace WindowUI
{
    public class XOBoardButton : Button
    {
        private eCellTokenValue m_CellValue;
        private int m_Row;
        private int m_Column;

        public eCellTokenValue CellValue
        {
            get => m_CellValue;
            set
            {
                m_CellValue = value;
            }
        }

        public int Row
        {
            get => m_Row;
            set
            {
                m_Row = value;
            }
        }

        public int Column
        {
            get => m_Column;
            set
            {
                m_Column = value;
            }
        }

        public XOBoardButton(int i_Row, int i_Column)
        {
            Anchor = AnchorStyles.Left;
            Anchor = AnchorStyles.Top;
            m_CellValue = eCellTokenValue.Empty;
            m_Row = i_Row;
            m_Column = i_Column;
            Width = 50;
            Height = 50;
        }

        public void OnClickOccurred(eCellTokenValue i_CellValue, int i_Row, int i_Column)
        {
            if(m_Row == i_Row && m_Column == i_Column)
            {
                m_CellValue = i_CellValue;
                Text = m_CellValue.ToString();
            }
        }
    }
}
