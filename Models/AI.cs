using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class AI
    {
        Dictionary<int[], Dictionary<int[], float>> moveLog;
        Dictionary<int[], float> MoveValues;

        public AI()
        {
            MoveValues = new Dictionary<int[], float>();
            moveLog = new Dictionary<int[],Dictionary<int[], float>>();
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
