using System;

namespace escuela_it
{
    public class Player
    {
        private string name;

        public Player(string v)
        {
            this.name = v;
        }

        internal void addNewTile(Tile tile)
        {
            throw new NotImplementedException();
        }

        internal bool isWinner()
        {
            throw new NotImplementedException();
        }

        internal void show()
        {
            throw new NotImplementedException();
        }

        internal void moveTilesFromRackToTable(Table table)
        {
            throw new NotImplementedException();
        }
    }
}