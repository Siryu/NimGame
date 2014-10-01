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

        public AI()
        {
            movesPossible = new List<Move>();
        }

        public int[] calculateTurn(int[] boardState)
        {
            foreach (Move m in movesPossible)
            {
                if (m.BoardSetup == boardState)
                {

                }
            }
        }

        public void AddGame(List<int[]> moves)
        {
            foreach (int[] intarr in moves)
            {
                foreach (int[] key in moveLog.Keys)
                {
                    if (key[0] == intarr[0] && key[1] == intarr[1] && key[2] == intarr[2])
                    {
                        
                    }
                }
            }
        }
    }
}
