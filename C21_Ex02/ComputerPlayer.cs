using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{
    public class ComputerPlayer : Player
    {

        public ComputerPlayer(char i_Sign = 'O', int i_Points = 0)
        {
            this.Sign = i_Sign;
        }
/*
        public int computerBestMove(char[,] io_matrix)
        {
            int index = 0;
            bool didAMove = false;
           if (checkForWinningOption(io_matrix) == true)
            {
                didAMove = true;
            }



            return index;
        }
        public bool checkForWinningOption()
        {



        }*/


    }

}
