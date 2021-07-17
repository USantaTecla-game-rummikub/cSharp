using System;
using escuela_it;

public class Run : TilesGroup
{
    const int MAX_RUN_SIZE = 13;
    public Run() : base(new Tile[MAX_RUN_SIZE])
    {
    }

    public override bool isOk()
    {
        return true;
    }

    public override TilesGroup readFrom(TilesGroup origin)
    {
        Tile[] tiles = base.takeTileFrom(origin); 
        throw new NotImplementedException();        
    }
}