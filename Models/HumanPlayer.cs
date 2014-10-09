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
        public override int[] getPlayerMove(int[] boardState)
        {
            Debug.Assert(boardState != null);

            int count = -1;
            int line = -1;

            while (line == -1)
            {
                line = View.Display.PromptForInt("What line do you wish to remove from?: ", 1, 3);
                line = (!(boardState[line - 1] > 0)) ? -1 : line;  
            }
            while (count > boardState[line - 1] || count <= 0)
            {
                count = View.Display.PromptForInt("How many do you wish to remove from line " + line + "?: ", 1, boardState[line - 1]);
            }

            boardState[line - 1] = boardState[line - 1] - count;

            return boardState;
        }
    }
}
