﻿using NUnit.Framework;
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
    public class ExpTileGroupTest
    {
        [Test]
        public void givenOneTileInTableGroupWhenParseSameTileThenNotHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.ONE, Color.RED));
            player.addTilesToGroup(new List<string>() { "1R" }, "");
            ExpTileGroup expTileGroup = new ExpTileGroup("1R");
            expTileGroup.interpret(player);
            Assert.IsFalse(expTileGroup.hasError());
        }

        [Test]
        public void givenOneTileInTableGroupWhenParseSameTileThenHasError()
        {
            Player player = new Player(new Table());
            player.addTileInRack(new Tile(TileNumber.ONE, Color.RED));
            player.addTilesToGroup(new List<string>() { "1R" }, "");
            ExpTileGroup expTileGroup = new ExpTileGroup("2B");
            expTileGroup.interpret(player);
            Assert.IsTrue(expTileGroup.hasError());
        }
    }
}
