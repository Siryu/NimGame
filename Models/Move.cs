using System.Collections.Generic;
using System.Diagnostics;

namespace NimGame.Models
{
    public class Move
    {
        public BoardState BoardSetup { get; set; }
        public float Value { get; set; }
        public int TimesSelected { get; set; }
        public List<Move> NextMove;

        public Move(BoardState boardSetup, float value = 0f)
        {
            this.NextMove = new List<Move>();
            this.BoardSetup = boardSetup;
            this.Value = value;
            this.TimesSelected = 1;
        }

        public override bool Equals(object obj)
        {
            Debug.Assert(obj != null);
            bool equal = true;
            const int rowCount = 3;

            if (obj is BoardState)
            {
                BoardState move2 = obj as BoardState;
                for (int i = 1; i <= rowCount && equal == true; i++)
                {
                    if (this.BoardSetup.getRowCount(i) != move2.getRowCount(i))
                    {
                        equal = false;
                    }
                }
            }
            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}