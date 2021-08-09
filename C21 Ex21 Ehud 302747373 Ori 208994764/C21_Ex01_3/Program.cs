﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex01_3
{
    class Program
    {
        public static void Main()
        {
            SandGlass();
        }

        public static void SandGlass()
        {
            Console.WriteLine("Please enter the number of lines for the sand machine");
            string numberOfLinesStr = Console.ReadLine();
            
            int numberOfLines = 0;
            bool goodInput = int.TryParse(numberOfLinesStr, out numberOfLines);

            StringBuilder stringBuilder = new StringBuilder();
            if (goodInput)
            {
                if (numberOfLines % 2 == 0)
                {
                    numberOfLines = numberOfLines + 1;
                }

                stringBuilder = C21_Ex01_2.Program.GenerateSandClockWithInput(ref stringBuilder, 0, numberOfLines);
                Console.WriteLine(stringBuilder.ToString());
            }
            else
            {
                Console.WriteLine("There was an error with your input");
            }
            
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }
    }
}