using System;

namespace escuela_it
{
    public class Turn
    {
        private Player[] players;

        public Turn(Player[] players)
        {
            this.players = players;
        }

        internal Player nextPlayer()
        {
            throw new NotImplementedException();
        }
    }
}