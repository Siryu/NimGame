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

        public Move(int[] boardSetup)
        {
            this.BoardSetup = boardSetup;
            this.Value = 0f;
            this.TimesSelected = 1;
        }
    }
}
