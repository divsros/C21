using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{
    class FourInARowGame
    {

        private Player player1;
        private Player player2;
        private int[,] board;
        private string winner;



        public FourInARowGame(Player i_Player1, Player i_Player2)
        {
            player1.Sign = i_Player1.Sign;
            player2.Sign = i_Player2.Sign;
            winner = string.Empty;
        }
        public void setBoard(int i_Rows, int i_Cols)
        {
            if (i_Rows > 0 && i_Cols > 0)
            {
                board = new int[i_Rows, i_Cols];
            }
        }
  
        public Player Player1
        {
            get 
            {
                return player1;
            }

            set
            {
                //if (typeof(Player) == value)
                {
                    player1 = value;
                }
            }

        }

        public Player Player2
        {
            get
            {
                return player2;
            }

            set
            {
                //if (typeof(Player) == value)
                {
                    player2 = value;
                }
            }

        }

        public string Winner
        {
            get
            {
                return winner;
            }

            set
            {
                //if (typeof(Player) == value)
                {
                    winner = value;
                }
            }

        }


        public bool validMove() { return true; }//need to write


    }

}
