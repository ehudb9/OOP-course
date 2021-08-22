using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C21_Ex02.LogicGame;

namespace C21_Ex02.ConsoleUI
{
    public class ShowBoardUI
    {
        public static void ShowBoard(Board i_BoardGame)
        {
            Ex02.ConsoleUtils.Screen.Clear();

            StringBuilder visualBoard = new StringBuilder();
            for (int i = 0; i < i_BoardGame.m_NumOfRows; i++)
            {
                visualBoard.AppendFormat("   {0}", i + 1);
            }

            visualBoard.AppendLine();

            for (int i = 0; i < i_BoardGame.m_NumOfRows; i++)
            {
                visualBoard.AppendFormat("{0}|", i + 1);

                for (int j = 0; j < i_BoardGame.m_NumOfColumns; j++)
                {
                    eCellTokenValue cellValue = i_BoardGame.m_BoardCells[i, j].CellTokenValue;
                    if (cellValue != eCellTokenValue.Empty)
                    {
                        char cellTokenIcon;
                        if (cellValue == eCellTokenValue.Player1)
                        {
                            cellTokenIcon = 'X';
                        }
                        else
                        {
                            cellTokenIcon = 'O';
                        }
                        visualBoard.AppendFormat(" {0} |", cellTokenIcon);
                    }
                    else
                    {
                        visualBoard.AppendFormat("   |");
                    }
                }

                visualBoard.AppendLine();
                visualBoard.Append(" ");
                visualBoard.Append('=', i_BoardGame.m_NumOfColumns * 4);
                visualBoard.Append("\n");
            }
            Console.WriteLine(visualBoard.ToString());
        }
    }
}
