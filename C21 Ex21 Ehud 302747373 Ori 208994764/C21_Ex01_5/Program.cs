using System;
using System.Linq;

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

            bool inputIsValid = checkInputValidity(inputNumberStr);
            if (inputIsValid == false)
            {
                Console.WriteLine("There is a problem with your string. Please exit and try again");
                Console.WriteLine("Please press 'Enter' to exit...");
                Console.ReadLine();
                return;
            }

            int unityDigit = inputNumberStr[inputNumberStr.Length - 1];
            char biggestDigitInNumber = inputNumberStr.Max();
            char smallestDigitInNumber = inputNumberStr.Min();
            int amountDigitDivideBy3 = 0;
            int amountDigitBiggerThenUnitDigit = 0;

            for (int i = 0; i < inputNumberStr.Length; i++)
            {
                if (inputNumberStr[i] % 3 == 0)
                {
                    amountDigitDivideBy3 = amountDigitDivideBy3 + 1;
                }
                if (inputNumberStr[i] > unityDigit)
                {
                    amountDigitBiggerThenUnitDigit = amountDigitBiggerThenUnitDigit + 1;
                }
            }

            string message = createFormatMessege(inputNumberStr, biggestDigitInNumber, smallestDigitInNumber, amountDigitDivideBy3, amountDigitBiggerThenUnitDigit);
            Console.WriteLine(message);

            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static bool checkInputValidity(string i_inputNumberStr)
        {
            if (i_inputNumberStr.Length != 9)
            {
                return false;
            }

            if(i_inputNumberStr[0] == '-')
            {
                return false;
            }

            for (int i = 0; i < i_inputNumberStr.Length; i++)
            {
                if (i_inputNumberStr[i] < '0' && i_inputNumberStr[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static string createFormatMessege(string i_inputStr, char i_biggestDigitInNumber, char i_smallestDigitInNumber, int i_amountDigitDivideBy3, int i_amountDigitBiggerThenUnitDigit)
        {
            object[] args = new object[5];
            args[0] = i_inputStr;
            args[1] = i_biggestDigitInNumber;
            args[2] = i_smallestDigitInNumber;
            args[3] = i_amountDigitDivideBy3;
            args[4] = i_amountDigitBiggerThenUnitDigit;

            string message = string.Format(
                @"Your input number was {0} 
The biggest digit in the input number is: {1} 
The smallest digit in the input number is: {2} 
The amount of digits in the in the input number that divided by 3 is: {3} 
The amount of digits in the input number that are bigger than the unity digit is: {4} ", args);

            return message;
        }
    }
}
