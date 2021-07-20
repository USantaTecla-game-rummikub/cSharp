using System;

namespace escuela_it
{
    public class Pounch : Group
    {
        private const int TILE_SIZE = 106;
        public Pounch() : base(new Tile[TILE_SIZE])
        {
        }

        public Tile take()
        {
            throw new NotImplementedException();
        }

        public void show()
        {
            throw new NotImplementedException();
        }
    }
}