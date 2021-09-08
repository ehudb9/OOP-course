using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    namespace MenuTestFunctunality
    {
        public class ShowVersion : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Version: 21.3.4.8933");
            }
        }

        public class CountSpaces : IExecutable
        {
            public void Execute()
            {
                string inputText;
                int spacesCounter = 0;

                Console.WriteLine("Please wrote something:");
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
        }

        public class ShowTime : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine(DateTime.Now.TimeOfDay);
            }
        }

        public class ShowDate : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
            }
        }
    }
}
