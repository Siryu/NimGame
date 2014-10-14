using NimGame.Controllers;
using NimGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NimGame
{
    public class GameManager
    {
        List<BoardState> GameMoves;
        Board board;
        GameType GameType;
        Player player1;
        Player player2;
        AI ai;

        public GameManager(int row1 = 3, int row2 = 5, int row3 = 7)
        {
            GameType = GetGameType();
            board = new Board(row1, row2, row3);
            GameMoves = new List<BoardState>();      
            ai = new AI();
            createPlayerTypes();
        }

        public void Game()
        {
            bool exit = false;
            bool gameExit = false;
            int turns = -1;

            while (!gameExit)
            {
                GameMoves.Add(board.getState());

                while (!exit)
                {
                    if(GameType == NimGame.GameType.Computer)
                    {
                        while (turns <= 0)
                        {
                            turns = View.Display.PromptForInt("\n\n\n" + "How many rounds would you like to go? : ", 1, int.MaxValue);
                        }
                    }

                    if (GameType != NimGame.GameType.Computer)
                    {
                        View.Display.show("\n\n\n" + (player1.getTurn() ? "Player 1's turn" : "Player 2's turn"));
                        board.PrintBoard();
                    }
                    board.setState(player1.getTurn() ? player1.getPlayerMove(board.getState()) : player2.getPlayerMove(board.getState()));
                    GameMoves.Add(board.getState());

                    exit = checkForEndOfRound();

                    player1.setTurn(!player1.getTurn());
                }

                roundOver();

                if (turns < 2)
                {
                    bool exitGame = !PromptToPlayAgain();
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

        private void roundOver()
        {
            ai.AddGame(GameMoves);
            GameMoves.Clear();

            board.ResetBoardState();

            if (player1.getTurn())
            {
                player1.setWins(player1.getWins() + 1);
            }
            else
            {
                player2.setWins(player2.getWins() + 1);
            }

            View.Display.show(player1.getTurn() ? "Player 1 wins!!!" : "Player 2 wins!!!");
            View.Display.show("\n\nPlayer One wins: " + player1.getWins());
            View.Display.show("Player Two wins: " + player2.getWins() + "\n\n");
        }

        private bool checkForEndOfRound()
        {
            bool endOfRound = true;
            for(int i = 1; i < 4; i++)
            {
                if (board.getState().getRowCount(i) != 0)
                {
                    endOfRound = false;
                    break;
                }
            }
            return endOfRound;
        }

        private bool PromptToPlayAgain()
        {
            bool playAgain;
            playAgain = View.Display.PromptForBool("Do you want to play again?");

            if (playAgain)
            {
                GameType newGame = GetGameType();
                if (newGame != GameType)
                {
                    GameType = newGame;
                    createPlayerTypes();
                }
            }
            return playAgain;
        }

        public GameType GetGameType()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("What type of game do you wish to play?\n\n");
            sb.Append("1. Player vs. Player\n");
            sb.Append("2. Player vs. Computer\n");
            sb.Append("3. Computer vs. Computer\n");

            int userInput = View.Display.PromptForInt(sb.ToString(), 1, 3);

            GameType selectedGameType = (GameType)(Enum.GetValues(typeof(GameType)).GetValue(userInput - 1));

            return selectedGameType;
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
    }
}
