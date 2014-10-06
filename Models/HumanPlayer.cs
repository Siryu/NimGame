using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class HumanPlayer : Player
    {
    
        public override int[] getPlayerMove(int[] boardState)
        {
            int line = -1;
            int count = -1;

            while (line <= 0 || line > 3)
            {
                Console.Write("What line do you wish to remove from?: ");
                int.TryParse(Console.ReadLine(), out line);
                if (line > 0 && line <= 3 && !(boardState[line - 1] > 0))
                {
                    line = -1;
                }
            }

            while (count > boardState[line - 1] || count <= 0)
            {
                Console.Write("How many do you wish to remove from line " + line + "?: ");
                int.TryParse(Console.ReadLine(), out count);
            }

            boardState[line - 1] = boardState[line - 1] - count;

            return boardState;
        }
    }
}
