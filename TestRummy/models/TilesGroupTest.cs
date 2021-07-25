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
    public class TilesGroupTest
    {
        [Test]
        public void givenTileWhenAddTileThenOk()
        {

        }

        [Test]
        public void givenSerieWhenTestSizeThenIsOk()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroup();            
            Assert.IsTrue( group.isSizeValidForSerie());
        }

        private TilesGroup getSerieGroup()
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            Tile tile1 = new Tile(TileNumber.ONE, Color.BLUE);
            Tile tile2 = new Tile(TileNumber.ONE, Color.RED);
            Tile tile3 = new Tile(TileNumber.ONE, Color.GREEN);
            Tile tile4 = new Tile(TileNumber.ONE, Color.YELLOW);
            group.addTile(tile1);
            group.addTile(tile2);
            group.addTile(tile3);
            group.addTile(tile4);            
            return group;
        }

        [Test]
        public void givenSerieWhenTestIsValidThenIsOk()
        {            
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroup();
            Assert.IsTrue(group.isSerieValid());
        }

        [Test]
        public void givenRunWhenTestThenIsOk()
        {
            TilesGroup group = this.getRunGroup();
            Assert.IsTrue(group.isRunValid());
        }

        private TilesGroup getRunGroup()
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            Tile tile1 = new Tile(TileNumber.ONE, Color.RED);
            Tile tile2 = new Tile(TileNumber.TWO, Color.RED);
            Tile tile3 = new Tile(TileNumber.THREE, Color.RED);
            group.addTile(tile1);
            group.addTile(tile2);
            group.addTile(tile3);
            return group;
        }

        [Test]
        public void givenTileWhenTestIndexThenOk()
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            Assert.IsTrue(group.hasIndex(TilesGroup.NEW));
        }

        [Test]
        public void givenSerieWhenSearchOneTileThenIsFinded()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroup();
            Tile tileOneRed = new Tile(TileNumber.ONE, Color.RED);
            Assert.IsTrue(group.getTile(tileOneRed) != null && group.getTile("1R") != null);
        }

        [Test]
        public void givenRunWhenSearchOneTileThenIsFinded()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getRunGroup();
            Tile tileOneRed = new Tile(TileNumber.ONE, Color.RED);
            Assert.IsTrue(group.getTile(tileOneRed) != null && group.getTile("1R") != null);
        }
    }
}
