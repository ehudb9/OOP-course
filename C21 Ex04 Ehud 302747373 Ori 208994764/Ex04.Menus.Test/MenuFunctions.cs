using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class MenuFunctions
    {
        public static void CountSpaces()
        {
            string inputText = "";
            int spacesCounter = 0;

            Console.WriteLine("Please wrote something :");
            inputText = Console.ReadLine();
            foreach (char c in inputText)
            {
                if (char.IsWhiteSpace(c))
                {
                    spacesCounter++;
                }
            }
            Console.WriteLine("Number of spaces: {0}", spacesCounter);
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 21.3.4.8933");
        }

        public static void ShowTime()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay);
        }

        public static void ShowDate()
        {
            Console.WriteLine(DateTime.Now.Date);
        }
    }
}
