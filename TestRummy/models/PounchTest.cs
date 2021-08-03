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
    class PounchTest
    {       
        [Test]
        public void givenColorWhenCompareWithStringThenOk() {

            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            Assert.IsTrue(Pounch.getColorVisualFormat(Color.RED) == "R" && Pounch.getColorVisualFormat(Color.JOKER) == "J");            
        }

        [Test]
        public void givenNumberWhenCompareWithStringThenOk()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            Assert.IsTrue(Pounch.getNumberVisualFormat(TileNumber.ONE) == "1" && Pounch.getNumberVisualFormat(TileNumber.THIRTEEN) == "13");
            Assert.IsTrue(Pounch.getNumberVisualFormat(TileNumber.JOKER) == "J");
        }

        [Test]
        public void givePounchWhenExtractThenCount()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            Tile tile = pounch.extract();
            Assert.IsTrue(pounch.count() == Table.TILES_TOTALES - 1);
        }

        [Test]
        public void givePounchWhenExtractAllThenisEmpty()
        {
            Pounch pounch = new Pounch(Table.TILES_TOTALES);
            for (int i = 0; i < Table.TILES_TOTALES; i++)
            {
                pounch.extract();
            }
            Assert.IsTrue(pounch.isEmpty());
        }

        [Test]
        public void givenPounchWhenSearchByTileDescriptionThenTileFindedIsTrue()
        {            
            Tile tile = Pounch.getTileByDescription("8R");
            Assert.IsTrue(tile.isNumberEqualTo("8") && tile.isColorEqualsTo(Color.RED));
        }
    }
}
