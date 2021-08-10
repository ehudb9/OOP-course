﻿using System;
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
            BinaryAnalyze();
        }

        public static void BinaryAnalyze()
        {
            System.Console.WriteLine("Please enter 3 Binary numbers with 7 digits each:");
            string binaryNum1 = System.Console.ReadLine();
            while (!IsValidInput(binaryNum1))
            {
                System.Console.WriteLine("Invalid input\nPlease enter Binary numbers with 7 digits each:");
                binaryNum1 = System.Console.ReadLine();
            }
            string binaryNum2 = System.Console.ReadLine();
            while (!IsValidInput(binaryNum2))
            {
                System.Console.WriteLine("Invalid input\nPlease enter Binary numbers with 7 digits each:");
                binaryNum2 = System.Console.ReadLine();
            }
            string binaryNum3 = System.Console.ReadLine();
            while (!IsValidInput(binaryNum3))
            {
                System.Console.WriteLine("Invalid input\nPlease enter Binary numbers with 7 digits each:");
                binaryNum3 = System.Console.ReadLine();
            }
            int decimalNum1 = BinaryToDecimal(binaryNum1);
            int decimalNum2 = BinaryToDecimal(binaryNum2);
            int decimalNum3 = BinaryToDecimal(binaryNum3);
            System.Console.WriteLine("The numbers input in decilmal are:{0} , {1} , {2}" , decimalNum1, decimalNum2, decimalNum3);

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
            System.Console.WriteLine("The avarage of '1' is : {0} \n The avarage of '0' is : {1} ", onesCounter / 3, zerosCounter / 3);

            if (IsSeriesOfIncreasingNumber(decimalNum1))
            {
                increasingNumbersCounter++;
            }
            if (IsSeriesOfIncreasingNumber(decimalNum2))
            {
                increasingNumbersCounter++;
            }
            if (IsSeriesOfIncreasingNumber(decimalNum3))
            {
                increasingNumbersCounter++;
            }



            if (IsPowerOfTow(decimalNum1))
            {
                powerOfTowCounter++;
            }
            if (IsPowerOfTow(decimalNum2))
            {
                powerOfTowCounter++;
            }
            if (IsPowerOfTow(decimalNum3))
            {
                powerOfTowCounter++;
            }
            System.Console.WriteLine("There is a {0} of increasing numbers", increasingNumbersCounter);
            System.Console.WriteLine("There is a {0} numbers that is power of 2", powerOfTowCounter);
            System.Console.WriteLine("The Max number is:" + Math.Max(Math.Max(decimalNum1, decimalNum2), decimalNum3));
            System.Console.WriteLine("The Min number is:" + Math.Min(Math.Min(decimalNum1, decimalNum2), decimalNum3));

        }
        public static bool IsValidInput(string i_InputNumber)
        {
            int i_LenthOfInput = i_InputNumber.Length;
            bool i_ValidFlag = true;

            if (i_LenthOfInput != 7)
            {
                i_ValidFlag = false;
            }
            else
            {
                for (int i = 0; i < i_LenthOfInput; i++)
                {
                    if(i_InputNumber[i] != '0' && i_InputNumber[i] != '1')
                    {
                        i_ValidFlag = false;
                    }
                }
            }
            return i_ValidFlag;
        }
    }
    public static int BinaryToDecimal(string i_BinaryNum)
    {
        int i_DecimalNumber = 0;
        double i_Power = 0;
        for(int i = i_BinaryNum.Length - 1; i >= 0; i++)
        {
            i_Power = Math.Pow(2, i_BinaryNum.Length - i - 1);
            i_DecimalNumber += int.Parse(i_BinaryNum[i].ToString()) * i_Power;
        }
        return i_DecimalNumber;
    }

    public static bool IsSeriesOfIncreasingNumber(int i_ThreeDigitDecimal)
    {
        int i_Division = 10;
        bool i_IsIncreaseNumber = false;
        int i_Hundres = i_ThreeDigitDecimal / 100;
        int i_Units = i_ThreeDigitDecimal % 10;
        int i_Dozens = (i_ThreeDigitDecimal / 10) % 10;
        if(i_Hundres < i_Hundres && i_Hundres < i_Units)
        {
            i_IsIncreaseNumber = true;
        }
        return i_IsIncreaseNumber;

    }

    public static bool IsPowerOfTow(int i_ThreeDigitDecimal)
    {
        if(i_ThreeDigitDecimal == 0)
        {
            return false;
        }
        while(i_ThreeDigitDecimal != 1)
        {
            i_ThreeDigitDecimal /= 2;
            if(i_ThreeDigitDecimal % 2 && i_ThreeDigitDecimal != 1)
            {
                return false;
            }
        }
        return true;
    }
}
