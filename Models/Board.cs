using System;
using System.Collections.Generic;
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
            startingState = new int[] { row1, row2, row3 };
            currentState = new int[] { row1, row2, row3 };
        }

        public void ResetBoardState()
        {
            currentState = new int[startingState.Length];
            
            for (int i = 0; i < startingState.Length; ++i)
            {
                currentState[i] = startingState[i];
            }
        }

        public int[] getState()
        {
            return new int[] {currentState[0], currentState[1], currentState[2]};
        }

        public void setState(int[] newState)
        {
            this.currentState = newState;
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1 + ". ");

                for (int j = 0; j < currentState[i]; j++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
