//Created by Josh Burnett

using System;
using System.Reflection.Metadata.Ecma335;

namespace TicTacToeGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesPlayed = 0;
            TimeSpan totalTimePlayed = TimeSpan.Zero;
            DateTime startTime = DateTime.Now;
            DateTime endTime;
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] Positions = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do
            {
                Console.Clear();

                currentPlayer = GetNextPlayer(currentPlayer);

                Hud(currentPlayer);
                GameBoard(Positions);

                Engine(Positions, currentPlayer);


                gameStatus = CheckWinner(Positions);
                
               


            } while (gameStatus.Equals(0));

            Console.Clear();
            Hud(currentPlayer);
            GameBoard(Positions);

            if (gameStatus.Equals(1))
            {
                
                Console.WriteLine($"Player {currentPlayer} is the winner!");
                endTime = DateTime.Now;
                TimeSpan totalTime = endTime - startTime;
                Console.WriteLine($"Total time played: {totalTime.TotalSeconds} seconds");
                gamesPlayed++;
                totalTimePlayed += totalTime;
                double averageTimePerGame = totalTimePlayed.TotalSeconds / gamesPlayed;
                Console.WriteLine($"Average time per game: {averageTimePerGame} seconds");
                Console.Write("Do you want to play again? (Y/N): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.ToLower().Equals("n"))
                {
                    Environment.Exit(0);
                }
                
               
                  
                
            }

            if (gameStatus.Equals(2))
            {
               
                Console.WriteLine($"The game is a draw!");
                endTime = DateTime.Now;
                TimeSpan totalTime = endTime - startTime;
                Console.WriteLine($"Total time played: {totalTime.TotalSeconds} seconds");
                gamesPlayed++;
                totalTimePlayed += totalTime;
                double averageTimePerGame = totalTimePlayed.TotalSeconds / gamesPlayed;
                Console.WriteLine($"Average time per game: {averageTimePerGame} seconds");
                Console.Write("Do you want to play again? (Y/N): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.ToLower().Equals("n"))
                {
                    Environment.Exit(0);
                }
            }
        }

        private static int CheckWinner(char[] Positions)
        {

            if (Winner(Positions))
            {
                return 1;
            }


            if (Draw(Positions))
            {
                return 2;
            }

            return 0;
        }

        private static bool Draw(char[] Positions)
        {
            return Positions[0] != '1' &&
            Positions[1] != '2' &&
            Positions[2] != '3' &&
            Positions[3] != '4' &&
            Positions[4] != '5' &&
            Positions[5] != '6' &&
            Positions[6] != '7' &&
            Positions[7] != '8' &&
            Positions[8] != '9';
        }

        private static bool Winner(char[] Positions)
        {
            if (IsGameMarkersTheSame(Positions, 0, 1, 2))
            {
                return true;
            }

            if (IsGameMarkersTheSame(Positions, 3, 4, 5))
            {
                return true;
            }

            if (IsGameMarkersTheSame(Positions, 6, 7, 8))
            {
                return true;
            }

            if (IsGameMarkersTheSame(Positions, 0, 3, 6))
            {
                return true;
            }

            if (IsGameMarkersTheSame(Positions, 1, 4, 7))
            {
                return true;
            }

            if (IsGameMarkersTheSame(Positions, 2, 5, 8))
            {
                return true;
            }

            if (IsGameMarkersTheSame(Positions, 0, 4, 8))
            {
                return true;
            }

            if (IsGameMarkersTheSame(Positions, 2, 4, 6))
            {
                return true;
            }

            return false;
        }

        private static bool IsGameMarkersTheSame(char[] testPositions, int pos1, int pos2, int pos3)
        {
            return testPositions[pos1].Equals(testPositions[pos2]) && testPositions[pos2].Equals(testPositions[pos3]);
        }

        private static void Engine(char[] Positions, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {

                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                (userInput.Equals("1") ||
                userInput.Equals("2") ||
                userInput.Equals("3") ||
                userInput.Equals("4") ||
                userInput.Equals("5") ||
                userInput.Equals("6") ||
                userInput.Equals("7") ||
                userInput.Equals("8") ||
                userInput.Equals("9")))
                {

                    int.TryParse(userInput, out var gamePosition);

                    char currentPosition = Positions[gamePosition - 1];

                    if (currentPosition.Equals('X') || currentPosition.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select anotyher placement.");
                    }
                    else
                    {
                        Positions[gamePosition - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select anotyher placement.");
                }
            } while (notValidMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }

        static void Hud(int PlayerNumber)
        {

            Console.WriteLine("Welcome to the Super Duper Tic Tac Toe Game!");


            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();


            Console.WriteLine($"Player {PlayerNumber} to move, select 1 thorugh 9 from the game board.");
            Console.WriteLine();
        }

        static void GameBoard(char[] Positions)
        {
            Console.WriteLine($" {Positions[0]} | {Positions[1]} | {Positions[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Positions[3]} | {Positions[4]} | {Positions[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Positions[6]} | {Positions[7]} | {Positions[8]} ");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
}