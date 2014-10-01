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


// take board total board states from game, find winner, and add data into a collection for potential moves (method)
// 
// create a random move method if nothing exists inside the collection already established.
//
// take what the best move is from the collection and return a new board state. (method) 
//
// help with problems others are having


namespace NimGame
{
    public class Program
    {
        AI computer;
        List<int[]> GameMoves;
        int[] boardState;
        GameType GameType;
        int p1Wins = 0, p2Wins = 0;

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
            int turns = -1;

            while (!gameExit)
            {
                GameMoves.Add(new int[] {boardState[0], boardState[1], boardState[2]});

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
                        GameMoves.Add(player1Turn ? GetUserInput() : GetComputerInput());
                    }

                    else
                    {                  
                        while (turns <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("How many rounds would you like to go?");
                            int.TryParse(Console.ReadLine(), out turns);
                        }

                        GameMoves.Add(GetComputerInput());
                        GameMoves.Add(GetComputerInput());
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
                boardState = new int[] { 3, 5, 7 };
                if (player1Turn) 
                {
                    p1Wins++;
                }
                else
                {
                    p2Wins++;
                }
                Console.WriteLine(player1Turn ? "Player 1 wins!!!" : "Player 2 wins!!!");
                player1Turn = true;
                Console.WriteLine();
                Console.WriteLine();
                if (turns <= 1)
                {
                    string playAgain = null;

                    while (playAgain == null)
                    {
                        Console.WriteLine("Do you want to play again? y/n");
                        playAgain = Console.ReadLine();
                        if (playAgain.ToUpper() == "N" || playAgain.ToUpper() == "NO")
                        {
                            gameExit = true;
                        }
                        else if (playAgain.ToUpper() == "Y" || playAgain.ToUpper() == "YES")
                        {
                            gameExit = false;
                            GameType = GetGameType();
                            exit = false;
                            turns = -1;
                        }
                        else
                        {
                            playAgain = null;
                        }
                    }
                }
                else
                {
                    turns--;
                    exit = false;
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
                if (line > 0 && line <=3 && !(boardState[line - 1] > 0))
                {
                    line = -1;
                }
            }

            while (count > boardState[line - 1] || count <= 0)
            {
                Console.Write("How many do you wish to remove from line " + line + "?: ");
                int.TryParse(Console.ReadLine(), out count);
            }

            boardState[line - 1] = boardState[line - 1] - count;

            return new int[] {boardState[0], boardState[1], boardState[2]};
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
