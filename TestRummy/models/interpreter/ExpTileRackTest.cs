using NUnit.Framework;
using Rummy.models;
using Rummy.models.interpreter;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRummy.models.interpreter
{
    public class ExpTileRackTest
    {
        [Test]
        public void givenOneTileInRackWhenParseSameTileThenNotHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.ONE, Color.RED));
            TileRack expTileRack = new TileRack("1R");            
            //expTileRack.interpret(player);
            Assert.IsFalse(expTileRack.hasError());
        }

        [Test]
        public void givenOneTileInRackWhenParseDistinctTileThenHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.ONE, Color.RED));
            TileRack expTileRack = new TileRack("2R");
            //expTileRack.interpret(player);
            Assert.IsTrue(expTileRack.hasError());
        }      
    }
}
