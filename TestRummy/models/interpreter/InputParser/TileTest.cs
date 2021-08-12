using NUnit.Framework;
using Rummy.models.interpreter.InputParser;
using Rummy.models.interpreter.InputParser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRummy.models.interpreter.InputParser
{
    public class TileTest
    {
        [Test]
        public void givenTilesWhenParserOneTileThenIsCorrect()
        {
            Input input = new Input("4R 5R 6R");            
            Tile tile = new Tile(input);
            tile.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }
       
        [Test]
        public void givenTileWithJokerAtStartWhenParserJokerThenIsCorrect()
        {
            Input input = new Input("J 5R 6R");            
            Tile tile = new Tile(input);
            tile.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTileWithJokerAtMiddleWhenParserJokerThenIsCorrect()
        {
            Input input = new Input("11Y J 13Y");
            Tile tile = new Tile(input);
            tile.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }
    }
}
