using System.Windows.Forms;
using LogicGame;
using System;

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

        public XOBoardButton(int i_Row, int i_Column)
        {
            Anchor = AnchorStyles.Left;
            Anchor = AnchorStyles.Top;
            m_CellValue = eCellTokenValue.Empty;
            m_Row = i_Row;
            m_Column = i_Column;
            Width = 30;
            Height = 30;
        }
    }
}
