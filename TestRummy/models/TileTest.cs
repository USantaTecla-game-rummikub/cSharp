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
    class TileTest
    {
        [Test]
        public void givenTilesWhenSearchByStringTheseThenExist()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);                                                            
            Array numbers = Enum.GetValues(typeof(TileNumber));
            Array colors = Enum.GetValues(typeof(Color));                        
            foreach (Color color in colors)
            {
                Tile tile = new Tile(TileNumber.ONE, color);
                Assert.IsTrue(tile.isNumberEqualTo(Pounch.getNumberVisualFormat(TileNumber.ONE)) && tile.isColorEqualsTo(Pounch.getColorVisualFormat(color)));
            }
            foreach (Color color in colors)
            {
                Tile tile = new Tile(TileNumber.SEVEN, color);
                Assert.IsTrue(tile.isNumberEqualTo(Pounch.getNumberVisualFormat(TileNumber.SEVEN)) && tile.isColorEqualsTo(Pounch.getColorVisualFormat(color)));
            }
            foreach (Color color in colors)
            {
                Tile tile = new Tile(TileNumber.THIRTEEN, color);
                Assert.IsTrue(tile.isNumberEqualTo(Pounch.getNumberVisualFormat(TileNumber.THIRTEEN)) && tile.isColorEqualsTo(Pounch.getColorVisualFormat(color)));
            }
        }

        [Test]
        public void givenEqualTilesWhenCompareThenAreEquals()
        {
            Tile tile1 = new Tile(TileNumber.ONE, Color.GREEN);
            Tile tile2 = new Tile(TileNumber.ONE, Color.GREEN);            
            Tile tile3 = new Tile(TileNumber.JOKER, Color.JOKER);
            Tile tile4 = new Tile(TileNumber.JOKER, Color.JOKER);
            Assert.IsTrue(tile1.isNumberEqualTo(tile2) && tile1.isColorEqualsTo(tile2));
            Assert.IsTrue(tile3.isNumberEqualTo(tile4) && tile3.isColorEqualsTo(tile4));
        }        

        [Test]
        public void givenDistinctTilesWhenCompareThenAreDistinct()
        {
            Tile tile1 = new Tile(TileNumber.ONE, Color.GREEN);
            Tile tile2 = new Tile(TileNumber.TWO, Color.GREEN);
            Tile tile3 = new Tile(TileNumber.JOKER, Color.JOKER);
            Tile tile4 = new Tile(TileNumber.SEVEN, Color.RED);
            Assert.IsTrue(tile1.isNumberDistinctTo(tile2) || tile1.isColorDistinct(tile2));
            Assert.IsTrue(tile3.isNumberDistinctTo(tile4) || tile3.isColorDistinct(tile4));
        }

        [Test]
        public void givenTileWhenCloneThenIsOk()
        {
            Tile tileToCopy = new Tile(TileNumber.SIX, Color.GREEN);
            Tile tile = new Tile(TileNumber.ONE, Color.RED);
            tile.clone(tileToCopy);
            Assert.IsTrue(tile.isNumberEqualTo(tileToCopy) && tile.isColorEqualsTo(tileToCopy));
        }

        [Test]
        public void givenTileWhenJokerThenIsOk()
        {
            Tile tile = new Tile(TileNumber.JOKER, Color.JOKER);
            Assert.IsTrue(tile.isJoker());
        }

        [Test]
        public void givenTwoJokersWhenCompareThenIsTrue()
        {
            Tile tile = new Tile(TileNumber.JOKER, Color.JOKER);
            Tile tile2 = new Tile(TileNumber.JOKER, Color.JOKER);
            Assert.IsTrue(tile.isNumberEqualTo(tile2) && tile.isColorEqualsTo(tile2));
        }

        [Test]
        public void givenTwoTilesWhenCompareTheNumbersFirstIsLessThatSecondThenIsOk()
        {
            Tile tile1 = new Tile(TileNumber.TWO, Color.RED);
            Tile tile2 = new Tile(TileNumber.TEN, Color.BLUE);
            Assert.IsTrue(tile1.isNumberLessThan(tile2));
        }

        [Test]
        public void givenTwoTilesWhenCompareTheNumbersFirstIsGreaterThatSecondThenIsOk()
        {
            Tile tile2 = new Tile(TileNumber.TWO, Color.RED);
            Tile tile1 = new Tile(TileNumber.TEN, Color.BLUE);
            Assert.IsTrue(tile1.isNumberGreaterThan(tile2));
        }

        [Test]
        public void givenTileWhenToSerializeThenIsTrueTextRepresentations()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            Tile tile1 = new Tile(TileNumber.TWO, Color.RED);
            Tile tile2 = new Tile(TileNumber.JOKER, Color.JOKER);
            Assert.IsTrue(tile1.ToString() == "2R" && tile2.ToString() == "J");
        }
    }
}
