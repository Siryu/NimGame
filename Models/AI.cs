using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class AI
    {
        Dictionary<int[], float> MoveValues;

        public AI()
        {
            MoveValues = new Dictionary<int[], float>();
        }

        public int[] calculateTurn(int[] boardState)
        {
            KeyValuePair<int[], float> returnValue = new KeyValuePair<int[],float>(boardState, 0f);
            Array.Sort(boardState);

            foreach (KeyValuePair<int[], float> kvp in MoveValues)
            {
                if (returnValue.Key == boardState || kvp.Value >= returnValue.Value)
                {
                    returnValue = kvp;
                }
            }

            return returnValue.Key;
        }

        public void AddGame(List<int[]> moves)
        {
            foreach (int[] intarr in moves)
            {
                Array.Sort(intarr);

                // odd or even determines who won.
                // first move added in is the first move, not initial board state.
                if (moves.Count % 2 == 0)
                {
                    // multiply everything by -1 for first player
                }
            }
        }
    }
}
