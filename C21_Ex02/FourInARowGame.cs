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

        public bool validCol(int i_Col)
        {
            bool validCol = false;
            if (i_Col > 0 && i_Col <= board.GetLength(1))
            {
                validCol = true;
            }

            return validCol; 
        }


        public bool GetRowToInput(int i_MatrixCol, out int io_MatrixRow)
        {
            io_MatrixRow = 0;
            bool validRowFound = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                io_MatrixRow = board.GetLength(0) - i - 1;
                if (board[i_MatrixCol, io_MatrixRow] == ' ')
                {
                    validRowFound = true;
                    break;
                }   
            }

            return validRowFound;
        }

        public bool SetMove(int i_MatrixCol,Player i_Player)
        {

            int matrixRow;
            bool validInput = false;

            if (validCol(i_MatrixCol) == true)
            {

                if (GetRowToInput(i_MatrixCol, out matrixRow) == true)
                {
                    board[i_MatrixCol, matrixRow] = i_Player.Sign;
                    validInput = true;
                } 
            }

            return validInput;
        }
    }

}
