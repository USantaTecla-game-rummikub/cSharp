using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser
{
    public class Tiles: Parser
    {
        private Tile tile;
        private RestTiles restTiles;        

        public Tiles(Input input): base(input)
        {
            this.tile = new Tile(input);
            this.restTiles = new RestTiles(input);            
        }

        public override void parse()
        {
            this.testSpaceRequired();
            this.tile.parse();            
            this.restTiles.parse();
        }
    }
}
