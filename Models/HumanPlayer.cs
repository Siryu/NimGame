using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class HumanPlayer : Player
    {
        public override BoardState getPlayerMove(BoardState boardState)
        {
            Debug.Assert(boardState != null);

            int count = -1;
            int line = -1;
            const int smallestRow = 1;
            const int largestRow = 3;
    
            line = View.Display.PromptForInt("What line do you wish to remove from?: ", smallestRow, largestRow);
            count = View.Display.PromptForInt("How many do you wish to remove from line " + line + "?: ", 1, boardState.getRowCount(line));
            
            boardState.setRowCount(line, boardState.getRowCount(line) - count);

            return boardState;
        }
    }
}
