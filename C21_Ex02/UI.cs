using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{
    class UI
    {
        public static void PrintBoard(char[,] i_Board)
        {
            int signAmount = 1 + 4 * i_Board.GetLength(1);
            StringBuilder result = new StringBuilder();

            Ex02.ConsoleUtils.Screen.Clear();
            for (int i = 0; i < i_Board.GetLength(1); i++)
            {
                result.AppendFormat("  {0} ", i + 1);
            }
            result.AppendLine();
            for (int i = 0; i < i_Board.GetLength(0); i++)
            {
                for (int j = 0; j < i_Board.GetLength(1); j++)
                {
                    result.AppendFormat("| {0} ", i_Board.GetValue(i, j));
                }

                result.AppendLine("|");
                result.Append('=', signAmount);
                result.AppendLine();
            }
            System.Console.WriteLine(result);
        }
        public static void EndGame()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            System.Console.WriteLine("Game Over");
        }
        public static void PrintErrorMsg()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            System.Console.WriteLine("Invalid Colum");
        }
        public static void PrintInstruction()
        {
            Ex02.ConsoleUtils.Screen.Clear();

            System.Console.WriteLine("Enter a colum number you wish you choose which isnt full");
        }
        public static void PrintDraw()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            System.Console.WriteLine("Draw");
        }


    }
}
            

