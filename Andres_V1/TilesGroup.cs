using System;

namespace escuela_it
{
    public abstract class TilesGroup
    {
        private Tile[] tiles;
        private int tilesCount;
        
        protected TilesGroup(Tile[] tiles)
        {
            this.tiles=tiles; 
            this.tilesCount = 0; 
        }

        protected Tile[] takeTileFrom(TilesGroup origin)
        {
            throw new NotImplementedException();
        }

        protected void addTile(Tile tile){
            this.tiles[tilesCount] = tile;
        }

        protected Tile getTile(int index){
            return tiles[index];
        }
        public abstract TilesGroup readFrom(TilesGroup origin);       
        public abstract bool isOk(); 
    }
}