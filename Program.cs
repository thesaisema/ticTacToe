/*
Name: Sainimere Sema
Professor: Brother Manley
Date: January 15, 2021
Class: CSE 210
*/


using System;

namespace ticTac
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gameboard = {"#", "#", "#", "#", "#", "#", "#", "#", "#"};
            string player = changePlayer("");
            while (!gameFinished(gameboard) && !rowWinner(gameboard) && !columnWinner(gameboard) && !diagonalWinner(gameboard))
            {
                display_board(gameboard);
                nextMove(player, gameboard);
                player = changePlayer(player);
            }
            display_board(gameboard);

            if(checkWin(gameboard) == true)
            {
                Console.Write($"{player}'s win! Congratulations!!!!!");
            }

            if(checkDraw(gameboard) == true)
            {
                Console.Write("\nThere was a draw.");
            }

            Console.Write("\nGood game!");

        }

        static void display_board(string[] gameboard)
        {
            Console.WriteLine();
            Console.WriteLine($"{gameboard[0]}|{gameboard[1]}|{gameboard[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{gameboard[3]}|{gameboard[4]}|{gameboard[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{gameboard[6]}|{gameboard[7]}|{gameboard[8]}");
        
        }

        static bool rowWinner(string[] gameboard)
        {
            return ((gameboard[0] == "x" && gameboard[1] == "x" && gameboard[2] == "x")
                   || (gameboard[3] == "x" && gameboard[4] == "x" && gameboard[5] == "x")
                   || (gameboard[6] == "x" && gameboard[7] == "x" && gameboard[8] == "x"));
        }

        static bool columnWinner(string[] gameboard)
        {
            return ((gameboard[0] == "x" && gameboard[3] == "x" && gameboard[6] == "x")
                   || (gameboard[1] == "x" && gameboard[4] == "x" && gameboard[7] == "x")
                   || (gameboard[2] == "x" && gameboard[5] == "x" && gameboard[8] == "x"));
        }

        static bool diagonalWinner(string[] gameboard)
        {
            return ((gameboard[0] == "x" && gameboard[4] == "x" && gameboard[8] == "x")
                   || (gameboard[2] == "x" && gameboard[4] == "x" && gameboard[6] == "x"));
        }

        static bool gameFinished(string[] gameboard)
        {
            bool continueGame = true;
            for (int i = 0; i < 9; i++)
            {
                if(gameboard[i] != "x" && gameboard[i] != "o")
                {
                    continueGame = false;
                    break;
                }
            }
            return continueGame;
        }

        static string changePlayer(string current)
        {
            string newPlayer = "o";
            if (current == "" || current == "o")
            {
                newPlayer = "x";
            }
            return newPlayer;
        }

        static void nextMove(string newPlayer, string[] gameboard)
        {
            Console.Write($"\n {newPlayer}'s turn to choose a square (1-9): ");
            int place = Convert.ToInt32(Console.ReadLine());
            gameboard[place - 1] = newPlayer;
        }

        static bool checkDraw(string[] gameboard)
        {
            bool draw = false;
            if(!rowWinner(gameboard) && !columnWinner( gameboard) && !diagonalWinner(gameboard))
            {
                draw = true;
            }
            return draw;
        }

        static bool checkWin(string[] gameboard)
        {
            bool win = false;
            if (rowWinner(gameboard) || columnWinner(gameboard) || diagonalWinner(gameboard))
            {
                win = true;
            }
            return win;
        }
    }
}