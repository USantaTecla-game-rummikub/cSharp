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
        public void giveTilesInSerieWithoutJokerWhenDownToTableThenValidGroupIsTrue()
        {
            Table table = new Table();           
            table.addTilesToGroup(this.getTilesSerieGroupWithoutJoker(), TilesGroup.NEW);
            Assert.IsTrue(table.isValidGroups());
        }

        private List<Tile> getTilesSerieGroupWithoutJoker()
        {
            return new List<Tile>() {
                    new Tile(TileNumber.ONE, Color.RED),
                    new Tile(TileNumber.ONE, Color.BLUE),
                    new Tile(TileNumber.ONE, Color.YELLOW),
                    new Tile(TileNumber.ONE, Color.GREEN)
            };
        }

        [Test]
        public void giveTilesInSerieWithJokerWhenDownToTableThenValidGroupIsTrue()
        {
            Table table = new Table();
            table.addTilesToGroup(this.getTilesSerieGroupWithJoker(), TilesGroup.NEW);
            Assert.IsTrue(table.isValidGroups());
        }

        private List<Tile> getTilesSerieGroupWithJoker()
        {
            return new List<Tile>() {
                    new Tile(TileNumber.ONE, Color.RED),
                    new Tile(TileNumber.JOKER, Color.JOKER),
                    new Tile(TileNumber.ONE, Color.YELLOW),
                    new Tile(TileNumber.ONE, Color.GREEN)
            };
        }

        [Test]
        public void giveTilesInRunWithoutJokerWhenDownThenValidGroupIsTrue()
        {
            Table table = new Table();
            table.addTilesToGroup(this.getTilesRunGroupWithoutJoker(), TilesGroup.NEW);
            Assert.IsTrue(table.isValidGroups());
        }

        private List<Tile> getTilesRunGroupWithoutJoker()
        {
            return new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.TWO, Color.RED),
                new Tile(TileNumber.THREE, Color.RED),
                new Tile(TileNumber.FOUR, Color.RED)
                 };
        }

        [Test]
        public void giveTilesInRunWithJokerWhenDownThenValidGroupIsTrue()
        {
            Table table = new Table();
            table.addTilesToGroup(this.getTilesRunGroupWithJoker(), TilesGroup.NEW);
            Assert.IsTrue(table.isValidGroups());
        }

        private List<Tile> getTilesRunGroupWithJoker()
        {
            return new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.TWO, Color.RED),
                new Tile(TileNumber.THREE, Color.RED),
                new Tile(TileNumber.JOKER, Color.JOKER)
                 };
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

        [Test]
        public void giveTilesInWrongSerieNumberWhenDownThenValidGroupIsFalse()
        {
            Table table = new Table();
            table.addTilesToGroup(new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.ONE, Color.BLUE),
                new Tile(TileNumber.TEN, Color.GREEN)
                 }, TilesGroup.NEW);
            Assert.IsFalse(table.isValidGroups());
        }

        [Test]
        public void giveTilesInWrongRunColorWhenDownThenValidGroupIsFalse()
        {
            Table table = new Table();
            table.addTilesToGroup(new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.TWO, Color.RED),
                new Tile(TileNumber.THREE, Color.GREEN)
                 }, TilesGroup.NEW);
            Assert.IsFalse(table.isValidGroups());
        }

        [Test]
        public void giveTilesInWrongRunNumberWhenDownThenValidGroupIsFalse()
        {
            Table table = new Table();
            table.addTilesToGroup(new List<Tile>() {
                new Tile(TileNumber.ONE, Color.RED),
                new Tile(TileNumber.TWO, Color.RED),
                new Tile(TileNumber.FOUR, Color.RED)
                 }, TilesGroup.NEW);
            Assert.IsFalse(table.isValidGroups());
        }

        [Test]
        public void giveTilesInTableWhenSearchByStringThenIsTrue()
        {
            Table table = new Table();
            table.addTilesToGroup(this.getTilesSerieGroupWithoutJoker(), TilesGroup.NEW);
            Assert.IsTrue(table.existTileInTable("1R") && table.existTileInTable("1G") && table.existTileInTable("1B") && table.existTileInTable("1Y"));
        }

        [Test]
        public void giveTilesWithJokerInTableWhenSearchJokerByStringThenIsTrue()
        {
            Table table = new Table();
            table.addTilesToGroup(this.getTilesSerieGroupWithJoker(), TilesGroup.NEW);
            Assert.IsTrue(table.existTileInTable("J"));
        }

        [Test]
        public void giveTableWith2GroupsWhenSearchGroupByIndexThenIsTrue()
        {
            Table table = new Table();
            List<Tile> serieGroup = this.getTilesSerieGroupWithoutJoker();
            List<Tile> runGroup = this.getTilesRunGroupWithoutJoker();
            table.addTilesToGroup(serieGroup, TilesGroup.NEW);
            table.addTilesToGroup(runGroup, TilesGroup.NEW);
            for (int i = 0; i < serieGroup.Count + runGroup.Count; i++)
            {
                table.extract();
            }
            Assert.IsTrue(table.hasGroup(1) && table.hasGroup(2));
        }

        [Test]
        public void giveTableWith2GroupsWhenMoveOneTileAtOtherGroupThenTileExistIsTrue()
        {
            Table table = new Table();
            List<Tile> serieGroup = this.getTilesSerieGroupWithJoker();
            List<Tile> runGroup = this.getTilesRunGroupWithoutJoker();
            table.addTilesToGroup(serieGroup, TilesGroup.NEW);
            table.addTilesToGroup(runGroup, TilesGroup.NEW);
            table.moveTileFromOriginGroupToTargetGroup("J", 1, 2);                        
            Assert.IsTrue(table.existTileInTable("J") && table.existsTileInGroup("J", 2));
        }

        [Test]
        public void giveTableWith2GroupsWhenMoveOneTileAtNewGroupThenTileExistIsTrue()
        {
            Table table = new Table();
            List<Tile> serieGroup = this.getTilesSerieGroupWithJoker();
            List<Tile> runGroup = this.getTilesRunGroupWithoutJoker();
            table.addTilesToGroup(serieGroup, TilesGroup.NEW);
            table.addTilesToGroup(runGroup, TilesGroup.NEW);
            table.moveTileFromOriginGroupToTargetGroup("J", 1, TilesGroup.NEW);
            Assert.IsTrue(table.existTileInTable("J") && table.existsTileInGroup("J", 3));
        }

        [Test]
        public void givenTableWithGroup1WhenPutInGroup1ThenNewTileExistInGroup1IsOk()
        {
            Table table = new Table();
            List<Tile> runGroup = this.getTilesRunGroupWithoutJoker();
            table.addTilesToGroup(runGroup, TilesGroup.NEW);
            List<Tile> newTile = new List<Tile>() { new Tile(TileNumber.FIVE, Color.RED) };
            table.addTilesToGroup(newTile, 1);             
            Assert.IsTrue(table.existsTileInGroup("5R", 1) );
        }

        [Test]
        public void givenTableWithGroup1WhenPutInGroup1ThenIsValidAdd()
        {
            Table table = new Table();
            List<Tile> runGroup = this.getTilesRunGroupWithoutJoker();
            table.addTilesToGroup(runGroup, TilesGroup.NEW);
            List<Tile> newTile = new List<Tile>() { new Tile(TileNumber.FIVE, Color.RED), new Tile(TileNumber.SIX, Color.RED) };            
            Assert.IsTrue(table.isValidAddTilesInGroup(newTile, 1));
        }

        [Test]
        public void givenTableWithRunGroupWhenPutInRunGroupASerieGroupThenNotIsValidAddTilesInGroup()
        {
            Table table = new Table();
            List<Tile> runGroup = this.getTilesRunGroupWithoutJoker();
            table.addTilesToGroup(runGroup, TilesGroup.NEW);
            List<Tile> newTiles = new List<Tile>() { new Tile(TileNumber.EIGHT, Color.RED), new Tile(TileNumber.EIGHT, Color.GREEN), new Tile(TileNumber.EIGHT, Color.BLUE) };
            Assert.IsFalse(table.isValidAddTilesInGroup(newTiles, 1));
        }

        [Test]
        public void givenTableWellFormedWhenSerializeAndDeserializeThenRestoreOK()
        {
            Table table = new Table();
            List<Tile> runGroup = this.getTilesRunGroupWithoutJoker();
            table.addTilesToGroup(runGroup, TilesGroup.NEW);
            string serializedTable = table.tilesGroupToString();
            string serializedPounch = table.pounchToString();
            List<Tile> newTile = new List<Tile>() { new Tile(TileNumber.FIVE, Color.RED) };
            table.addTilesToGroup(newTile, 1);
            table.set(serializedTable, serializedPounch);
            Assert.IsFalse(table.existTileInTable("5R"));
        }
    }
}
