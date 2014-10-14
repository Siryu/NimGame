using NimGame.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public class AIPlayer : Player
    {
        private Random rand;
        private AI ai;

        public AIPlayer(AI ai)
        {
            this.rand = new Random();
            this.ai = ai;
        }

        public override BoardState getPlayerMove(BoardState boardState)
        {
            Debug.Assert(boardState != null);

            Move returnMove = new Move(boardState.Clone(), 0f);

            foreach (Move m in ai.getPossibleMoves())
            {
                if (m.Equals(boardState))
                {
                    foreach (Move n in m.NextMove)
                    {
                        if (n.Value < returnMove.Value)
                        {
                            if ((n.BoardSetup.getRowCount(1) < boardState.getRowCount(1) && n.BoardSetup.getRowCount(2) == boardState.getRowCount(2) && n.BoardSetup.getRowCount(3) == boardState.getRowCount(3)) ||
                                (n.BoardSetup.getRowCount(1) == boardState.getRowCount(1) && n.BoardSetup.getRowCount(2) < boardState.getRowCount(2) && n.BoardSetup.getRowCount(3) == boardState.getRowCount(3)) ||
                                (n.BoardSetup.getRowCount(1) == boardState.getRowCount(1) && n.BoardSetup.getRowCount(2) == boardState.getRowCount(2) && n.BoardSetup.getRowCount(3) < boardState.getRowCount(3)))
                            {
                                returnMove = n;
                            }
                        }
                    }
                }
            }
            if (returnMove.Value >= 0.0f)
            {
                returnMove = GetRandomState(boardState);
            }
            return returnMove.BoardSetup;
        }

        private Move GetRandomState(BoardState state)
        {
            Debug.Assert(state != null);

            int row = rand.Next(1,4);

            while (state.getRowCount(row) == 0)
            {
                row = rand.Next(1,4);
            }

            state.setRowCount(row, (state.getRowCount(row) - (rand.Next(1, state.getRowCount(row)))));

            return new Move(state);
        }
    }
}