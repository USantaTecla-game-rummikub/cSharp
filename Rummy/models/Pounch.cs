using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class Pounch
    {
        private Tile[] pounch;        

        public Pounch(int numTiles)
        {
            this.createTiles(numTiles);
            this.shuffleTiles();
        }

        private void createTiles(int numTiles)
        {
            this.pounch = new Tile[numTiles];
            int i = 0;
            Array numbers = Enum.GetValues(typeof(TileNumber));
            Array colors = Enum.GetValues(typeof(Color));
            foreach (TileNumber number in numbers) {
                foreach (Color color in colors) {
                    Tile tile = new Tile(number, color);
                    this.pounch[i] = tile;
                    i = i + 1;
                }
            }            
        }

        private void shuffleTiles()
        {
            int numIterations = 10000;
            for (int i = 0; i < numIterations; i++)
            {
                Random rnd = new Random();
                int indexTile1 = rnd.Next(0, this.pounch.Length);
                int indexTile2 = rnd.Next(0, this.pounch.Length);
                Tile aux = this.pounch[indexTile2];
                this.pounch[indexTile2] = this.pounch[indexTile1];
                this.pounch[indexTile1] = aux;
            }
        }

        public Tile extract()
        {
            return this.pounch[this.pounch.Length - 1];
        }
    }
}
