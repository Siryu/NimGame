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

        public Move(int[] boardSetup, float value = 0f)
        {
            this.NextMove = new List<Move>();
            this.BoardSetup = boardSetup;
            this.Value = value;
            this.TimesSelected = 1;
        }

        
    }
}