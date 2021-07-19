using System;
using escuela_it;

public class Run : TilesGroup
{
    const int MAX_RUN_SIZE = 13;
    public Run() : base(new Tile[MAX_RUN_SIZE])
    {
    }

    protected override void add(Tile[] tiles)
    {
        throw new NotImplementedException();
    }

    protected override bool canAddToGroup(Tile[] tiles)
    {
        throw new NotImplementedException();
    }

    protected override TilesGroup newTilesGroup(TilesGroup tilesGroup)
    {
        throw new NotImplementedException();
    }

    protected override void take(Tile[] tiles)
    {
        throw new NotImplementedException();
    }
}