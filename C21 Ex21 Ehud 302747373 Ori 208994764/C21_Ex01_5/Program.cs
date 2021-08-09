using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex01_5
{
    class Program
    {
        public static void Main()
        {
            numberStatistics();
        }

        private static void numberStatistics()
        {
            Console.WriteLine("Please enter positive 9 digits number");
            string inputNumberStr = Console.ReadLine();
            char[] inputNumberAsCharArray = inputNumberStr.ToCharArray();

            for (int i = 0; i < inputNumberAsCharArray.Length; i++)
            {
                if (inputNumberAsCharArray[i] < '0' && inputNumberAsCharArray[i] > '9')
                {
                    Console.WriteLine("Please exit and try again with positve number");
                }
            }

            int unityDigit = inputNumberAsCharArray[inputNumberAsCharArray.Length - 1];
            char biggestDigitInNumber = inputNumberAsCharArray.Max();
            char smallestDigitInNumber = inputNumberAsCharArray.Min();
            int amountOfDigitDivideBy3 = 0;
            int amountOfDigitBiggerThenUnitDigit = 0;

            for (int i = 0; i < inputNumberAsCharArray.Length; i++)
            {
                if (inputNumberAsCharArray[i] % 3 == 0)
                {
                    amountOfDigitDivideBy3 = amountOfDigitDivideBy3 + 1;
                }
                if (inputNumberAsCharArray[i] > unityDigit)
                {
                    amountOfDigitBiggerThenUnitDigit = amountOfDigitBiggerThenUnitDigit + 1;
                }
            }

            object[] args = new object[5];
            args[0] = inputNumberStr;
            args[1] = biggestDigitInNumber;
            args[2] = smallestDigitInNumber;
            args[3] = amountOfDigitDivideBy3;
            args[4] = amountOfDigitBiggerThenUnitDigit;

            string message = string.Format(
@"Your input number was {0} 
The biggest digit in the input number is: {1} 
The smallest digit in the input number is: {2} 
The amount of digits in the in the input number that divided by 3 is: {3} 
The ampunt of digits in the input number that are bigger than the unity digit is: {4} ", args);

            Console.WriteLine(message);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }
    }
}
