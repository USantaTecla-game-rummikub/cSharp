using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class Table
    {
        private const int MALLETS = 2;
        private const int TILES_ONE_COLOR = 13;
        private const int TILES_RED = TILES_ONE_COLOR * MALLETS;
        private const int TILES_YELLOW = TILES_ONE_COLOR * MALLETS;
        private const int TILES_BLACK = TILES_ONE_COLOR * MALLETS;
        private const int TILES_GREEN = TILES_ONE_COLOR * MALLETS;
        private const int TILES_WILDCARD = 2;
        private const int SIZE_MIN_GROUP = 3;
        public static int TILES_TOTALES = TILES_RED + TILES_YELLOW + TILES_BLACK + TILES_GREEN + TILES_WILDCARD;
        private int GROUPS_MAX = (Table.TILES_TOTALES - 1) / SIZE_MIN_GROUP;

        private Tile[] pounch;
        private int[] suffle;
        private int pounchTop;
        private TilesGroup[] groups;

        public Table() {
            this.createTiles();
            this.shuffleTiles();
            this.pounchTop = this.pounch.Length;
            this.groups = new TilesGroup[GROUPS_MAX];
        }

        private void createTiles() {
            this.pounch = new Tile[TILES_TOTALES];
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

        internal Tile getTileFromPounch() {
            return this.pounch[pounchTop--];
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

        public void write() {
            int i = 1;
            foreach (TilesGroup group in this.groups) {
                Console.WriteLine(group.ToString());
                i++;
            }
        }
    }
}
