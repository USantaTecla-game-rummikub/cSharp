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
    public class TilesTest
    {
        [Test]
        public void givenRackTilesGroupWithoutErrorWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" 4R 5R 6R");           
            Tiles tiles = new Tiles(input);
            tiles.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }
       
        [Test]
        public void givenRackTilesGroupWithErrorWhenParseHasErrorsThenIsTrue()
        {
            Input input = new Input(" 4R 5R 6J");          
            Tiles tiles = new Tiles(input);
            tiles.parse();
            Assert.IsTrue(input.hasSintaxErrors());
        }

        [Test]
        public void givenRackTilesWithJokerAtEndWhenParseHasErrorsThenIsTrue()
        {
            Input input = new Input(" 10R 11R J");
            Tiles tiles = new Tiles(input);
            tiles.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenRackTilesWithJokerAtStartWhenParseHasErrorsThenIsTrue()
        {
            Input input = new Input(" J 10R 11R");
            Tiles tiles = new Tiles(input);
            tiles.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTileWithJokerAtMiddleWhenParserJokerThenIsCorrect()
        {
            Input input = new Input(" 11Y J 13Y");
            Tiles tiles = new Tiles(input);
            tiles.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }
    }
}
