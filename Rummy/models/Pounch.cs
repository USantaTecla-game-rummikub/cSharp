using Rummy.types;
using Rummy.views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class Pounch
    {
        private static Hashtable numbersVisualFormat;
        private static Hashtable colorsVisualFormat;
        private Tile[] pounch;
        private int top;
        private int numTiles;

        public Pounch(int numTiles) {
            this.numTiles = numTiles;
            this.createNumbersVisualizationFormat();
            this.createColorsVisualizationFormat();
            this.top = 0;
            this.createTiles(numTiles);
            this.shuffleTiles();
        }

        private void createNumbersVisualizationFormat()
        {
            numbersVisualFormat = new Hashtable()
            {
                [TileNumber.ONE] = "1",
                [TileNumber.TWO] = "2",
                [TileNumber.THREE] = "3",
                [TileNumber.FOUR] = "4",
                [TileNumber.FIVE] = "5",
                [TileNumber.SIX] = "6",
                [TileNumber.SEVEN] = "7",
                [TileNumber.EIGHT] = "8",
                [TileNumber.NINE] = "9",
                [TileNumber.TEN] = "10",
                [TileNumber.ELEVEN] = "11",
                [TileNumber.TWELVE] = "12",
                [TileNumber.THIRTEEN] = "13",
                [TileNumber.JOKER] = "J"
            };
        }

        private void createColorsVisualizationFormat()
        {
            colorsVisualFormat = new Hashtable()
            {
                [Color.RED] = "R",
                [Color.GREEN] = "G",
                [Color.BLUE] = "B",                              
                [Color.YELLOW] = "Y",
                [Color.JOKER] = "J"
            };
        }

        public static string getColorVisualFormat(Color color)
        {
            return colorsVisualFormat[color].ToString();
        }

        public static string getNumberVisualFormat(TileNumber number)
        {
            return numbersVisualFormat[number].ToString();
        }

        public static Tile getTileByDescription(string tileDescription) {
            Tile tile = null;
            TileNumber tileNumber = TileNumber.JOKER;
            Color color = Color.JOKER;
            bool finded = false;            

            foreach (TileNumber key in numbersVisualFormat.Keys) {
                if (tileDescription.Contains((string)Pounch.numbersVisualFormat[key])) {
                    tileNumber = key;
                    finded = true;
                    break;
                }
            }
            if (finded) {
                finded = false;
                foreach (Color key in colorsVisualFormat.Keys) {
                    if (tileDescription.Contains((string)Pounch.colorsVisualFormat[key])) {
                        color = key;
                        finded = true;
                        break;
                    }
                }
            }
            if (finded) {
                tile = new Tile(tileNumber, color);
            }
            return tile;
        }

        private void createTiles(int numTiles) {
            this.pounch = new Tile[numTiles];            
            Array numbers = Enum.GetValues(typeof(TileNumber));
            Array colors = Enum.GetValues(typeof(Color));
            for (int i = 0; i < 2; i++)
            {
                foreach (TileNumber number in numbers)
                {
                    if (number != TileNumber.JOKER)
                    {
                        foreach (Color color in colors)
                        {
                            if (color != Color.JOKER)
                            {
                                Tile tile = new Tile(number, color);
                                this.pounch[this.top++] = tile;                                
                            }
                        }
                    }
                }
            }
            this.pounch[this.top++] = new Tile(TileNumber.JOKER, Color.JOKER);
            this.pounch[this.top++] = new Tile(TileNumber.JOKER, Color.JOKER);
        }

        private void shuffleTiles() {
            for (int j = 0; j < 10000; j++)
            {
                for (int i = 0; i < this.numTiles; i++)
                {
                    Random rnd = new Random();
                    int index = rnd.Next(i, this.pounch.Length);
                    Tile tmpTile = this.pounch[i];
                    this.pounch[i] = this.pounch[index];
                    this.pounch[index] = tmpTile;
                }
            }
        }

        public Tile extract() {
            Debug.Assert(this.pounch.Length > 0);
            this.top--;
            return this.pounch[this.top];
        }        

        public bool isEmpty() {
            return this.top == 0;
        }
       
        public int count()
        {
            return this.top;
        }

        public void set(string state)
        {
            string[] chunks = state.Split(char.Parse(Message.VERTICAL_SLASH));
            this.numTiles = int.Parse(chunks[0]);
            this.top = int.Parse(chunks[1]);
            string[] tiles = chunks[2].Split(char.Parse(Message.SPACE));
            this.pounch = new Tile[numTiles];            
            for (int i = 0; i < this.top; i++) {
                this.pounch[i++] = Pounch.getTileByDescription(tiles[i]);
            }            
        }

        public override string ToString()
        {
            string result = "" + this.numTiles + Message.VERTICAL_SLASH + this.top + Message.VERTICAL_SLASH;
            foreach (Tile tile in this.pounch) {
                if (tile != null)
                {
                    result += tile.ToString() + Message.SPACE;
                } else
                {
                    result += Message.POUNCH_EMPTY_INPUT + Message.SPACE;
                }
            }
            return result;
        }
    }
}
