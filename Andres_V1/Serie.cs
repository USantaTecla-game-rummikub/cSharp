using escuela_it;

class Serie : TilesGroup
{
    const int MAX_SERIE_SIZE = 4;
    public Serie() : base(new Tile[MAX_SERIE_SIZE])
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

    protected override void take(Tile[] tiles)
    {
        throw new System.NotImplementedException();
    }
}