using System;

namespace escuela_it
{
    public class Player : IOrigin
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

        public bool contains(Tile[] tiles)
        {
            throw new NotImplementedException();
        }

        public void takeOut(Tile[] tiles)
        {
            throw new NotImplementedException();
        }
    }
}