using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex01_04
{
    class Program
    {
        public static void Main()
        {
            int number = 0;
            StringBuilder printData = new StringBuilder();
            string inputStr = getUserStr();
            bool isNumber = int.TryParse(inputStr, out number);

            palindromTest(ref inputStr, ref printData);
            if (isNumber == true)
            {
                divisionByFourTeast(number, ref printData);
            }
            else
            {
                int numOfUpperCases = NumOfUpperCases(inputStr);
                printData.AppendFormat("The number of upper cases in the string: {0} \n", numOfUpperCases);
            }

            System.Console.WriteLine(printData);
        }

        public static void divisionByFourTeast(int i_Number, ref StringBuilder i_Result)
        {

            if (CheckIfDividedByFour(i_Number) == true)
            {
                i_Result.AppendFormat("The string: \"{0}\" is divided by four\n", i_Number);
            }
            else
            {
                i_Result.AppendFormat("The string: \"{0}\" is not divided by four\n", i_Number);
            }


        }
        public static void palindromTest(ref string i_Str, ref StringBuilder i_Result)
        {
            bool isPalindrom = CheckIfPalindrom(i_Str, i_Str.Length);

            if (isPalindrom == true)
            {
                i_Result.AppendFormat("The string: \"{0}\" is a palindrom\n", i_Str);
            }
            else
            {
                i_Result.AppendFormat("The string: \"{0}\" is not a palindrom\n", i_Str);
            }

        }
        public static bool CheckIfStrValid(string i_Str)
        {
            bool isValid = true;
            const int k_NumOfCharacters = 8;

            if (i_Str.Length != k_NumOfCharacters)
            {
                isValid = false;
            }

            isValid = int.TryParse(i_Str, out int ignore);
            if (isValid == false)
            {
                for (int i_Index = 0; i_Index < i_Str.Length; i_Index++)
                {
                    char i_Letter = i_Str[i_Index];
                    if ((i_Letter >= 'a' && i_Letter <= 'z') || (i_Letter >= 'A' && i_Letter <= 'Z'))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }



        public static bool CheckIfPalindromRec(string i_Str, int i_StrLength, int i_Start, int i_End)
        {
            bool isPalindrom;

            if (i_StrLength == 2)
            {
                isPalindrom = i_Str[i_Start] == i_Str[i_End];
            }
            else
            {
                if (i_Str[i_Start] == i_Str[i_End])
                {
                    isPalindrom = CheckIfPalindromRec(i_Str, i_StrLength - 2, i_Start + 1, i_End - 1);
                }
                else
                {
                    isPalindrom = false;
                }
            }

            return isPalindrom;
        }
        public static bool CheckIfDividedByFour(int i_Number)
        {
            return i_Number % 4 == 0;
        }

        public static bool CheckIfPalindrom(string i_Str, int i_StrLength)
        {
            int i_Start = 0;
            int i_End = i_StrLength - 1;

            return CheckIfPalindromRec(i_Str, i_StrLength, i_Start, i_End);
        }

        public static int NumOfUpperCases(string i_Str)
        {
            int numOfUpperCases = 0;
            int i_StrLength = i_Str.Length;

            for (int i = 0; i < i_StrLength; i++)
            {
                if (i_Str[i] >= 'A' && i_Str[i] <= 'Z')
                {
                    numOfUpperCases++;
                }
            }

            return numOfUpperCases;
        }

        public static string getUserStr()
        {
            string i_Inpute = string.Empty;
            bool io_ValidInput = false;

            while (io_ValidInput != true)
            {
                System.Console.WriteLine("please enter an 8 characters's string which contains only english letters");
                i_Inpute = System.Console.ReadLine();
                io_ValidInput = CheckIfStrValid(i_Inpute);
                if (io_ValidInput == false)
                {
                    System.Console.Clear();
                    System.Console.WriteLine("Invalid input");
                }
            }

            return i_Inpute;
        }


    }
}
