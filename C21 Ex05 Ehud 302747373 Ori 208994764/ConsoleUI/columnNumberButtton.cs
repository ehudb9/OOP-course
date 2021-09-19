using System.Windows.Forms;

namespace WindowUI
{
    public sealed class ColumnNumberButton : Button
    {
        private int m_ColumnNumberValue;

        public int ColumnNumberValue
        {
            get => m_ColumnNumberValue;
            set
            {
                m_ColumnNumberValue = value;
            }
        }

        public ColumnNumberButton(int i_Column)
        {
            Anchor = AnchorStyles.Left;
            Anchor = AnchorStyles.Top;
            m_ColumnNumberValue = i_Column;
            Text = m_ColumnNumberValue.ToString();
            Width = 50;
            Height = 20;
        }

        public void OnClickOccurred(int i_Column, bool i_IsColumnIsFull)
        {
            if(i_Column == m_ColumnNumberValue && i_IsColumnIsFull)
            {
                Enabled = false;
            }
        }
    }
}
