﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Ui gameUi = new Ui();
            gameUi.RunGame();
        }
    }
}
