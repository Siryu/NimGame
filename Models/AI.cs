using NimGame.Controllers;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace NimGame.Models
{
    public class AI
    {
        private List<Move> movesPossible;
        private Random rand;

        public AI()
        {
            rand = new Random();
            movesPossible = new List<Move>();
        }

        public void AddGame(List<int[]> moves)
        {
            Debug.Assert(moves != null);

            int win = moves.Count % 2 == 0 ? 1 : -1;

            Debug.Assert(win == 1 || win == -1);

            for (int i = 0; i < moves.Count; i++)
            {
                bool isThere = false;
                float value;

                //I do not think this needs an assertion, but I am not sure... Kevin.
                value = ((float)(i + 1) / moves.Count) * win;

                foreach (Move m in movesPossible)
                {
                    if(m.Equals(moves[i]))
                    {
                        isThere = true;
                        if (i + 1 != moves.Count)
                        {
                            MoveOperations.IsMove(moves[i + 1], m, value);
                            break;
                        }
                    }
                }
                if (!isThere)
                {
                    Move newMove = new Move(moves[i]);
                    if (i + 1 != moves.Count)
                    {
                        MoveOperations.IsMove(moves[i + 1], newMove, value);
                        movesPossible.Add(newMove);
                    }
                }

                win *= -1;
            }
        }

        public IEnumerable<Move> getPossibleMoves()
        {
            return this.movesPossible;
        }
    }
}
