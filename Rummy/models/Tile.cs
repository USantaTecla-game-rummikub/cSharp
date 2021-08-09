using Rummy.types;
using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Rummy.models
{
    public class Tile
    {        
        private TileNumber number;
        private Color color;
        public Tile(TileNumber number, Color color)
        {
            this.number = number;
            this.color = color;
        }        

        public Tile()
        {

        }

        public TileNumber getNumber() {
            return this.number;
        }
        public void clone(Tile tile)
        {
            this.number = tile.number;
            this.color = tile.color;
        }      

        public bool isNumberLessThan(Tile tile)
        {
            return this.number < tile.number;
        }

        public bool isNumberGreaterThan(Tile tile)
        {
            return this.number > tile.number;
        }        

        public bool isColorEqualsTo(Tile tile)
        {
            return this.color == tile.color;
        }

        public bool isColorEqualsTo(Color color)
        {
            return this.color == color;
        }

        public bool isColorEqualsTo(string tile) {                        
            if (tile.ToUpper() == Pounch.getColorVisualFormat(Color.JOKER))
            {
                return Pounch.getColorVisualFormat(this.color) == tile.ToUpper();
            }
            else
            {                
                int i = 0;
                foreach (char token in tile)
                {
                    if (Regex.IsMatch(token.ToString(), "[0-9]"))
                    {
                        i++;
                    } else
                    {
                        break;
                    }
                }                
                return Pounch.getColorVisualFormat(this.color) == tile[i].ToString().ToUpper();
            }
        }

        public override string ToString()
        {
            if (!this.isJoker())
            {
                return Pounch.getNumberVisualFormat(this.number) + Pounch.getColorVisualFormat(this.color);
            } else
            {
                return Pounch.getNumberVisualFormat(this.number);
            }
        }

        public bool isNumberDistinctTo(Tile tile)
        {
            return this.number != tile.number;
        }

        public bool isNumberLessOrEqualThan(Tile tile)
        {
            return this.number <= tile.number;
        }

        public bool isJoker()
        {
            return this.number == TileNumber.JOKER && this.color == Color.JOKER;
        }

        public bool isColorDistinct(Tile tile)
        {
            return this.color != tile.color;
        }

        public bool isNumberEqualTo(Tile tile)
        {
            return this.number == tile.number;
        }

        public bool isNumberEqualTo(string tileString) {                           
            if (tileString.ToUpper() == Pounch.getNumberVisualFormat(TileNumber.JOKER))
            {
                return Pounch.getNumberVisualFormat(this.number) == tileString.ToUpper();
            }
            else
            {
                string num = "";                
                foreach (char token in tileString)
                {
                    if (Regex.IsMatch(token.ToString(), "[0-9]"))
                    {
                        num += token;                        
                    }
                    else
                    {
                        break;
                    }
                }
                return int.Parse(Pounch.getNumberVisualFormat(this.number)) == int.Parse(num);
            }
        }

        internal bool distanceIsOne(Tile tile2)
        {
            return Math.Abs((int)this.number - (int)tile2.number) == 1;
        }
    }
}