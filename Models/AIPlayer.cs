﻿using NimGame.Controllers;
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

        public override int[] getPlayerMove(int[] boardState)
        {
            Debug.Assert(boardState != null);

            Move returnMove = new Move(new int[] { boardState[0], boardState[1], boardState[2] }, 0f);

            foreach (Move m in ai.getPossibleMoves())
            {
                if (m.Equals(boardState))
                {
                    foreach (Move n in m.NextMove)
                    {
                        if (n.Value < returnMove.Value)
                        {
                            if ((n.BoardSetup[0] < boardState[0] && n.BoardSetup[1] == boardState[1] && n.BoardSetup[2] == boardState[2]) ||
                                (n.BoardSetup[0] == boardState[0] && n.BoardSetup[1] < boardState[1] && n.BoardSetup[2] == boardState[2]) ||
                                (n.BoardSetup[0] == boardState[0] && n.BoardSetup[1] == boardState[1] && n.BoardSetup[2] < boardState[2]))
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

        private Move GetRandomState(int[] state)
        {
            Debug.Assert(state != null);
            Debug.Assert(state.Length == 3);

            int row = rand.Next(3);

            while (state[row] == 0) row = rand.Next(3);

            state[row] = state[row] - (rand.Next(1, state[row]));

            return new Move(state);
        }
    }
}