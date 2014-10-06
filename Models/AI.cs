using NimGame.Controllers;
using System;
using System.Collections.Generic;

namespace NimGame.Models
{
    public class AI
    {
        List<Move> movesPossible;
        Random rand = new Random();
        MoveOperations mm;

        public AI(MoveOperations mm)
        {
            this.mm = mm;
            movesPossible = new List<Move>();
        }

        public int[] calculateTurn(int[] boardState)
        {
            Move returnMove = new Move(new int[]{boardState[0], boardState[1], boardState[2]}, 0f);

            foreach (Move m in movesPossible)
            {
                if (m.BoardSetup[0] == boardState[0] && m.BoardSetup[1] == boardState[1] && m.BoardSetup[2] == boardState[2])
                {
                    foreach (Move n in m.NextMove)
                    {
                        if (n.Value < returnMove.Value)
                        {
                            if ((n.BoardSetup[0] < boardState[0] && n.BoardSetup[1] == boardState[1] && n.BoardSetup[2] == boardState[2]) ||
                                (n.BoardSetup[0] == boardState[0] && n.BoardSetup[1] < boardState[1] && n.BoardSetup[2] == boardState[2]) ||
                                (n.BoardSetup[0] == boardState[0] && n.BoardSetup[1] == boardState[1] && n.BoardSetup[2] < boardState[2]))

                            {
                                returnMove = n;
                            }
                        }
                    }
                }
            }
            if (returnMove.Value >= 0.0f)
            {
                returnMove = GetRandomState(boardState);                
            }
            return returnMove.BoardSetup;
        }

        public void AddGame(List<int[]> moves)
        {
            int win = moves.Count % 2 == 0 ? 1 : -1;

            for(int i = 0; i < moves.Count; i++)
            {
                bool isThere = false;
                float value;

                value = ((float)(i + 1) / moves.Count) * win;

                foreach (Move m in movesPossible)
                {
                    if (m.BoardSetup[0] == (moves[i])[0] && m.BoardSetup[1] == (moves[i])[1] && m.BoardSetup[2] == (moves[i])[2])
                    {
                        isThere = true;
                        if (i + 1 != moves.Count)
                        {
                            mm.IsMove(moves[i + 1], m, value);
                            break;
                        }
                    }
                }
                if (!isThere)
                {
                    Move newMove = new Move(moves[i]);
                    if (i + 1 != moves.Count)
                    {
                        mm.IsMove(moves[i + 1], newMove, value);
                        movesPossible.Add(newMove);
                    }
                }

                win *= -1;
            }
        }

        private Move GetRandomState(int[] state)
        {
            int row = rand.Next(3);

            while (state[row] == 0)
            {
                row = rand.Next(3);
            }
            state[row] = state[row] - (rand.Next(1, state[row]));

            return new Move(state);
        }
    }
}