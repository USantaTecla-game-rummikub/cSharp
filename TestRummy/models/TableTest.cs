using NUnit.Framework;
using Rummy.models;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRummy.models
{
    class TableTest
    {
        [Test]
        public void giveTilesInSerieWhenDownThenValidGroupIsTrue()
        {
            Table table = new Table();           
            table.addTilesToGroup(new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.ONE, Color.BLUE),
                new Tile(TileNumber.ONE, Color.YELLOW),
                new Tile(TileNumber.ONE, Color.GREEN)
                 }, TilesGroup.NEW);
            Assert.IsTrue(table.isValidGroups());
        }

        [Test]
        public void giveTilesInRunWhenDownThenValidGroupIsTrue()
        {
            Table table = new Table();
            table.addTilesToGroup(new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.TWO, Color.RED),
                new Tile(TileNumber.THREE, Color.RED)
                 }, TilesGroup.NEW);
            Assert.IsTrue(table.isValidGroups());
        }

        [Test]
        public void giveTilesInWrongSerieColorWhenDownThenValidGroupIsFalse()
        {
            Table table = new Table();
            table.addTilesToGroup(new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.ONE, Color.GREEN)
                 }, TilesGroup.NEW);
            Assert.IsFalse(table.isValidGroups());
        }
    }
}
