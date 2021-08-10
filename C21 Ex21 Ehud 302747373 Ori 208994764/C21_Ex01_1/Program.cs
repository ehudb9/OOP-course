using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex01_1
{
    class Program
    {
        public static void Main()
        {
            binaryAnalyze();
        }

        private static void binaryAnalyze()
        {
            Console.WriteLine("Please enter 3 Binary numbers with 9 digits each:");
            string binaryNum1 = Console.ReadLine();

            while (!isValidInput(binaryNum1))
            {
                Console.WriteLine("Invalid input\nPlease enter Binary numbers with 9 digits each:");
                binaryNum1 = Console.ReadLine();
            }

            string binaryNum2 = Console.ReadLine();
            while (!isValidInput(binaryNum2))
            {
                Console.WriteLine("Invalid input\nPlease enter Binary numbers with 9 digits each:");
                binaryNum2 = Console.ReadLine();
            }

            string binaryNum3 = Console.ReadLine();
            while (!isValidInput(binaryNum3))
            {
                Console.WriteLine("Invalid input\nPlease enter Binary numbers with 9 digits each:");
                binaryNum3 = Console.ReadLine();
            }

            int decimalNum1 = binaryToDecimal(binaryNum1);
            int decimalNum2 = binaryToDecimal(binaryNum2);
            int decimalNum3 = binaryToDecimal(binaryNum3);

            int zerosCounter = 0;
            int onesCounter = 0;
            int powerOfTowCounter = 0;
            int increasingNumbersCounter = 0;

            string allInputTogether = binaryNum1 + binaryNum2 + binaryNum3;
            for (int i = 0; i < allInputTogether.Length; i++)
            {
                if(allInputTogether[i] == '0')
                {
                    zerosCounter++;
                }
                else
                {
                    onesCounter++;
                }
            }

            if (isSeriesOfIncreasingNumber(decimalNum1))
            {
                increasingNumbersCounter++;
            }
            if (isSeriesOfIncreasingNumber(decimalNum2))
            {
                increasingNumbersCounter++;
            }
            if (isSeriesOfIncreasingNumber(decimalNum3))
            {
                increasingNumbersCounter++;
            }

            if (isPowerOfTow(decimalNum1))
            {
                powerOfTowCounter++;
            }
            if (isPowerOfTow(decimalNum2))
            {
                powerOfTowCounter++;
            }
            if (isPowerOfTow(decimalNum3))
            {
                powerOfTowCounter++;
            }

            int maxNumber = Math.Max(Math.Max(decimalNum1, decimalNum2), decimalNum3);
            int minNumber = Math.Min(Math.Min(decimalNum1, decimalNum2), decimalNum3);

            string message = string.Format(
                @"The numbers input in decimal are: {0} , {1} , {2}
The average of '1' is : {3}
The average of '0' is : {4}
There are {5} increasing numbers
There are {6} numbers that are power of 2
The Max number is: {7}
The Min number is: {8}", decimalNum1, decimalNum2, decimalNum3, onesCounter / 3, zerosCounter / 3, increasingNumbersCounter, powerOfTowCounter, maxNumber, minNumber);
            
            Console.WriteLine(message);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();

        }
        private static bool isValidInput(string i_InputNumber)
        {
            int lengthOfInput = i_InputNumber.Length;
            bool validFlag = true;

            if (lengthOfInput != 9)
            {
                validFlag = false;
            }
            else
            {
                for (int i = 0; i < lengthOfInput; i++)
                {
                    if(i_InputNumber[i] != '0' && i_InputNumber[i] != '1')
                    {
                        validFlag = false;
                    }
                }
            }

            return validFlag;
        }
        private static int binaryToDecimal(string i_BinaryNum)
        {
            int decimalNumber = 0;

            for (int i = i_BinaryNum.Length - 1; i >= 0; i--)
            {
                int power = (int)(Math.Pow(2, i_BinaryNum.Length - i - 1));
                decimalNumber += int.Parse(i_BinaryNum[i].ToString()) * power;
            }

            return decimalNumber;
        }

        private static bool isSeriesOfIncreasingNumber(int i_ThreeDigitDecimal)
        {
            bool isIncreaseNumber = false;
            int hundreds = i_ThreeDigitDecimal / 100;
            int units = i_ThreeDigitDecimal % 10;
            int dozens = (i_ThreeDigitDecimal / 10) % 10;

            if (hundreds < dozens && dozens < units)
            {
                isIncreaseNumber = true;
            }

            return isIncreaseNumber;
        }

        private static bool isPowerOfTow(int i_ThreeDigitDecimal)
        {
            if (i_ThreeDigitDecimal == 0)
            {
                return false;
            }

            while (i_ThreeDigitDecimal != 1)
            {
                i_ThreeDigitDecimal /= 2;
                if (i_ThreeDigitDecimal % 2 == 1 && i_ThreeDigitDecimal != 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
    
}
