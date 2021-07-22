using Rummy.types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
                [Color.BLUE] = "B",
                [Color.GREEN] = "G",
                [Color.RED] = "R",
                [Color.YELLOW] = "Y",
                [Color.JOKER] = ""
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
            int numIterations = 10000;
            //  for (int i = 0; i < numIterations; i++) {
            for (int i = 0; i < this.numTiles; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(i, this.pounch.Length);
               // int indexTile2 = rnd.Next(i + 1, this.pounch.Length);
                Tile tmpTile = this.pounch[i];
                this.pounch[i] = this.pounch[index];
                this.pounch[index] = tmpTile;
            }
          //  }
        }

        public Tile extract() {
            Debug.Assert(this.pounch.Length > 0);
            this.top--;
            return this.pounch[this.top];
        }        

        public bool isEmpty() {
            return this.top == 0;
        }

        public void write()
        {
            Console.WriteLine(Message.POUNCH + this.top);
         /*   foreach (Tile tile in this.pounch) {
                tile.write();
                Console.Write(" ");
            } */
            Console.WriteLine();
        }
    }
}
