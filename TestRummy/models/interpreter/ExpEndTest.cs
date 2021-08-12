using NUnit.Framework;
using Rummy.models;
using Rummy.models.interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRummy.models.interpreter
{
    public class ExpEndTest
    {
        private const int NUM_PLAYERS = 2;

        [Test]
        public void givenPlayerWithoutActionWhenInterpretExpEndThenNumPointsPlusOne()
        {
            Turn turn = new Turn(NUM_PLAYERS);
            Player player = turn.take();
            int numPointsInitials = player.getPoints();
            EndCommand expEnd = new EndCommand();
            //expEnd.execute(player);
            Assert.IsTrue(player.isEnd() && player.getPoints() == (numPointsInitials + 1));
        }
    }
}
