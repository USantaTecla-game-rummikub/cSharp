using Rummy.types;
using System;

namespace Rummy.models
{
    public class Tile
    {
        private TileNumber number;
        private Color color;

        public TileNumber getNumber() {
            return this.number;
        }

        public Tile(TileNumber number, Color color)
        {
            this.number = number;
            this.color = color;
        }

        internal bool isNumberLessThan(Tile tile)
        {
            return this.number < tile.number;
        }

        internal bool isNumberGreaterThan(Tile tile)
        {
            return this.number > tile.number;
        }

        internal bool isColorEqualsTo(Tile tile)
        {
            return this.color == tile.color;
        }

        internal bool isNumberDistinctTo(Tile tile)
        {
            return this.number != tile.number;
        }

        public bool isNumberLessOrEqualThan(Tile tile)
        {
            return this.number <= tile.number;
        }

        internal bool isColorDistinct(Tile tile)
        {
            return this.color != tile.color;
        }
    }
}