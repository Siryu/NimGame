using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class Board
    {
        private int[] currentState;
        private int[] startingState;

        public Board(int row1, int row2, int row3)
        {
            Debug.Assert(row1 >= 0 && row2 >= 0 && row3 >= 0);

            startingState = new int[] { row1, row2, row3 };
            currentState = new int[] { row1, row2, row3 };
        }

        public void ResetBoardState()
        {
            currentState = new int[startingState.Length];
            
            for (int i = 0; i < startingState.Length; ++i) currentState[i] = startingState[i];
        }

        public int[] getState()
        {
            return (int[])this.currentState.Clone();
        }

        public void setState(int[] newState)
        {
            this.currentState = newState;
        }

        public void PrintBoard()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("\n");
            
            for (int i = 0; i < 3; i++)
            {
                stringBuilder.Append((i + 1) + ". ");

                for (int j = 0; j < currentState[i]; j++)
                {
                   stringBuilder.Append("X");
                }
                stringBuilder.Append("\n");
            }
            stringBuilder.Append("\n");

            View.Display.show(stringBuilder.ToString());
        }
    }
}
