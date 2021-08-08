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
            player2 = new Player(i_Player2.Sign);
            winner = string.Empty;
        }

        public void initialBoard(int i_Rows, int i_Cols)
        {
            if (i_Rows > 0 && i_Cols > 0)
            {
                board = new char[i_Rows, i_Cols];
                for (int i = 0; i < i_Rows; i++)
                {
                    for (int j = 0; j < i_Cols; j++)
                    {
                        board[i, j] = ' ';
                    }
                }
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

        public char[,] Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
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
            if (i_Col >= 0 && i_Col < board.GetLength(1))
            {
                validCol = true;
            }

            return validCol;
        }
        public bool validRow(int i_Row)
        {
            bool validRow = false;

            if (i_Row > 0 && i_Row < board.GetLength(0))
            {
                validRow = true;
            }

            return validRow;
        }

        public bool IsOnBoard(Point i_MatrixPoint)
        {
            bool onBoard = false;
            bool isValidColum = validCol(i_MatrixPoint.X);
            bool isValidRow = validRow(i_MatrixPoint.Y);

            if (isValidColum == true && isValidRow == true)
            {
                onBoard = true;
            }

            return onBoard;
        }

///////////////////////////Check For Victory funcs///////////////////////////////

        public bool StopCheckForAFour(Point i_MatrixPoint, Player i_Player)
        {
            bool stopCheck = !IsOnBoard(i_MatrixPoint);

            if (stopCheck == false)
            {
                if (board[i_MatrixPoint.Y, i_MatrixPoint.X] != i_Player.Sign)
                {
                    stopCheck = true;
                }
            }

            return stopCheck;
        }

        public bool CheckIfWon(Player i_Player, Point i_LastMove)
        {
            bool isWon = false;
            if (CheckRow(i_Player, i_LastMove) == true)
            {
                isWon = true;
            }
            if (CheckDiagonals(i_LastMove, i_Player) == true)
            {
                isWon = true;
            }
            else if (CheckColum(i_Player, i_LastMove) == true)
            {
                isWon = true;
            }

            return isWon;
        }
        public bool CheckLeftDiagonal(Point i_MatrixPoint, Player i_Player)
        {
            int signCount = 1;
            bool checkRightDown = true, checkUpRLeft = true, diagonalFourInARow = false;
            Point currentPoint = i_MatrixPoint;

            while (checkRightDown == false)
            {
                currentPoint.AddValues(1, 1);
                checkRightDown = StopCheckForAFour(currentPoint, i_Player);
                if (checkRightDown == false)
                {
                    signCount++;
                }
            }

            currentPoint = i_MatrixPoint;
            while (checkUpRLeft == false)
            {
                currentPoint.AddValues(-1, -1);
                checkRightDown = StopCheckForAFour(currentPoint, i_Player);
                if (checkRightDown == false)
                {
                    signCount++;
                }
            }

            if (signCount >= 4)
            {
                diagonalFourInARow = true;
            }

            return diagonalFourInARow;
        }

        public bool CheckRightDiagonal(Point i_MatrixPoint, Player i_Player)
        {
            int signCount = 1;
            bool checkRightUp = true, checkLeftDown = true, diagonalFourInARow = false;
            Point currentPoint = i_MatrixPoint;

            while (checkRightUp == false)
            {
                currentPoint.AddValues(1, -1);
                checkRightUp = StopCheckForAFour(currentPoint, i_Player);
                if (checkRightUp == false)
                {
                    signCount++;
                }
            }

            currentPoint = i_MatrixPoint;
            while (checkLeftDown == false)
            {
                currentPoint.AddValues(-1, 1);
                checkLeftDown = StopCheckForAFour(currentPoint, i_Player);
                if (checkLeftDown == false)
                {
                    signCount++;
                }
            }

            if (signCount >= 4)
            {
                diagonalFourInARow = true;
            }

            return diagonalFourInARow;
        }

        public bool CheckDiagonals(Point i_MatrixPoint, Player i_Player)
        {
            bool isWin = false;
            bool leftDiagonal = CheckLeftDiagonal(i_MatrixPoint, i_Player);
            bool rightDiagonal = CheckRightDiagonal(i_MatrixPoint, i_Player);
            if (leftDiagonal == true || rightDiagonal == true)
            {
                isWin = true;
            }
            return isWin;
        }

        public bool CheckRow(Player i_Player, Point i_LastMove)
        {
            bool isThereFourCoins = false;
            int coinsCount = 0;
            int currentCol = i_LastMove.X;
            int i = 0;

            while (i <= 3 && currentCol < board.GetLength(0))
            {
                while (currentCol >= 0 && board[i_LastMove.Y, currentCol] == i_Player.Sign)
                {
                    coinsCount++;
                    currentCol--;
                    if (coinsCount == 4)
                    {
                        isThereFourCoins = true;
                    }
                }

                i++;
                currentCol = i_LastMove.X + i;
                coinsCount = 0;
            }

            return isThereFourCoins;
        }
        public bool CheckColum(Player i_Player, Point i_LastMove)
        {
            bool stopCheckingDown = false;
            bool isThereFourCoins = false;
            int coinsCount = 1;
            Point currentPosition = i_LastMove;

            while (stopCheckingDown != true)
            {
                currentPosition.AddValues(0, 1);
                if (StopCheckForAFour(currentPosition, i_Player) != true)
                {
                    coinsCount++;
                }
                else
                {
                    stopCheckingDown = true;
                }

            }
            if (coinsCount >= 4)
            {
                isThereFourCoins = true;
            }

            return isThereFourCoins;
        }


///////////////////////////
        public bool GetRowToInput(int i_MatrixCol, out int io_MatrixRow)
        {
            io_MatrixRow = 0;
            bool validRowFound = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                io_MatrixRow = board.GetLength(0) - i - 1;
                if (board[io_MatrixRow, i_MatrixCol] == ' ')
                {
                    validRowFound = true;
                    break;
                }
            }

            return validRowFound;
        }

        public bool SetMove(int i_MatrixCol, Player i_Player, out int o_MatrixRow)
        {

            int matrixRow;
            bool validInput = false;

            o_MatrixRow = -1;
            if (validCol(i_MatrixCol) == true)
            {

                if (GetRowToInput(i_MatrixCol, out matrixRow) == true)
                {
                    board[matrixRow, i_MatrixCol] = i_Player.Sign;
                    o_MatrixRow = matrixRow;
                    validInput = true;
                }
            }

            return validInput;
        }

        public bool CheckIfDraw(Point i_LastMove)
        {
            bool isDraw = false;
            if (i_LastMove.Y == 0)
            {
                isDraw = true;
            }

            return isDraw;
        }


        public bool CheckIfGameOver(Player i_Player, Point i_LastMove)
        {
            bool isGameOver = false;

            if (CheckIfWon(player1, i_LastMove) == true)
            {
                //UI.PrintMsg(player1Wins);
                isGameOver = true;
            }
            else if (CheckIfWon(player2, i_LastMove) == true)///נגעתי בטעות אני מניח
            {
                //UI.PrintMsg(player2Wins);
                isGameOver = true;
            }
            else if (CheckIfDraw(i_LastMove) == true)
            {
                //UI.PrintMsg(Draw);
                isGameOver = true;
            }
            return isGameOver;
        }



        public Point turnOf(Player i_Player)
        {
            bool isEnded = false;
            string strColInput = string.Empty;
            int intColInput;
            int MatrixRow = 0;
            bool isGameOver = false;
            Point lastMove = new Point();
            lastMove.X = 0;
            lastMove.Y = 0;
            lastMove.SetPoint(0, 0);
            
            while (isEnded == false)
            {
                strColInput = System.Console.ReadLine();

                if (int.TryParse(strColInput, out intColInput) == true)
                {
                    isEnded = true;
                    int matrixCol = intColInput - 1;
                    SetMove(matrixCol, i_Player,out MatrixRow);
                    Ex02.ConsoleUtils.Screen.Clear();
                    //UI.PrintInstruction();
                    UI.PrintBoard(board);
                    lastMove.SetPoint(matrixCol, MatrixRow);
                }
                else
                {
                    //UI.PrintErrorMsg(inValidColumn);
                }
            }
            return lastMove;
        }

        public void RunGame()
        {
            bool isGameOver = false;
            Point lastMove;
            while (isGameOver == false)
            {
                lastMove = turnOf(Player1);
                isGameOver = CheckIfGameOver(player1, lastMove);
                if(isGameOver == true)
                {
                    break;
                }

                lastMove = turnOf(Player2);
                isGameOver = CheckIfGameOver(player2, lastMove);
            }

            //UI.EndGame();
        }
    }

}


  
