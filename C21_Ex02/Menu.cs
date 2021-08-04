using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{

    static class Menu
    {
        enum MenuOptions
        {
            newGame = '1', printInstructions, exitGame
        }
        public static void MainMenu()
        {
            bool validChoise = false;
            while (validChoise != true)
            {
                System.Console.WriteLine("Welcome To Four In A Row game!");
                System.Console.WriteLine("1.start a new game");
                System.Console.WriteLine("2.Print the instruction");
                System.Console.WriteLine("3.Exit the game");
                int choise1 = Convert.ToInt32(System.Console.ReadLine());
                int choise = Convert.ToInt32(System.Console.ReadLine());
                if (choise == (int)MenuOptions.newGame)
                {
                    newGame();
                    validChoise = true;
                }
                else if (choise == (int)MenuOptions.printInstructions)
                {
                    GameInstructions();
                    validChoise = true;
                }

                else if (choise == (int)MenuOptions.exitGame)
                {
                    ExitGame();
                    validChoise = true;
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    System.Console.WriteLine("Invalid input");
                }

                /* switch (choise)
                 {
                     case MenuOptions.newGame:
                         newGame();
                         validChoise = true;
                         break;
                     case MenuOptions.printInstructions:
                         GameInstructions();
                         validChoise = true;
                         break;
                     case MenuOptions.exitGame:
                         ExitGame();
                         validChoise = true;
                         break;
                       default:
                         Ex02.ConsoleUtils.Screen.Clear();
                         System.Console.WriteLine("Invalid input");
                         break;
                 }*/
                ClearBuffer();
            }


        }

        public static void newGame()
        {
            //Ex02.ConsoleUtils.Screen.Clear();
            FourInARowGame theGame = null;
            Menu.initialTheGame(ref theGame);
            UI.PrintBoard(theGame.getBoard());

        }
        public static void initialTheGame(ref FourInARowGame o_Game)
        {
            initialThePlayers(ref o_Game);
            initialBoard(ref o_Game);
        }
        public static void initialThePlayers(ref FourInARowGame o_Game)
        {
            int numberCount = 0;
            bool validPlayers = false;
            while (validPlayers != true)
            {
                
                System.Console.WriteLine("For two Human players press 2, to player against the computer press 1");
                //ClearBuffer();
                string test = System.Console.ReadLine();
              //  numberCount = System.Console.Read();
                if (numberCount != '1' && numberCount != '2')
                {
                    validPlayers = false;
                }
                if (validPlayers == false)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    System.Console.WriteLine("Invalid input");
                }
            }
            Player Player1 = new Player();
            if (numberCount == 1)
            {
                ComputerPlayer Player2 = new ComputerPlayer('O');
                o_Game = new FourInARowGame(Player1, Player2);
            }
            else
            {
                Player Player2 = new Player('O');
                o_Game = new FourInARowGame(Player1, Player2);
            }

            ClearBuffer();
        }
        public static void initialBoard(ref FourInARowGame o_Game)
        {
            int cols = 0;
            int rows = 0;
            bool validRows = false;
            bool validCols = false;

            while (validRows != true)
            {
                System.Console.Write("Enter how many rows you want (4-8)");
                string rowsStr = System.Console.ReadLine();
                validRows = int.TryParse(rowsStr, out rows);
                if (rows < 4 || rows > 8)
                {
                    validRows = false;
                }

            }

            while (validCols != true)
            {
                System.Console.Write("Enter how many colums you want (4-8)");
                string colsStr = System.Console.ReadLine();
                validCols=int.TryParse(colsStr, out cols);
                if (cols < 4 || cols > 8)
                {
                    validCols = false;
                }

            }
            o_Game.initialBoard(rows, cols);
        }


        public static void GameInstructions() { }////need to write

        public static void ExitGame() { }//need to write


        public static void ClearBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false); // true = hide input
            }
            Console.ReadKey();
        }


    }
}
