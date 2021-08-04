using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = new int[5, 5];
            UI.PrintBoard(matrix);
            FourInARowGame theGame=null;
            Menu.initialTheGame(ref theGame);
        }
    }

}
