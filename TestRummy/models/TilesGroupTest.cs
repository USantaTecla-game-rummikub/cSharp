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
        public void givenTileWhenGetPointsThenIsTrue()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroup();
            Assert.IsTrue(group.getPoints() == 4);
        }

        [Test]
        public void givenSerieWithoutJokerWhenTestSizeThenIsTrue()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group1 = this.getSerieGroup();
            Assert.IsTrue(group1.isSizeValidForSerie());
        }

        [Test]
        public void givenSerieWithJokerWhenTestSizeThenIsTrue()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroupWithOneJoker();
            Assert.IsTrue(group.isSizeValidForSerie());
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

        private TilesGroup getSerieGroupWithOneJoker()
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            Tile tile1 = new Tile(TileNumber.ONE, Color.BLUE);
            Tile tile2 = new Tile(TileNumber.ONE, Color.RED);
            Tile tile3 = new Tile(TileNumber.JOKER, Color.JOKER);
            Tile tile4 = new Tile(TileNumber.ONE, Color.YELLOW);
            group.addTile(tile1);
            group.addTile(tile2);
            group.addTile(tile3);
            group.addTile(tile4);
            return group;
        }

        [Test]
        public void givenSerieWithoutJokerWhenTestValidThenIsTrue()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group1 = this.getSerieGroup();
            Assert.IsTrue(group1.isSerieValid());
        }

        [Test]
        public void givenSerieWithJokerWhenTestValidThenIsTrue()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroupWithOneJoker();
            Assert.IsTrue(group.isSerieValid());
        }

        [Test]
        public void givenRunWithoutJokerWhenTestThenIsOk()
        {
            TilesGroup group1 = this.getRunGroup();
            Assert.IsTrue(group1.isRunValid());
        }

        [Test]
        public void givenRunWithJokerWhenTestThenIsOk()
        {
            TilesGroup group2 = this.getRunGroupWithOneJoker();
            Assert.IsTrue(group2.isRunValid());
        }

        [Test]
        public void givenRunWithoutJokerWhenTestSizeThenIsOk()
        {
            TilesGroup group = this.getRunGroup();
            Assert.IsTrue(group.isSizeValidForRun());
        }

        [Test]
        public void givenRunWithJokerWhenTestSizeThenIsOk()
        {
            TilesGroup group = this.getRunGroupWithOneJoker();
            Assert.IsTrue(group.isSizeValidForRun());
        }

        private TilesGroup getRunGroup()
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            Tile tile1 = new Tile(TileNumber.ONE, Color.RED);
            Tile tile2 = new Tile(TileNumber.TWO, Color.RED);
            Tile tile3 = new Tile(TileNumber.THREE, Color.RED);
            Tile tile4 = new Tile(TileNumber.FOUR, Color.RED);
            group.addTile(tile1);
            group.addTile(tile2);
            group.addTile(tile3);
            group.addTile(tile4);
            return group;
        }

        private TilesGroup getRunGroupWithOneJoker()
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            Tile tile1 = new Tile(TileNumber.ONE, Color.RED);
            Tile tile2 = new Tile(TileNumber.TWO, Color.RED);
            Tile tile3 = new Tile(TileNumber.JOKER, Color.JOKER);
            Tile tile4 = new Tile(TileNumber.FOUR, Color.RED);
            group.addTile(tile1);
            group.addTile(tile2);
            group.addTile(tile3);
            group.addTile(tile4);
            return group;
        }

        [Test]
        public void givenTileWhenTestIndexThenOk()
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            Assert.IsTrue(group.hasIndex(TilesGroup.NEW));
        }

        [Test]
        public void givenSerieWithoutJokerWhenSearchOneTileThenIsFinded()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroup();
            Tile tileOneRed = new Tile(TileNumber.ONE, Color.RED);
            Assert.IsTrue(group.getTile(tileOneRed) != null && group.getTile("1R") != null);
        }

        [Test]
        public void givenSerieWithJokerWhenSearchOneTileThenIsFinded()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getSerieGroupWithOneJoker();
            Tile tileJoker = new Tile(TileNumber.JOKER, Color.JOKER);
            Assert.IsTrue(group.getTile(tileJoker) != null && group.getTile("J") != null);
        }

        [Test]
        public void givenRunWithoutJokerWhenSearchOneTileThenIsFinded()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getRunGroup();
            Tile tileFourRed = new Tile(TileNumber.FOUR, Color.RED);
            Assert.IsTrue(group.getTile(tileFourRed) != null && group.getTile("4R") != null);
        }

        [Test]
        public void givenRunWithJokerWhenSearchOneTileThenIsFinded()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup group = this.getRunGroupWithOneJoker();
            Tile joker = new Tile(TileNumber.JOKER, Color.JOKER);
            Assert.IsTrue(group.getTile(joker) != null && group.getTile("J") != null);
        }

        [Test]
        public void givenRunGroup1WhenPutInNewTileInGroup1ThenGroupValid() { 

            TilesGroup group = this.getRunGroup();
            group.addTile(new Tile(TileNumber.FIVE, Color.RED));
            Assert.IsTrue(group.isSizeValidForRun() && group.getPoints() == 15);    
        }

        [Test]
        public void givenGroupsWhenToStringThenIsTrueTheirTextRepresentations()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup groupSerie = this.getSerieGroup();
            TilesGroup groupRun = this.getRunGroup();
            TilesGroup groupSerieWithJoker = this.getSerieGroupWithOneJoker();
            TilesGroup groupRunWithJoker = this.getRunGroupWithOneJoker();
            Assert.IsTrue(groupSerie.ToString() == "0.1B 1R 1G 1Y \n" && groupRun.ToString() == "0.1R 2R 3R 4R \n" && groupSerieWithJoker.ToString() == "0.1B 1R J 1Y \n" && groupRunWithJoker.ToString() == "0.1R 2R J 4R \n");
        }

        [Test]
        public void givenStringSerieGroupWhenDeserializeThenIsTrueTilesGroup()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup groupSerie = new TilesGroup(TilesGroup.NEW);
            groupSerie.set("0.1B 1R 1G 1Y \n");
            Assert.IsTrue(groupSerie.hasIndex(0) && groupSerie.getTile("1B") != null && groupSerie.getTile("1R") != null && groupSerie.getTile("1G") != null && groupSerie.getTile("1Y") != null);
        }

        [Test]
        public void givenRunGroupWhenAddTileWithoutOrderThenIsGroupWellFormed()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            TilesGroup groupRun = new TilesGroup(TilesGroup.NEW);            
            groupRun.addTile(new Tile(TileNumber.ONE, Color.RED));
            groupRun.addTile(new Tile(TileNumber.THREE, Color.RED));
            groupRun.addTile( new Tile(TileNumber.FOUR, Color.RED));
            groupRun.addTile(new Tile(TileNumber.TWO, Color.RED));
            Assert.IsTrue(groupRun.isValid());
        }
    }
}
