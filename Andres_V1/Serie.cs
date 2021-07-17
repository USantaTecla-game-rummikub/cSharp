using escuela_it;

class Serie : TilesGroup
{
    const int MAX_SERIE_SIZE = 4;
    public Serie() : base(new Tile[MAX_SERIE_SIZE])
    {
    }

    public override TilesGroup readFrom(TilesGroup origin)
    {
        throw new System.NotImplementedException();
    }
}