namespace escuela_it
{
    internal class Incomplete : TilesGroup
    {
        private const int MAX_INCOMPLETE_SIZE = 0;
        public Incomplete() : base(new Tile[MAX_INCOMPLETE_SIZE])
        {
        }

        public override bool isOk()
        {
          return false;
        }

        public override TilesGroup readFrom(TilesGroup origin)
        {
            throw new System.NotImplementedException();
        }
    }
}