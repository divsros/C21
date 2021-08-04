using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_03
{
    class program
    {
        public static void Main()
        {
            StringBuilder str = new StringBuilder();
            DynamicClock(ref str);
        }


        public static bool ValidHeightInput(string i_Str)
        {
            bool validInput = false;

            validInput = int.TryParse(i_Str, out int number);
            if (number < 1)
            {
                validInput = false;
            }

            return validInput;
        }
        public static void DynamicClock(ref StringBuilder o_Str)
        {
            bool validInput = false;
            while (validInput != true)
            {
                System.Console.WriteLine("Enter height for the clock");
                string o_Length = System.Console.ReadLine();
                validInput = ValidHeightInput(o_Length);
                if (validInput == true)
                {
                    C21_Ex01_02.sandClock.CreateSandClock(ref o_Str, int.Parse(o_Length));
                    System.Console.WriteLine(o_Str);
                }
                else
                {
                    System.Console.Clear();
                    System.Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
