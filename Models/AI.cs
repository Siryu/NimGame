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

        public void AddGame(List<int[]> moves)
        {
            int win = moves.Count % 2 == 0 ? 1 : -1;

            for (int i = 0; i < moves.Count; i++)
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

        public List<Move> getPossibleMoves()
        {
            return this.movesPossible;
        }
    }
}
