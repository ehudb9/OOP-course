using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            SandGlass();
        }

        public static void SandGlass()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder = GenerateSandClockWithInput(ref stringBuilder, 0, 5);

            Console.WriteLine(stringBuilder.ToString());
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        public static StringBuilder GenerateSandClockWithInput(ref StringBuilder io_stringBuilder, int i_row, int i_height)
        {
            if (i_row == i_height)
            {
                return io_stringBuilder;
            }
            if (i_row < i_height / 2)
            {
                io_stringBuilder.AppendLine(new string(' ', i_row) + new string('*', i_height - (2 * i_row)));
            }
            else
            {
                io_stringBuilder.AppendLine(new string(' ', i_height - i_row - 1) + new string('*', (2 * i_row) - i_height + 2));
            }
            GenerateSandClockWithInput(ref io_stringBuilder, i_row + 1, i_height);
            return io_stringBuilder;
        }
    }
}
