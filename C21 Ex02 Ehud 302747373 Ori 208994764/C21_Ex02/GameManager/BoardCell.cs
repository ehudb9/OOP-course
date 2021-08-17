using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02.GameManager
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
