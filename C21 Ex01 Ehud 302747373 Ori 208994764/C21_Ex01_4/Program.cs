using System;

namespace C21_Ex01_4
{
    class Program
    {
        public static void Main()
        {
            stringAnalysis();
        }

        private static void stringAnalysis()
        {
            string isDevideBy4Str = "No";
            string isPalindromStr = "No";
            int amountUpercaseletter = 0;

            Console.WriteLine("Please enter a string of 8 chars - contains either only numbers or only letters");
            string inputStr = Console.ReadLine();

            bool inputIsValid = checkInputValidity(inputStr);
            while(inputIsValid == false)
            {
                Console.WriteLine("There is a problem with your string. Please try again");
                inputStr = Console.ReadLine();
            }
            
            if(Char.IsDigit(inputStr[0]))
            {
                bool devideBy4 = int.Parse(inputStr) % 4 == 0;
                if(devideBy4 == true)
                {
                    isDevideBy4Str = "Yes";
                }
            }
            else
            {
                amountUpercaseletter = countUpperCase(inputStr);
            }

            bool strIsPalindrom = isPalindrom(inputStr, 0, inputStr.Length - 1);
            if (strIsPalindrom == true)
            {
                isPalindromStr = "Yes";
            }

            string message = createFormatMessege(inputStr, isPalindromStr, isDevideBy4Str, amountUpercaseletter);
            Console.WriteLine(message);

            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }

        private static bool checkInputValidity(string i_strForChecking)
        {
            if (i_strForChecking.Length != 8)
            {
                return false;
            }

            for (int i = 0; i < i_strForChecking.Length; i++)
            {
                char currentReadChar = i_strForChecking[i];
                if (!Char.IsLetter(currentReadChar))
                {
                    if (!Char.IsDigit(currentReadChar))
                    {
                        return false;
                    }
                }
            }
            
            return (checkIfStrContainOnlyDigits(i_strForChecking) || checkIfStrContainOnlyLetters(i_strForChecking));
        }

        private static bool checkIfStrContainOnlyDigits(string i_strForChecking)
        {
            for (int i = 0; i < i_strForChecking.Length; i++)
            {
                char currentReadChar = i_strForChecking[i];
                if (!Char.IsDigit(currentReadChar))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool checkIfStrContainOnlyLetters(string i_strForChecking)
        {
            for (int i = 0; i < i_strForChecking.Length; i++)
            {
                char currentReadChar = i_strForChecking[i];
                if (Char.IsDigit(currentReadChar))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isPalindrom(string i_strForChecking, int i_startCharIndex, int i_endCharIndex)
        {
            if(i_startCharIndex == i_endCharIndex)
            {
                return true;
            }

            if(i_strForChecking[i_startCharIndex] != i_strForChecking[i_endCharIndex])
            {
                return false;
            }

            if (i_startCharIndex < i_endCharIndex + 1)
            {
                return isPalindrom(i_strForChecking, i_startCharIndex + 1, i_endCharIndex - 1);
            }

            return true;
        }

        private static int countUpperCase(string i_inputStr)
        {
            int amountUpercaseletter = 0;
            for (int i = 0; i < i_inputStr.Length; i++)
            {
                char currentReadChar = i_inputStr[i];
                if (currentReadChar >= 'A' && currentReadChar <= 'Z')
                {
                    amountUpercaseletter = amountUpercaseletter + 1;
                }
            }

            return amountUpercaseletter;
        }

        private static string createFormatMessege(string i_inputStr, string i_isPalindromStr, string i_isDevideBy4Str, int i_mountUpercaseletter)
        {
            object[] args = new object[4];
            args[0] = i_inputStr;
            args[1] = i_isPalindromStr;
            args[2] = i_isDevideBy4Str;
            args[3] = i_mountUpercaseletter;

            string message = string.Format(
                @"The string that you wrote is: {0}
The input string is a palindrom: {1}
The input string is a number that divided by 4: {2}
The amount of uppercase letters in thr input string (in case of input that contains only letters) is: {3}", args);

            return message;
        }
    }
}
