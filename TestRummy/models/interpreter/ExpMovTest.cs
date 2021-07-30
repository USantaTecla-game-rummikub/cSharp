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
    public class ExpMovTest
    {
        [Test]
        public void givenTwoGroupsOnTheTableWhenParseExpMovThenNotHasError()
        {
            Player player = new Player(new Table());
            this.setRunGroup(player);
            this.setSerieGroup(player);
            player.addTilesToGroup(new List<string>() { "10R", "11R", "12R", "13R" }, Group.NEW);
            player.addTilesToGroup(new List<string>() { "10Y", "10G", "10B" }, Group.NEW);
            List<ExpMovIn> lstMovIn = new List<ExpMovIn>()
            {
                new ExpMovIn(new List<ExpTileGroup>() { new ExpTileGroup("10R")}, new Group("1"), new Group("2"))
            };
            ExpMov expMov = new ExpMov(lstMovIn);
            expMov.interpret(player);
            Assert.IsFalse(expMov.hasError());
        }

        [Test]
        public void givenTwoGroupsOnTheTableWhenParseExpMovThenHasWrongTileError()
        {
            Player player = new Player(new Table());
            this.setRunGroup(player);
            this.setSerieGroup(player);
            player.addTilesToGroup(new List<string>() { "10R", "11R", "12R", "13R" }, Group.NEW);
            player.addTilesToGroup(new List<string>() { "10Y", "10G", "10B" }, Group.NEW);
            List<ExpMovIn> lstMovIn = new List<ExpMovIn>()
            {
                new ExpMovIn(new List<ExpTileGroup>() { new ExpTileGroup("10B")}, new Group("1"), new Group("2"))
            };
            ExpMov expMov = new ExpMov(lstMovIn);
            expMov.interpret(player);
            Assert.IsTrue(expMov.hasError() && expMov.getError() == ErrorMessage.WRONG_TILE);
        }

        private void setRunGroup(Player player)
        {            
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.ELEVEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TWELVE, Color.RED));
            player.addTileInRack(new Tile(TileNumber.THIRTEEN, Color.RED));
        }

        private void setSerieGroup(Player player)
        {
            player.addTileInRack(new Tile(TileNumber.TEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.BLUE));
        }
    }
}
