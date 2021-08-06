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
    public class CommandParserTest
    {
        private const string inputPutNewSerie = "PUT 10R 10G 10B";
        private const string inputPutToNotExistSerie = "PUT 10R 10G 10B IN 1";
        private const string inputPutNewRun = "PUT 9R 10R 11R";
        private const string inputPutRunToNotExistGroup = "PUT 9R 10R 11R IN 1";
        private const string inputOtherPutForAddToSerieGroup = "PUT 10Y IN 1";
        private const string inputOtherPutForAddToRunGroup = "PUT 4R IN 1";
        private const string inputPutNewSerieAndNewRunWithMoreThan30 = "PUT 6R 6G 6B 6Y, 7Y 8Y 9Y";
        private const string inputPutNewSerieAndNewRunWithJokerAndMoreThan30 = "PUT 2R 2G J, 7Y 8Y J";
        private const string inputMovFromGroup2ToNewGroup = "MOV FROM 1 6R";
        private const string inputMovFromGroup1ToGroup2 = "MOV FROM 1 6Y IN 2";        

        private const int NUM_PLAYERS = 2;

        public CommandParserTest()
        {

        }

        [Test]
        public void givenPutCommandToNewSerieGroupWhenParseThenIsTrue()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            this.setRackInitialWithSerie(player);
            CommandParser command = new CommandParser(inputPutNewSerie, player);
            command.parse();
            Assert.IsFalse(command.hasError());
        }

        private void setRackInitialWithSerie(Player player)
        {
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.BLUE));
        }

        private void setRackInitialWithRun(Player player)
        {
            player.addTileInRack(new Tile(TileNumber.NINE, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.ELEVEN, Color.RED));
        }

        [Test]
        public void givenPutCommandToSerieGroupNotExistWhenParseThenHasErrorWrongGroup()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            this.setRackInitialWithSerie(player);
            CommandParser command = new CommandParser(inputPutToNotExistSerie, player);
            command.parse();
            Assert.IsTrue(command.hasError() && command.getError() == ErrorMessage.WRONG_GROUP);
        }

        [Test]
        public void givenPutCommandToNewSerieGroupWithWrongTileWhenParseThenIsFalse()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            player.addTileInRack(new Tile(TileNumber.TEN, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TEN, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.ONE, Color.YELLOW));
            CommandParser command = new CommandParser(inputPutNewSerie, player);
            command.parse();
            Assert.IsTrue(command.hasError() && command.getError() == ErrorMessage.WRONG_TILE);
        }

        [Test]
        public void givenPutCommandToNewRunGroupWhenParseThenIsTrue()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            this.setRackInitialWithRun(player);
            CommandParser command = new CommandParser(inputPutNewRun, player);
            command.parse();
            Assert.IsFalse(command.hasError());
        }

        [Test]
        public void givenPutCommandToRunGroupNotExistWhenParseThenHasError()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            this.setRackInitialWithRun(player);
            CommandParser command = new CommandParser(inputPutRunToNotExistGroup, player);
            command.parse();
            Assert.IsTrue(command.hasError() && command.getError() == ErrorMessage.WRONG_GROUP);
        }

        [Test]
        public void givenPutCommandToSerieGroupWhenParseThenIsTrue()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            this.setRackInitialWithSerie(player);
            CommandParser command = new CommandParser(inputPutNewSerie, player);
            command.parse();
            player.addTileInRack(new Tile(TileNumber.TEN, Color.YELLOW));
            command = new CommandParser(inputOtherPutForAddToSerieGroup, player);
            command.parse();
            Assert.IsFalse(command.hasError());
        }

        [Test]
        public void givenPutCommandToRunGroupWhenParseThenNotHasError()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            this.setRackInitialWithRun(player);
            CommandParser command = new CommandParser(inputPutNewRun, player);
            command.parse();
            player.addTileInRack(new Tile(TileNumber.FOUR, Color.RED));
            command = new CommandParser(inputOtherPutForAddToRunGroup, player);
            command.parse();
            Assert.IsFalse(command.hasError());
        }

        [Test]
        public void givenPutNewSerieAndNewRunWithMoreThan30WhenParseThenNotHasError()
        {            
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.SIX, Color.RED));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.BLUE));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.SEVEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.EIGHT, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.NINE, Color.YELLOW));
            CommandParser command = new CommandParser(inputPutNewSerieAndNewRunWithMoreThan30, player);
            command.parse();
            Assert.IsFalse(command.hasError());
        }

        [Test]
        public void givenPutNewSerieAndNewRunWithJokerMoreThan30WhenParseThenNotHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.TWO, Color.RED));
            player.addTileInRack(new Tile(TileNumber.TWO, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.JOKER, Color.JOKER));
            player.addTileInRack(new Tile(TileNumber.SEVEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.EIGHT, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.JOKER, Color.JOKER));
            CommandParser command = new CommandParser(inputPutNewSerieAndNewRunWithJokerAndMoreThan30, player);
            command.parse();
            Assert.IsFalse(command.hasError());
        }

        [Test]
        public void givenInputMovFromGroup2ToNewGroupWhenParseThenNewGroupIs3()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.SIX, Color.RED));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.BLUE));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.SEVEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.EIGHT, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.NINE, Color.YELLOW));
            CommandParser command = new CommandParser(inputPutNewSerieAndNewRunWithMoreThan30, player);
            command.parse();
            command = new CommandParser(inputMovFromGroup2ToNewGroup, player);
            command.parse();            
            Assert.IsTrue(player.existsTileInGroup("6R", 3));
        }

        [Test]
        public void givenInputMovFromGroup1ToGroup2WhenParseThenNotHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.SIX, Color.RED));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.BLUE));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.GREEN));
            player.addTileInRack(new Tile(TileNumber.SIX, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.SEVEN, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.EIGHT, Color.YELLOW));
            player.addTileInRack(new Tile(TileNumber.NINE, Color.YELLOW));
            CommandParser command = new CommandParser(inputPutNewSerieAndNewRunWithMoreThan30, player);
            command.parse();
            command = new CommandParser(inputMovFromGroup1ToGroup2, player);
            command.parse();
            Assert.IsTrue(player.existsTileInGroup("6Y", 2));
        }
    }
}
