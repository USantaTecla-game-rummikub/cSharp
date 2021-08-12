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
    public class ExpMovInTest
    {
        [Test]
        public void givenTwoGroupsOnTableWhenMoveOneTileToOtherGroupThenNotHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.ELEVEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TWELVE, Color.RED));
            player.addTileInRack(new Tile(TileNumber.THIRTEEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.BLUE));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.GREEN));            
            player.addTilesToGroup(new List<string>() { "10R", "11R", "12R", "13R" }, Group.NEW);
            player.addTilesToGroup(new List<string>() { "10B", "10G" }, Group.NEW);                        
            MovIn expMovIn = new MovIn(new List<TileGroup>() { new TileGroup("10R") }, new Group("1"), new Group("2"));
            //expMovIn.interpret(player);
            Assert.IsFalse(expMovIn.hasError());
        }

        [Test]
        public void givenTwoGroupsOnTableWhenMoveOneWrongTileToOtherGroupThenHasErrorWrongTile()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.ELEVEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TWELVE, Color.RED));
            player.addTileInRack(new Tile(TileNumber.THIRTEEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.BLUE));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.GREEN));
            player.addTilesToGroup(new List<string>() { "10R", "11R", "12R", "13R" }, Group.NEW);
            player.addTilesToGroup(new List<string>() { "10B", "10G" }, Group.NEW);            
            MovIn expMovIn = new MovIn(new List<TileGroup>() { new TileGroup("10B") }, new Group("1"), new Group("2"));
            //expMovIn.interpret(player);
            Assert.IsTrue(expMovIn.hasError());
        }
    }
}
