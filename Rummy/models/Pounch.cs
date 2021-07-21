using Rummy.types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class Pounch
    {
        private Tile[] pounch;
        private int top;

        public Pounch(int numTiles) {
            this.top = 0;
            this.createTiles(numTiles);
            this.shuffleTiles();
        }

        private void createTiles(int numTiles) {
            this.pounch = new Tile[numTiles];            
            Array numbers = Enum.GetValues(typeof(TileNumber));
            Array colors = Enum.GetValues(typeof(Color));
            for (int i = 0; i < 2; i++)
            {
                foreach (TileNumber number in numbers)
                {
                    if (number != TileNumber.J)
                    {
                        foreach (Color color in colors)
                        {
                            if (color != Color.J)
                            {
                                Tile tile = new Tile(number, color);
                                this.pounch[this.top++] = tile;                                
                            }
                        }
                    }
                }
            }
            this.pounch[this.top++] = new Tile(TileNumber.J, Color.J);
            this.pounch[this.top++] = new Tile(TileNumber.J, Color.J);
        }

        private void shuffleTiles() {
            int numIterations = 10000;
            for (int i = 0; i < numIterations; i++) {
                Random rnd = new Random();
                int indexTile1 = rnd.Next(0, this.pounch.Length);
                int indexTile2 = rnd.Next(0, this.pounch.Length);
                Tile aux = this.pounch[indexTile2];
                this.pounch[indexTile2] = this.pounch[indexTile1];
                this.pounch[indexTile1] = aux;
            }
        }

        public Tile extract() {
            Debug.Assert(this.pounch.Length > 0);
            return this.pounch[this.top - 1];
        }        

        public bool isEmpty() {
            return this.top == 0;
        }

        public void write()
        {
            Console.WriteLine(Message.POUNCH + this.top);
            foreach (Tile tile in this.pounch) {
                tile.write();
                Console.Write(" ");
            }
        }
    }
}
