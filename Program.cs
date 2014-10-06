using NimGame.Controllers;
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
        MoveOperations mm;
        List<int[]> GameMoves;
        int[] boardState;
        GameType GameType;
        Player player1;
        Player player2;
        AI ai;

        public Program()
        {
            boardState = new int[] {3, 5, 7};
            GameMoves = new List<int[]>();

            mm = new MoveOperations();
            ai = new AI(mm);

            GameType = GetGameType();
            createPlayerTypes();
        }

        public void Game()
        {
            bool exit = false;
            bool gameExit = false;
            int turns = -1;

            while (!gameExit)
            {
                GameMoves.Add(new int[] {boardState[0], boardState[1], boardState[2]});

                while (!exit)
                {
                    if (GameType == NimGame.GameType.Computer)
                    {
                        while (turns <= 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("How many rounds would you like to go?");
                            int.TryParse(Console.ReadLine(), out turns);
                        }
                    } 

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(player1.getTurn() ? "Player 1's turn" : "Player 2's turn");
                    PrintBoard();
                    GameMoves.Add(player1.getTurn() ? player1.getPlayerMove(this.boardState) : player2.getPlayerMove(this.boardState));    

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

                    player1.setTurn(!player1.getTurn());
                }
                ai.AddGame(GameMoves);
                GameMoves.Clear();
                boardState = new int[] { 3, 5, 7 };
                if (player1.getTurn()) 
                {
                    player1.setWins(player1.getWins() + 1);
                }
                else
                {
                    player2.setWins(player2.getWins() + 1);
                }
                Console.WriteLine(player1.getTurn() ? "Player 1 wins!!!" : "Player 2 wins!!!");
                player1.setTurn(true);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Player One wins: " + player1.getWins());
                Console.WriteLine("Player Two wins: " + player2.getWins());
                Console.WriteLine();
                Console.WriteLine();
               
                if (turns <= 1)
                {
                    bool exitGame = PromptToPlayAgain();
                    gameExit = exitGame;
                    exit = exitGame;
                    turns = -1;
                }
                else
                {
                    turns--;
                    exit = false;
                }
            }
        }

        private bool PromptToPlayAgain()
        {
            string playAgain = null;
            bool returnBool = false;

            while (playAgain == null)
            {
                Console.WriteLine("Do you want to play again? y/n");
                playAgain = Console.ReadLine().ToUpper();
                if (playAgain == "N" || playAgain == "NO")
                {
                    returnBool = true;
                }
                else if (playAgain == "Y" || playAgain == "YES")
                {
                    returnBool = false;
                    GameType newGame = GetGameType();
                    if (newGame != GameType)
                    {
                        GameType = newGame;
                        createPlayerTypes();
                    }
                }
                else
                {
                    playAgain = null;
                }
            }
            return returnBool;
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

        private void createPlayerTypes()
        {
            switch (GameType)
            {
                case NimGame.GameType.TwoPlayer:
                    {
                        player1 = new HumanPlayer();
                        player2 = new HumanPlayer();
                        break;
                    }
                case NimGame.GameType.OnePlayer:
                    {
                        player1 = new HumanPlayer();
                        player2 = new AIPlayer(this.ai);
                        break;
                    }
                case NimGame.GameType.Computer:
                    {
                        player1 = new AIPlayer(this.ai);
                        player2 = new AIPlayer(this.ai);
                        break;
                    }
            }
        }

        public static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Game();
        }
    }
}
