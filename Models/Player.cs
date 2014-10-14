using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.Models
{
    public abstract class Player
    {
        bool isPlayerTurn = true;
        int wins;

        public abstract BoardState getPlayerMove(BoardState boardState);

        public bool getTurn()
        {
            return isPlayerTurn;
        }

        public void setTurn(bool isPlayerTurn)
        {
            this.isPlayerTurn = isPlayerTurn;
        }

        public int getWins()
        {
            return this.wins;
        }

        public void setWins(int wins)
        {
            this.wins = wins;
        }
    }
}
