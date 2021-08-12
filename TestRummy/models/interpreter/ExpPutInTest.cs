using NUnit.Framework;
using Rummy.controllers;
using Rummy.controllers.implementation;
using Rummy.models;
using Rummy.models.DAO;
using Rummy.models.interpreter;
using Rummy.types;
using Rummy.views;
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
            List<TileRack> expTiles = new List<TileRack>()
            {
                new TileRack("10R"), new TileRack("11R"), new TileRack("12R")
            };                        
            PutIn expPutIn = new PutIn(expTiles, group);
            PlayController playController = this.getPlayController();
            
            // expPutIn.execute();
            Assert.IsFalse(expPutIn.hasError());
        }

        private PlayController getPlayController()
        {
            SessionImplementation session = new SessionImplementation();
            StartControllerImplementation startController = new StartControllerImplementation(session);
            startController.play(2);
            PlayControllerImplementation playController = new PlayControllerImplementation(session, new SessionImplementationDAO());            
            playController.takeTurn();
            return (PlayController)playController;
        }

        [Test]
        public void givenRunAndGroupIndexWithGreater30pointsWhenParsePutInWithDistinctTilesThenHasError()
        {
            Player player = new Player(new Table());
            this.setRunGroup(player);
            Group group = new Group();
            List<TileRack> expTiles = new List<TileRack>()
            {
                new TileRack("10R"), new TileRack("11R"), new TileRack("13R")
            };
            PutIn expPutIn = new PutIn(expTiles, group);
            // expPutIn.interpret(player);
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
            List<TileRack> expTiles = new List<TileRack>()
            {
                new TileRack("1R"), new TileRack("2R"), new TileRack("3R")
            };
            PutIn expPutIn = new PutIn(expTiles, group);
            // expPutIn.interpret(player);
            Assert.IsTrue(expPutIn.hasError() && expPutIn.getError() == ErrorMessage.WRONG_POINTS);
        }
    }
}
