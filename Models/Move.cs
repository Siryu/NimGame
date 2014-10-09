using System.Collections.Generic;

namespace NimGame.Models
{
    public class Move
    {
        public int[] BoardSetup { get; set; }
        public float Value { get; set; }
        public int TimesSelected { get; set; }
        public List<Move> NextMove;

        public Move(int[] boardSetup, float value = 0f)
        {
            this.NextMove = new List<Move>();
            this.BoardSetup = boardSetup;
            this.Value = value;
            this.TimesSelected = 1;
        }

        public override bool Equals(object obj)
        {
            bool equal = false;

            if (obj is int[])
            {
                int[] move2 = obj as int[];
                int length = 0;
                if ((length = this.BoardSetup.Length) == move2.Length)
                {
                    equal = true;
                    for (int i = 0; i < length && equal; ++i)
                    {
                        if (this.BoardSetup[i] != move2[i]) equal = false;
                    }
                }
        }
            return equal;
        }
    }
}