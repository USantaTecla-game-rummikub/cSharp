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
            int i = 0;
            int num;
            foreach (char token in tile) {
                if (!int.TryParse(token.ToString(), out num)) {                               
                    break;
                } else {
                    i++;
                }
            }
            return this.color.ToString() == tile[i].ToString();
        }

        internal void write()
        {
            Console.Write(Pounch.getNumberVisualFormat(this.number) +  Pounch.getColorVisualFormat(this.color));
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
            int i = 0;
            int aux;
            string num = "";
            foreach (char token in tileString) {
                if (int.TryParse(token.ToString(), out aux)) {
                    num += token;
                    i++;
                }
                else {
                    break;
                }
            }          
            return int.Parse(this.number.ToString()) == int.Parse(num);
        }
    }
}