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
    public class ExpPutTest
    {
        [Test]
        public void givenExpPutWhenInterpretThenNotHasError()
        {
            Player player = new Player(new Table());
            this.setRunGroup(player);
            this.setSerieGroup(player);
            List<PutIn> lstPutIn = new List<PutIn>()
            {
                new PutIn(new List<TileRack>() { new TileRack("10R"), new TileRack("11R"), new TileRack("12R") }, new Group()),
                new PutIn(new List<TileRack>() { new TileRack("10Y"), new TileRack("10G"), new TileRack("10B")}, new Group())
            };
            PutCommand expPut = new PutCommand(lstPutIn);
            //expPut.interpret(player);
            //Assert.IsFalse(expPut.hasError());
        }

        [Test]
        public void givenExpPutWithErrorWhenInterpretThenHasError()
        {
            Player player = new Player(new Table());
            this.setRunGroup(player);
            this.setSerieGroup(player);
            List<PutIn> lstPutIn = new List<PutIn>()
            {
                new PutIn(new List<TileRack>() { new TileRack("10R"), new TileRack("11R"), new TileRack("12R") }, new Group()),
                new PutIn(new List<TileRack>() { new TileRack("10R"), new TileRack("10G"), new TileRack("10B")}, new Group())
            };
            PutCommand expPut = new PutCommand(lstPutIn);
            //expPut.interpret(player);
            Assert.IsTrue(expPut.hasError());
        }

        private void setRunGroup(Player player)
        {
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.ELEVEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TWELVE, Color.RED));
        }

        private void setSerieGroup(Player player)
        {
            player.addTileInRack(new Tile(TileNumber.TEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.BLUE));
        }
    }
}
