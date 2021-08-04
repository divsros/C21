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
        private char[,] board;
        private string winner;


        public FourInARowGame(Player i_Player1, ComputerPlayer i_Player2)
        {
            player1 = new Player(i_Player1.Sign);
            player2 = new ComputerPlayer(i_Player2.Sign);
        }
        public FourInARowGame(Player i_Player1, Player i_Player2)
        {
            player1 = new Player(i_Player1.Sign);
            player2= new Player(i_Player2.Sign);
            winner = string.Empty;
        }
        public void initialBoard(int i_Rows, int i_Cols)
        {
            if (i_Rows > 0 && i_Cols > 0)
            {
                board = new char[i_Rows, i_Cols];
            }
        }
    
        public char[,] getBoard()
        {
            return board;
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


        public bool validMove(int i_Col,Player i_Player)
        {
            bool validCol = false;
            bool validHeight = false;
            bool validInput = false;

            if (i_Col > 0 && i_Col < board.GetLength(1))
            {
                validCol = true;
            }

            if (validCol == true)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[i_Col, i] == ' ')
                    {
                        validHeight = true;
                        board[i_Col, i] = i_Player.Sign;
                    }
                }
            }

            if (validCol == true && validHeight == true)
            {
                validInput = true;
            }

            return validInput;
        }
    }

}
