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
                        if (n.Value < returnMove.Value && moveIsValidChange(n.BoardSetup, boardState))
                        {
                            returnMove = n;
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

        private bool moveIsValidChange(BoardState newState, BoardState oldState)
        {
            bool isValidChange = false;
            if ((newState.getRowCount(1) < oldState.getRowCount(1) && newState.getRowCount(2) == oldState.getRowCount(2) && newState.getRowCount(3) == oldState.getRowCount(3)) ||
                (newState.getRowCount(1) == oldState.getRowCount(1) && newState.getRowCount(2) < oldState.getRowCount(2) && newState.getRowCount(3) == oldState.getRowCount(3)) ||
                (newState.getRowCount(1) == oldState.getRowCount(1) && newState.getRowCount(2) == oldState.getRowCount(2) && newState.getRowCount(3) < oldState.getRowCount(3)))
            {
                isValidChange = true;
            }

            return isValidChange;
        }

        private Move GetRandomState(BoardState state)
        {
            Debug.Assert(state != null);
            Move randomState = new Move(state.Clone());
            
            int row = rand.Next(1,4);

            while (state.getRowCount(row) == 0)
            {
                row = rand.Next(1,4);
            }

            randomState.BoardSetup.setRowCount(row, (state.getRowCount(row) - (rand.Next(1, state.getRowCount(row)))));

            return randomState;
        }
    }
}