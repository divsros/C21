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
            FourInARowGame theGame=null;
            Menu.initialTheGame(ref theGame);
            UI.PrintBoard(theGame.getBoard());
        }
    }

}
