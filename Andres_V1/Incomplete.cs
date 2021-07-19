namespace escuela_it
{
    internal class Incomplete : TilesGroup
    {
        private const int MAX_INCOMPLETE_SIZE = 0;
        public Incomplete() : base(new Tile[MAX_INCOMPLETE_SIZE])
        {
        }

        protected override void add(Tile[] tiles)
        {
            throw new System.NotImplementedException();
        }

        protected override bool canAddToGroup(Tile[] tiles)
        {
            throw new System.NotImplementedException();
        }

        protected override TilesGroup newTilesGroup(TilesGroup tilesGroup)
        {
            throw new System.NotImplementedException();
        }

        protected override void take(Tile[] tile)
        {
            throw new System.NotImplementedException();
        }
    }
}