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
    public class ExpPutInTest
    {
        [Test]
        public void givenRunAndGroupIndexWithGreater30pointsWhenParsePutInWithSameTilesThenNotHasError()
        {
            Player player = new Player(new Table());
            this.setRunGroup(player);         
            Group group = new Group();
            List<ExpTileRack> expTiles = new List<ExpTileRack>()
            {
                new ExpTileRack("10R"), new ExpTileRack("11R"), new ExpTileRack("12R")
            };                        
            ExpPutIn expPutIn = new ExpPutIn(expTiles, group);
            expPutIn.interpret(player);
            Assert.IsFalse(expPutIn.hasError());
        }

        [Test]
        public void givenRunAndGroupIndexWithGreater30pointsWhenParsePutInWithDistinctTilesThenHasError()
        {
            Player player = new Player(new Table());
            this.setRunGroup(player);
            Group group = new Group();
            List<ExpTileRack> expTiles = new List<ExpTileRack>()
            {
                new ExpTileRack("10R"), new ExpTileRack("11R"), new ExpTileRack("13R")
            };
            ExpPutIn expPutIn = new ExpPutIn(expTiles, group);
            expPutIn.interpret(player);
            Assert.IsTrue(expPutIn.hasError());
        }

        private void setRunGroup(Player player)
        {
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.ELEVEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TWELVE, Color.RED));
        }
        
        [Test]
        public void givenRunAndGroupWithLess30pointsWhenParsePutInWithSameTilesThenHasErrorWrongPoints()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.ONE, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TWO, Color.RED));
            player.addTileInRack(new Tile(TileNumber.THREE, Color.RED));
            Group group = new Group();
            List<ExpTileRack> expTiles = new List<ExpTileRack>()
            {
                new ExpTileRack("1R"), new ExpTileRack("2R"), new ExpTileRack("3R")
            };
            ExpPutIn expPutIn = new ExpPutIn(expTiles, group);
            expPutIn.interpret(player);
            Assert.IsTrue(expPutIn.hasError() && expPutIn.getError() == Message.WRONG_POINTS);
        }
    }
}
