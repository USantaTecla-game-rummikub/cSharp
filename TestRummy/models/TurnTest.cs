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
    public class TurnTest
    {
        private const int NUM_PLAYERS = 2;

        [Test]
        public void givenTurnWith2PlayersWhenTakeTurnThenPlayerIsStartTurn()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();            
            Assert.IsTrue(player.getLastAction() == ActionType.STARTTURN);
        }

        [Test]
        public void givenTurnWith2PlayersWhenCurrentPlayerFinishTurnThenIsEnd()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            player.finishTurn(); 
            Assert.IsTrue( turn.isEnd() );
        }

        [Test]
        public void givenTurnWith2PlayersWhenTakePlayerAndChangeTurnThenPlayersAreDifferents()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player1 = turn.take();
            turn.change();
            Player player2 = turn.take();
            Assert.IsTrue(player1 != player2);
        }

        [Test]
        public void givenTurnWith2PlayersWhenTakePlayerTwiceWithoutChangeTurnThenPlayersAreEquals()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player1 = turn.take();            
            Player player2 = turn.take();
            Assert.IsTrue(player1 == player2);
        }

        [Test]
        public void givenTurnWith2PlayersWhenGetWinnerByPointsThenWinnerExists()
        {
            Turn turn = new Turn(NUM_PLAYERS);            
            Player currentPlayer = null;
            while (!turn.hasWinnerByPoints())
            {
                currentPlayer = turn.take();
                currentPlayer.extractTile();
                turn.change();                
            }            
            Assert.IsTrue(turn.getWinnerByPoints() != null);
        }

        [Test]
        public void givenTurnWith2PlayersWhen()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player1 = turn.take();            
            turn.change();            
            Player player2 = turn.take();
            SnapShot snapShot = turn.save();
            turn.change();
            Player player3 = turn.take();
            turn.restore(snapShot);
            Player playerRestored = turn.take();
            Assert.AreEqual(playerRestored, player2);
        }
    }
}
