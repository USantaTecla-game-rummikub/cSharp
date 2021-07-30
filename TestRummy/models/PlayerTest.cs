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
    class PlayerTest
    {
        [Test]
        public void givenRackWhenAddTileValidThenExistTileIsOk()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.FIVE, Color.BLUE));
            player.addTileInRack(new Tile(TileNumber.JOKER, Color.JOKER));
            Assert.IsTrue( player.existTileInRack("5B") && player.existTileInRack("J"));
        }

        [Test]
        public void givenRackWhenAddTileNotValidThenExistTileIsFalse()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.FIVE, Color.BLUE));
            Assert.IsFalse(player.existTileInRack("5T"));
        }

        [Test]
        public void givenGroupDownToTableWhenSearchTilesInTableThenIsTrue()
        {
            Player player = this.getPlayerWithSerieGroupTiles();
            player.addTilesToGroup(new List<string>() { "10R", "10G", "10B" }, "");
            Assert.IsTrue(player.existTileInTable("10R") && player.existTileInTable("10R") && player.existTileInTable("10R"));
        }

        [Test]
        public void givenGroupDownToTableWhenSearchTilesNotExistsThenIsFalse()
        {
            Player player = this.getPlayerWithSerieGroupTiles();
            player.addTilesToGroup(new List<string>() { "10R", "10G", "10B" }, "");
            Assert.IsFalse(player.existTileInTable("10Y") && player.existTileInTable("1R") && player.existTileInTable("11G"));
        }

        [Test]
        public void givenTilesInRackWith30pointsWhenGetPointsThenAdd30PointsIsOk()
        {
            Player player = this.getPlayerWithSerieGroupTiles();
            Assert.IsTrue(player.getPoints() == 30);
        }

        [Test]
        public void givenTilesWhenTilesDownThenLastActionIsTilesDown()
        {
            Player player = this.getPlayerWithSerieGroupTiles();
            player.addTilesToGroup(new List<string>() { "10R", "10G", "10B" }, "");
            Assert.IsTrue(player.getLastAction() == ActionType.TILEDOWN);
        }

        [Test]
        public void givenTilesInRackWith30pointsWhenTestIfIsAllowedToTileDownThenIsOk()
        {
            Player player = this.getPlayerWithSerieGroupTiles();
            Assert.IsTrue(player.isAllowedToTileDown(new List<string>() { "10R", "10G", "10B" }));
        }

        [Test]
        public void givenTilesInRackWhenAllTilesDownThenIsWinner()
        {
            Player player = this.getPlayerWithSerieGroupTiles();
            player.addTilesToGroup(new List<string>() { "10R", "10G", "10B" }, "");
            Assert.IsTrue(player.isWinner());
        }

        [Test]
        public void givenTilesInRackWhenTilesDownThenExistGroup()
        {
            Player player = this.getPlayerWithSerieAndRunGroupTiles();            
            player.addTilesToGroup(new List<string>() { "10R", "10G", "10B" }, "");
            player.addTilesToGroup(new List<string>() { "10Y", "11Y", "12Y", "13Y" }, "");            
            Assert.IsTrue(player.existGroup("1") && player.existGroup("2"));            
        }

        [Test]
        public void givenGroupsInTableWhenMoveTilesInterGroupThenValidateLastMovementIsTrue()
        {
            Player player = this.getPlayerWithSerieAndRunGroupTiles();
            player.addTilesToGroup(new List<string>() { "10R", "10G", "10B" }, "");
            player.addTilesToGroup(new List<string>() { "10Y", "11Y", "12Y", "13Y" }, "");
            player.moveTileFromGroupToGroup("10Y", 2, 1);
            Assert.IsTrue(player.getLastAction() == ActionType.GROUPMOVEMENT);
        }

        [Test]
        public void givenPlayerWhenExtractThenLastActionIsExtract()
        {
            Player player = new Player(new Table());
            player.extractTile();
            Assert.IsTrue(player.getLastAction() == ActionType.EXTRACT);
        }

        [Test]
        public void givenPlayerWithoutTilesDownWhenFinishTurnThenLastActionIsExtract() {
            Player player = this.getPlayerWithSerieGroupTiles();
            player.finishTurn(); 
            Assert.IsTrue(player.getLastAction() == ActionType.EXTRACT);
        }

        private Player getPlayerWithSerieGroupTiles()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.BLUE));
            return player;
        }

        private Player getPlayerWithSerieAndRunGroupTiles()
        {
            Player player = this.getPlayerWithSerieGroupTiles();
            player.addTileInRack(new Tile(TileNumber.TEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.ELEVEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.TWELVE, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.THIRTEEN, Color.YELLOW));
            return player;
        }

    }
}
