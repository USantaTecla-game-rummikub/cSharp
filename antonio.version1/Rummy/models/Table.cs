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
        private const int TILES_YELLOW = TILES_RED;
        private const int TILES_BLACK = TILES_RED;
        private const int TILES_GREEN = TILES_RED;
        private const int TILES_WILDCARD = 2;
        private const int SIZE_MIN_GROUP = 3;
        public static int TILES_TOTALES = TILES_RED + TILES_YELLOW + TILES_BLACK + TILES_GREEN + TILES_WILDCARD;
        private int GROUPS_MAX = (Table.TILES_TOTALES - 1) / SIZE_MIN_GROUP;

        private Pounch pounch;
        private TilesGroup[] groups;

        public Table() {
            this.pounch = new Pounch(TILES_TOTALES);            
            this.groups = new TilesGroup[GROUPS_MAX];            
        }
       
        internal Tile extract() {
            return this.pounch.extract();
        }

        public void addTileToGroup(Tile tile, int groupIndex)
        {
            if (this.isValidInsertion(tile, groupIndex)) {
               this.groups[groupIndex].addTile(tile);
            }
        }

        public bool isValidInsertion(Tile tile, int groupIndex)
        {
            return this.groups[groupIndex].isValidInsertion(tile);
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
