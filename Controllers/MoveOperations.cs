using NimGame.Models;
using System.Linq;
using System.Diagnostics;

namespace NimGame.Controllers
{
    public static class MoveOperations
    {
        public static void IsMove(BoardState next, Move currentMove, float value)
        {
            Debug.Assert(next != null);
            Debug.Assert(currentMove != null);
            
            bool isAdded = false;

            foreach (Move m in currentMove.NextMove)
            {
                if (m.Equals(next))
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
    }
}