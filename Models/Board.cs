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
        private BoardState currentState;
        private BoardState defaultState;

        public Board(int row1, int row2, int row3)
        {
            Debug.Assert(row1 >= 0 && row2 >= 0 && row3 >= 0);

            currentState = new BoardState(row1, row2, row3);
            defaultState = new BoardState(row1, row2, row3);
        }

        public BoardState getState()
        {
            return this.currentState.Clone();
        }

        public void setState(BoardState state)
        {
            this.currentState = state;
        }

        public void editRowCount(int row, int count)
        {
            this.currentState.setRowCount(row, count);
        }

        public void ResetBoardState()
        {
            this.currentState = defaultState.Clone();
        }

        public void PrintBoard()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("\n");

            for (int i = 1; i < 4; i++)
            {
                stringBuilder.Append(i + ". ");

                for (int j = 0; j < currentState.getRowCount(i); j++)
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
