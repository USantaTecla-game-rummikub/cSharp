using System;

namespace escuela_it
{
    public class Pounch : Group
    {
        private const int TILE_SIZE = 106;
        private const int MAX_TILE_NUMBER = 13;
        
        public Pounch() : base(new Tile[TILE_SIZE])
        {
            for(int i = 0; i<=MAX_TILE_NUMBER; i++){
                
            }
        }
        public Tile take()
        {
            return tiles[tilesCount--];
        }

        public void show()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Pounch: {0}", tilesCount);
        }
    }
}