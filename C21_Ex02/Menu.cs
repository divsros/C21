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
            newGame = 1, printInstructions, exitGame
        }

        enum Enemy
        {
           Computer=1, Human
        }

        public static void MainMenu()
        {
            int menuChoise = 0;
            bool validChoise = false;
            FourInARowGame game = null;

            while (validChoise != true)
            {
                System.Console.WriteLine("Welcome To Four In A Row game!");
                System.Console.WriteLine("1.start a new game");
                System.Console.WriteLine("2.Print the instruction");
                System.Console.WriteLine("3.Exit the game");
                string choiseStr = System.Console.ReadLine();
                int.TryParse(choiseStr, out menuChoise);
                if (menuChoise == (int)MenuOptions.newGame)
                {
                    game = newGame();
                    validChoise = true;
                }
                else if (menuChoise == (int)MenuOptions.printInstructions)
                {
                    GameInstructions();
                    validChoise = true;
                }

                else if (menuChoise == (int)MenuOptions.exitGame)
                {
                    ExitGame();
                    validChoise = true;
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    System.Console.WriteLine("Invalid input");
                }
                /*
               switch (choise)
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
                }
                */
            }
        }

        public static FourInARowGame newGame()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            FourInARowGame theGame = null;
            Menu.initialTheGame(ref theGame);
            UI.PrintBoard(theGame.Board);

            return theGame;
        }

        public static void initialTheGame(ref FourInARowGame o_Game)
        {
            initialThePlayers(ref o_Game);
            Ex02.ConsoleUtils.Screen.Clear();
            initialBoard(ref o_Game);
        }

        public static void initialThePlayers(ref FourInARowGame o_Game)
        {
            int humanPlayers = 0;
            bool validPlayers = false;
            while (validPlayers != true)
            { 
                System.Console.WriteLine("1.Play against the computer\n2.Play against a friend");
                string humanPlayersStr = System.Console.ReadLine();
                int.TryParse(humanPlayersStr,out humanPlayers);
                if (humanPlayers == (int)Enemy.Computer || humanPlayers == (int)Enemy.Human)
                {
                    validPlayers = true;
                }
                if (validPlayers == false)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    System.Console.WriteLine("Invalid input");
                }
            }
            Player Player1 = new Player();
            if (humanPlayers == (int)Enemy.Computer)
            {
                ComputerPlayer Player2 = new ComputerPlayer('O');
                o_Game = new FourInARowGame(Player1, Player2);
            }
            else if(humanPlayers == (int)Enemy.Human)
            {
                Player Player2 = new Player('O');
                o_Game = new FourInARowGame(Player1, Player2);
            }
        }

        public static void initialBoard(ref FourInARowGame o_Game)
        {
            int cols = 0;
            int rows = 0;
            bool validRows = false;
            bool validCols = false;

            while (validRows != true)
            {
                System.Console.Write("Enter how many rows you want (4-8):");
                string rowsStr = System.Console.ReadLine();
                validRows = int.TryParse(rowsStr, out rows);
                if (rows < 4 || rows > 8)
                {
                    validRows = false;
                }

            }

            while (validCols != true)
            {
                System.Console.Write("Enter how many colums you want (4-8):");
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

    }
}
