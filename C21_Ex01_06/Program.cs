using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Ex01_6
{
    class Program
    {
        public static void Main()
        {
            bool isValid = false;
            StringBuilder dataStr = new StringBuilder();

            while (isValid == false)
            {
                System.Console.WriteLine("Please enter a 9 digits number.");
                string strNum = System.Console.ReadLine();
                isValid = CheckIfVallid(strNum);
                if (isValid == true) 
                {
                    dataStr.AppendFormat("The string: \"{0}\" has:", strNum);
                    AddNumOfDigDividedByThree(ref strNum, ref dataStr);
                    AddNumOfDigBiggerThenLeastSigBit(ref strNum, ref dataStr);
                    AddMaxDigit(ref strNum, ref dataStr);
                    AddMinDigit(ref strNum, ref dataStr);
                }
                else
                {
                    System.Console.WriteLine("Wrong input, please try againe.");
                }
            }

            System.Console.WriteLine(dataStr);
        }

        public static void AddNumOfDigDividedByThree(ref string i_StrNum, ref StringBuilder o_DataStr)
        {
            int numOfDigDividedByThree = GetNumOfGigDividedByThree(i_StrNum);
            o_DataStr.AppendFormat("{0} digits divided by 3 ,", numOfDigDividedByThree);
        }

            public static void AddNumOfDigBiggerThenLeastSigBit(ref string i_StrNum, ref StringBuilder o_DataStr)
        {
            int numOfDigBiggerThenLeastSigBit = GetNumOfDigBiggerThenLeastSigBit(i_StrNum);
            o_DataStr.AppendFormat("{0} digits bigger then the least significant bit.\n", numOfDigBiggerThenLeastSigBit);
        }

        public static void AddMaxDigit(ref string i_StrNum,ref StringBuilder o_DataStr)
        {
            int maxDig = GetMaxDig(i_StrNum);
            o_DataStr.AppendFormat("The max digits in the string is: {0}.\n", maxDig);
        }

        public static void AddMinDigit(ref string i_StrNum, ref StringBuilder o_DataStr)
        {
            int minDig = GetMinDig(i_StrNum);
            o_DataStr.AppendFormat("The min digits in the string is: {0}.\n",minDig);
        }

            public static bool CheckIfVallid(string i_Str)
            {
                bool isValid = true;
                int strLength = i_Str.Length;
                const int k_NumOfDigits = 9;

                if (strLength != k_NumOfDigits)
                {
                    isValid = false;
                }
                else
                {
                    for (int i = 0; i < strLength; i++)
                    {
                        if (i_Str[i] < '0' || i_Str[i] > '9')
                        {
                            isValid = false;
                        }
                    }
                }

                return isValid;
            }

            public static int GetMaxDig(string i_StrNum)
            {
                int strLength = i_StrNum.Length;

                int end = strLength - 2;
                int maxDig = (int)char.GetNumericValue(i_StrNum, 0);

                for (int i = 0; i <= end; i++)
                {
                    if (char.GetNumericValue(i_StrNum, i + 1) >= maxDig)
                    {
                        maxDig = (int)char.GetNumericValue(i_StrNum, i + 1);
                    }
                }

                return maxDig;
            }
            public static int GetMinDig(string i_StrNum)
            {
                int strLength = i_StrNum.Length;
                int end = strLength - 2;
                int minDig = (int)char.GetNumericValue(i_StrNum, 0);

                for (int i = 0; i < end; i++)
                {
                    if (char.GetNumericValue(i_StrNum, i + 1) <= minDig)
                    {
                        minDig = (int)char.GetNumericValue(i_StrNum, i + 1);
                    }
                }

                return minDig;
            }

            public static int GetNumOfGigDividedByThree(string i_StrNum)
            {
                int strLength = i_StrNum.Length;
                int numOfDigDividedByThree = 0;

                for (int i = 0; i < strLength; i++)
                {
                    if (i_StrNum[i] % 3 == 0)
                    {
                        numOfDigDividedByThree++;
                    }
                }

                return numOfDigDividedByThree;
            }

            public static int GetNumOfDigBiggerThenLeastSigBit(string i_StrNum)
            {
                int strLength = i_StrNum.Length;
                int end = strLength - 1;
                int leastSignificantBit = i_StrNum[end];
                int numOfDigBiggerThenLeastSigBit = 0;

                for (int i = 0; i < strLength; i++)
                {
                    if (i_StrNum[i] > leastSignificantBit)
                    {
                        numOfDigBiggerThenLeastSigBit++;
                    }
                }

                return numOfDigBiggerThenLeastSigBit;
            }
        
    


    }
}