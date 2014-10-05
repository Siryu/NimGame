using NimGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Controllers
{
    public class MoveManipulator
    {
        public void IsMove(int[] next, Move currentMove, float value)
        {
            bool isAdded = false;

            foreach (Move m in currentMove.NextMove)
            {
                if (AreEqual(m.BoardSetup, next))
                {
                    float moveValue = m.Value * m.TimesSelected;
                    moveValue += value;
                    m.TimesSelected += 1;
                    m.Value = moveValue / m.TimesSelected;
                    isAdded = true;
                }
            }

            if (!isAdded)
            {
                Move newMove = new Move(next, value);
                currentMove.NextMove.Add(newMove);
            }
        }

        public bool AreEqual(int[] move1, int[] move2)
        {
            int length = 0;
            bool equal = false;
            if ((length = move1.Count()) == move2.Count())
            {
                equal = true;
                for (int i = 0; i < length && equal; ++i)
                {
                    if (move1[i] != move2[i]) equal = false;
                }
            }
            return equal;
        }
    }
}