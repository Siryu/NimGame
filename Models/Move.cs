using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class Move
    {
        public int[] BoardSetup { get; set; }
        public float Value { get; set; }
        public int TimesSelected { get; set; }
        public List<Move> NextMove;

        public Move(int[] boardSetup)
        {
            this.NextMove = new List<Move>();
            this.BoardSetup = boardSetup;
            this.Value = 0f;
            this.TimesSelected = 1;
        }

        public Move(int[] boardSetup, float value)
        {
            this.NextMove = new List<Move>();
            this.BoardSetup = boardSetup;
            this.Value = value;
            this.TimesSelected = 1;
        }

        public void IsMove(int[] next, float value)
        {
            bool isAdded = false;
            foreach (Move m in NextMove)
            {
                if (m.BoardSetup[0] == next[0] && m.BoardSetup[1] == next[1] && m.BoardSetup[2] == next[2])
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
                Move newMove = new Move(next);
                newMove.Value = value;
                this.NextMove.Add(newMove);
            }
        }
    }
}