using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_01
{
    class program
    {
        public static void Main()
        {
            StringBuilder resultStr = new StringBuilder();
            List<string> numbersStr = new List<string>();
            GetThreeNumberInput(ref numbersStr, ref resultStr);
            Statistics(ref numbersStr, ref resultStr);
            System.Console.WriteLine(resultStr);
        }


        public static void GetThreeNumberInput(ref List<string> i_Numbers, ref StringBuilder o_ResultStr)
        {
            for (int i = 1; i <= 3; i++)
            {
                bool validNumber = false;
                double number = 0;
                string numberStr = string.Empty;

                while (validNumber != true)
                {
                    validNumber = true;
                    System.Console.WriteLine("Enter 9 digit Number " + i + ".");
                    numberStr = System.Console.ReadLine();
                    System.Console.Clear();
                    if (numberStr.Length != 9 || double.TryParse(numberStr, out number) == false)
                    {
                        validNumber = false;
                        System.Console.WriteLine("Invalid input");
                    }

                    for (int j = 0; j < numberStr.Length; j++)
                    {
                        if (numberStr[j] != '1' && numberStr[j] != '0') 
                        {
                            validNumber = false;
                        }
                    }
                }

                i_Numbers.Add(numberStr);
                number = BinaryToDecimal(numberStr);
                o_ResultStr.AppendFormat("Number {0}. is: {1}\n", i, number);
            }
        }
        public static void Statistics(ref List<string> i_Numbers, ref StringBuilder o_ResultStr)
        {
            AverageZerosAndOnes(ref i_Numbers, ref o_ResultStr);
            NumbersWhichPowerOfTwo(ref i_Numbers, ref o_ResultStr);
            RisingNumbersCount(ref i_Numbers, ref o_ResultStr);
            AddBiggestNumberToStatistics(ref i_Numbers, ref o_ResultStr);
            AddSmallestNumberToStatistics(ref i_Numbers, ref o_ResultStr);
        }

        public static double BinaryToDecimal(string i_Str)
        {
            double decimalNumber = 0;
            double pow = i_Str.Length;

            for (int i = 0; i < i_Str.Length; i++)
            {
                pow--;
                char digit = i_Str[i];
                if (digit == '1')
                    decimalNumber += Math.Pow(2, pow);
            }

            return decimalNumber;
        }

        public static void NumbersWhichPowerOfTwo(ref List<string> i_Numbers, ref StringBuilder o_ResultStr)
        {
            int powOfTwoCount = 0;

            foreach (string str in i_Numbers)
            {
                bool powOfTwo = PowerOfTwo(str);
                if (powOfTwo == true)
                    powOfTwoCount++;
            }

            o_ResultStr.AppendFormat("There are {0} numbers which are power of two\n", powOfTwoCount);
        }
        public static bool PowerOfTwo(string i_Str)
        {
            bool done = false;
            int power = 0;

            double number = BinaryToDecimal(i_Str);
            while (done != true)
            {
                if (number / Math.Pow(2, power) == 1)
                    return true;
                if (number / Math.Pow(2, power) < 1)
                    return false;
                power++;
            }

            return false;
        }
        public static void RisingNumbersCount(ref List<string> i_Numbers, ref StringBuilder o_ResultStr)
        {
            int risingNumbersCount = 0;

            foreach (string io_Str in i_Numbers)
            {
                risingNumbersCount += RisingDigits(io_Str);
            }

            o_ResultStr.AppendFormat("The are {0} rising numbers\n", risingNumbersCount);
        }
        public static int RisingDigits(string o_Str)
        {
            double i_CurrentDigit = 0;
            double i_Number = Math.Floor(BinaryToDecimal(o_Str));
            double i_LastDigit = Math.Floor(i_Number % 10);

            while (i_Number != 0)
            {
                i_CurrentDigit = Math.Floor(i_Number / 10 % 10);
                if (i_CurrentDigit >= i_LastDigit)
                    return 0;
                i_Number = Math.Floor(i_Number / 10);
            }

            return 1;
        }
        public static double SmallestNumber(ref List<string> i_Numbers)
        {
            double i_Smallest = BinaryToDecimal(i_Numbers[0]);

            foreach (string o_Str in i_Numbers)
            {
                double i_CurrentNumber = BinaryToDecimal(o_Str);
                if (i_CurrentNumber < i_Smallest)
                    i_Smallest = i_CurrentNumber;
            }

            return i_Smallest;
        }
        public static void AddSmallestNumberToStatistics(ref List<string> i_Numbers, ref StringBuilder o_ResultStr)
        {
            double smallest = SmallestNumber(ref i_Numbers);

            o_ResultStr.AppendFormat("The smallest number is: {0}\n", smallest);
        }
        public static double BiggestNumber(ref List<string> i_Numbers)
        {
            if (i_Numbers.Count == 0)
            {
                System.Console.WriteLine("No numbers entered");
                return 0;
            }

            double biggest = BinaryToDecimal(i_Numbers[0]);

            foreach (string str in i_Numbers)
            {
                double currentNumber = BinaryToDecimal(str);
                if (currentNumber > biggest)
                    biggest = currentNumber;
            }

            return biggest;
        }
        public static void AddBiggestNumberToStatistics(ref List<string> o_Numbers, ref StringBuilder io_ResultStr)
        {
            double i_Biggest = BiggestNumber(ref o_Numbers);

            io_ResultStr.AppendFormat("The biggest number is: {0}\n", i_Biggest);
        }
        public static void AverageZerosAndOnes(ref List<string> i_Numbers, ref StringBuilder o_ResultStr)
        {
            float i_Zeroes = TotalZeros(ref i_Numbers);
            float i_Ones = TotalOnes(ref i_Numbers);
            float i_AverageZeroes = i_Zeroes / i_Numbers.Count;
            float i_AverageOnes = i_Ones / i_Numbers.Count;

            o_ResultStr.AppendFormat("The amount of zeroes is: {0}\n", i_Zeroes);
            o_ResultStr.AppendFormat("The amount of ones is {0}\n", i_Ones);
            o_ResultStr.AppendFormat("The average zeros in each number is: {0}\n", i_AverageZeroes);
            o_ResultStr.AppendFormat("The average ones in each number is: {0}\n", i_AverageOnes);
        }
        public static float TotalZeros(ref List<string> i_Numbers)
        {
            float zeroCount = 0;

            foreach (string str in i_Numbers)
            {
                foreach (char letter in str)
                {
                    if (letter == '0')
                    {
                        zeroCount++;
                    }
                }
            }

            return zeroCount;
        }

        public static float TotalOnes(ref List<string> i_Numbers)
        {
            float onesCount = 0;

            foreach (string str in i_Numbers)
            {
                foreach (char letter in str)
                {
                    if (letter == '1')
                    {
                        onesCount++;
                    }
                }
            }

            return onesCount;
        }
    }
}
