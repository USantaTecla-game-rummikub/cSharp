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
    public class GroupTest
    {
        [Test]
        public void givenGroupWhenParseBySameGroupNumberThenNotHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.ONE, Color.RED));
            player.addTilesToGroup(new List<string>() { "1R" }, "");
            Group group = new Group("1");
            group.interpret(player);
            Assert.IsFalse(group.hasError());
        }

        [Test]
        public void givenGroupWhenParseByDistinctGroupNumberThenHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.ONE, Color.RED));
            player.addTilesToGroup(new List<string>() { "1R" }, "");
            Group group = new Group("2");
            group.interpret(player);
            Assert.IsTrue(group.hasError());
        }
    }
}
