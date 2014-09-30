using NimGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * create Nim game that learns the more you play the game
 * 3, 5, 7 X's in a row
 * can take as many items as you want from each row
 * goal is to get opposite player to take the last x in a row
 * no invalid moves
 * 
 * 3 game modes
 * user vs user
 * computer vs user
 * computer vs computer
 */ 

namespace NimGame
{
    public class Program
    {
        AI computer;
        List<int[]> GameMoves;
        int[] boardState;
        GameType GameType;

        public Program()
        {
            boardState = new int[] {3, 5, 7};
            GameMoves = new List<int[]>();      
            
            GameType = GetGameType();
            computer = new AI();
        }

        public void Game()
        {
            bool player1Turn = true;
            bool exit = false;
            bool gameExit = false;

            while (!gameExit)
            {
                while (!exit)
                {
                    if (GameType == NimGame.GameType.TwoPlayer)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(player1Turn ? "Player 1's turn" : "Player 2's turn");
                        PrintBoard();
                        GameMoves.Add(GetUserInput());
                    }

                    else if (GameType == NimGame.GameType.OnePlayer)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(player1Turn ? "Player 1's turn" : "Computer's turn");
                        PrintBoard();
                        GameMoves.Add(GetUserInput());
                        GameMoves.Add(GetComputerInput());
                    }

                    else
                    {
                        int turns = -1;

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("How many rounds would you like to go?");
                        while (turns <= 0)
                        {
                            int.TryParse(Console.ReadLine(), out turns);
                        }

                        // fix this for loop, doesn't add to the ai game for processing.
                        for (int i = 0; i < turns; i++)
                        {
                            GameMoves.Add(GetComputerInput());
                            GameMoves.Add(GetComputerInput());
                        }
                    }

                    foreach (int i in boardState)
                    {
                        if (i != 0)
                        {
                            exit = false;
                            break;
                        }
                        else
                        {
                            exit = true;
                        }
                    }

                    player1Turn = !player1Turn;
                }
                computer.AddGame(GameMoves);
                GameMoves.Clear();

                Console.WriteLine("Do you want to play again? y/n");
                string playAgain = Console.ReadLine();
                if (playAgain.ToUpper() == "Y" || playAgain.ToUpper() == "YES")
                {
                    gameExit = true;
                }
                else
                {
                    gameExit = false;
                    GetGameType();
                }
            }
        }

        public int[] GetComputerInput()
        {
            return computer.calculateTurn(this.boardState);
        }

        public int[] GetUserInput()
        {
            int line = -1;
            int count = -1;

            while (line <= 0 || line > 3)
            {
                Console.Write("What line do you wish to remove from?: ");
                int.TryParse(Console.ReadLine(), out line);
                //if (!(boardState[line - 1] > 0))
                //{
                //    line = -1;
                //}
            }

            while (count > boardState[line - 1] || count <= 0)
            {
                Console.Write("How many do you wish to remove from line " + line + "?: ");
                int.TryParse(Console.ReadLine(), out count);
            }

            boardState[line - 1] = boardState[line - 1] - count;

            return boardState;
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1 + ". ");

                for (int j = 0; j < boardState[i]; j++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public GameType GetGameType()
        {
            int userInput = -1;

            while(userInput == -1)
            {
                Console.WriteLine("What type of game do you wish to play? \n");
                Console.WriteLine("1. Player vs. Player");
                Console.WriteLine("2. Player vs. Computer");
                Console.WriteLine("3. Computer vs. Computer");
                Console.WriteLine();

                int.TryParse(Console.ReadLine(), out userInput);
                if (userInput != 1 && userInput != 2 && userInput != 3)
                {
                    userInput = -1;
                }
            }

            return (GameType)(Enum.GetValues(typeof(GameType)).GetValue(userInput - 1));
        }


        public static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Game();
        }
    }
}
