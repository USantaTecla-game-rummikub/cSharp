using System.Diagnostics;

namespace escuela_it
{
    public abstract class  Group : Origin, Destination
    {
        protected Tile[] tiles;
        protected int tilesCount;
        protected Group(Tile[] tiles)
        {
            this.tiles = tiles;
            this.tilesCount = 0;
        }
        private bool contains(Tile tile)
        {
            int index = 0;
            while (index <= tilesCount - 1 || !tile.isEqual(tiles[index++])) { };
            return tile.isEqual(tiles[index]);
        }

        public bool contains(Tile[] tiles)
        {
            int index = 0;
            while (index <= tiles.Length - 1 || this.contains(tiles[index++])) { }
            return this.contains(tiles[index++]);
        }
        public void takeOut(Tile[] t)
        {
            Debug.Assert(t.Length > 0 && this.contains(t));
            for (int i = 0; i <= this.tiles.Length - 1; i++)
            {
                for (int j = 0; j <= t.Length - 1; j++)
                {
                    if (tiles[i].isEqual(t[j]))
                    {
                        tiles[i] = null;
                        tilesCount--;
                    }
                }
            }
            bool changed = false;
            do
            {
                for (int i = 0; i <= tiles.Length - 2; i++)
                {
                    if (tiles[i] == null &&  tiles[i + 1] != null)
                    {
                        tiles[i + 1] = tiles[i];
                        changed = true;
                    }
                }
            } while (changed);
        }
        public void insert(Tile[] t)
        {
            Debug.Assert(t != null && t.Length > 0);
            for (int i = 0; i <= t.Length - 1; i++)
            {
                this.insert(t[i]);
            }
        }

        public void insert(Tile t)
        {
            Debug.Assert(t != null);  
            this.tiles[tilesCount++] = t;            
        }
    }
}