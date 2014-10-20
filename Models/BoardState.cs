using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class BoardState
    {
        private int row1;
        private int row2;
        private int row3;

        public BoardState(int row1 = 3, int row2 = 5, int row3 = 7)
        {
            this.row1 = row1;
            this.row2 = row2;
            this.row3 = row3;
        }

        public int getRowCount(int row)
        {
            System.Diagnostics.Debug.Assert(row > 0 && row < 4);
            int returnedRow = 0;

            switch (row)
            {
                case 1:
                    returnedRow = row1;
                    break;
                case 2:
                    returnedRow = row2;
                    break;
                case 3:
                    returnedRow = row3;
                    break;
            }
            return returnedRow;
        }

        public void setRowCount(int row, int count)
        {
            System.Diagnostics.Debug.Assert(row > 0 && row < 4);

            switch (row)
            {
                case 1:
                    this.row1 = count;
                    break;
                case 2:
                    this.row2 = count;
                    break;
                case 3:
                    this.row3 = count;
                    break;
            }
        }

        public BoardState Clone()
        {
            BoardState clonedState = new BoardState();
            clonedState.setRowCount(1, this.row1);
            clonedState.setRowCount(2, this.row2);
            clonedState.setRowCount(3, this.row3);

            return clonedState;
        }
    }
}