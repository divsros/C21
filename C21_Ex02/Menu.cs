﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02
{
    static class Menu
    {
 

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
                System.Console.WriteLine("Welcome To Four In A Row game!");
                System.Console.WriteLine("For two Human players press 2, to player against the computer press 1");
                string playerNums = System.Console.ReadLine();
                validPlayers = int.TryParse(playerNums, out numberCount);
                if (numberCount != 1 && numberCount != 2)
                {
                    validPlayers = false;
                }
                if (validPlayers == false)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    System.Console.WriteLine("Invalid input");
                }
            }
            //o_Game.Player1 = new Player();
            Player Player1 = new Player();
            if (numberCount == 1)
            {
                ComputerPlayer Player2 = new ComputerPlayer('O');
                //o_Game.Player2 = new ComputerPlayer();
                o_Game = new FourInARowGame(Player1, Player2);
            }
            else
            {
                Player Player2 = new Player('O');
                //o_Game.Player2 = new Player('O');
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
                int.TryParse(colsStr, out cols);
                if (cols < 4 || cols > 8)
                {
                    validCols = false;
                }

            }
            o_Game.setBoard(rows, cols);
        }





    }
}
