using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class AI
    {
        List<Move> movesPossible;
        Random rand = new Random();

        public AI()
        {
            movesPossible = new List<Move>();
        }

        public int[] calculateTurn(int[] boardState)
        {
            Move returnMove = new Move(boardState);

            foreach (Move m in movesPossible)
            {
                if (m.BoardSetup == boardState)
                {
                    foreach (Move n in m.NextMove)
                    {
                        if (n.Value <= returnMove.Value)
                        {
                            if (n.BoardSetup[0] <= boardState[0] && n.BoardSetup[1] <= boardState[1] && n.BoardSetup[2] <= boardState[2])
                            {
                                returnMove = n;
                            }
                        }
                    }
                }
            }

            if (returnMove.BoardSetup == boardState)
            {
                
                // needs some work on a random move play by a computer player.
                
                int row = rand.Next(3);
                returnMove.BoardSetup[row] = returnMove.BoardSetup[row] - (returnMove.BoardSetup[row] - rand.Next(returnMove.BoardSetup[row]) + 1); 
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
                    if (m.BoardSetup == moves[i])
                    {
                        isThere = true;
                        if (i + 1 != moves.Count)
                        {
                            m.IsMove(moves[i + 1], value);
                        }
                    }                       
                }
                if (!isThere)
                {
                    Move newMove = new Move(moves[i]);
                    newMove.IsMove(moves[i + 1], value);
                    movesPossible.Add(newMove);
                }

                win *= -1;
            }
        }
    }
}