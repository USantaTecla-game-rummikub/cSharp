using System;
using System.Text.RegularExpressions;

namespace Rummy.models.interpreter.InputParser
{
    public class RestTiles: Parser
    {
        private Tiles tiles;

        public RestTiles(Input input): base(input)
        {
            
        }

        public override void parse()
        {            
            if (!this.input.isEnd() && this.input.isNotEqual(",") && this.input.isNotEqual(" IN"))
            {
                this.tiles = new Tiles(this.input);
                this.tiles.parse();             
            } 
        }
    }
}