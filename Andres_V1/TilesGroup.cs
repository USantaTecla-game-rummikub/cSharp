using System;

namespace escuela_it
{
    public abstract class TilesGroup
    {
        protected Tile[] tiles;
        protected int tilesCount;
        protected TilesGroup(Tile[] tiles)
        {
            this.tiles = tiles;
            this.tilesCount = 0;
        }
        public TilesGroup readFrom(TilesGroup origin)
        {
            Tile[] tiles = getTileFromOrigin(origin);
            if (!origin.include(tiles))
                Console.WriteLine("Error: Tiles not found on the group.");
            else if (!this.canAddToGroup(tiles))
            {
                Console.WriteLine("Error: Tiles can not be added on the group.");
            }
            else
            {
                origin.take(tiles);
                this.add(tiles);
            }
            return newTilesGroup(this);
        }

        protected abstract TilesGroup newTilesGroup(TilesGroup tilesGroup);

        protected abstract void add(Tile[] tile);
        protected abstract void take(Tile[] tile);
        protected abstract bool canAddToGroup(Tile[] tile);
        private bool include(Tile[] tiles)
        {
            int index = 0;
            while (index <= tiles.Length - 1 || this.include(tiles[index++]))
            {

            }
            return this.include(tiles[index++]);
        }

        private bool include(Tile tile)
        {
            int index = 0;
            while (index <= tilesCount - 1 || !tile.isEqual(tiles[index++]))
            {

            };
            return tile.isEqual(tiles[index]);
        }

        private Tile[] getTileFromOrigin(TilesGroup origin)
        {
            throw new NotImplementedException();
        }
    }
}