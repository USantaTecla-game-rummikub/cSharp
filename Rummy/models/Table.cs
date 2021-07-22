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
        private List<TilesGroup> groups;        

        public Table() {                  
            this.pounch = new Pounch(TILES_TOTALES);
            this.groups = List<TilesGroup>();            
        }

        private List<T> List<T>()
        {
            throw new NotImplementedException();
        }

        public Tile extract() {
            return this.pounch.extract();
        }

        public void addTileToGroup(Tile tile, int groupIndex) {
            TilesGroup group = this.getGroup(groupIndex);
            if (group == null)
            {
                TilesGroup newGroup = new TilesGroup(groupIndex);
                newGroup.addTile(tile);
                this.groups.Add(newGroup);                                
            } else
            {
                group.addTile(tile);
            }
        }

        public void moveTileFromOriginGroupToTargetGroup(string tileTextDescription, int originGroup, int targetGroup)
        {
            Tile tile = this.getTile(tileTextDescription);
            TilesGroup oGroup = this.getGroup(originGroup);
            TilesGroup tGroup = this.getGroup(targetGroup);
            Tile originTile = oGroup.getTile(tile);
            tGroup.addTile(originTile);
            oGroup.removeTile(originTile);
        }

        public bool isValidGroups() {
            bool valids = true;
            foreach (TilesGroup group in this.groups) {
                if (!group.isValid()) {
                    valids = false;
                    break;
                }
            }
            return valids;
        }
        
        public void write() {

            this.pounch.write();
            Console.Write("Table: ");
            for (int i = 0; i < this.groups.Count; i++) {
                this.groups[i].write();
                Console.WriteLine();
                i++;
            }
            Console.WriteLine();
        }

        public bool isEmptyPounch()
        {
            return this.pounch.isEmpty();
        }

        public bool hasGroup(int indexGroup)
        {            
            foreach (TilesGroup group in this.groups)
            {
                if (group.hasIndex(indexGroup))
                {
                    return true;
                }
            }
            return false;
        }

        private TilesGroup getGroup(int indexGroup)
        {
            foreach (TilesGroup group in this.groups)
            {
                if (group.hasIndex(indexGroup))
                {
                    return group;
                }
            }
            return null;
        }

        public bool existTileInTable(string tileTextDescription)
        {            
            return this.getTile(tileTextDescription) != null;
        }

        private Tile getTile(string tileTextDescription)
        {
            Debug.Assert(tileTextDescription.Length >= 2 && tileTextDescription.Length <= 3);
            Tile tileFinded = null;
            foreach (TilesGroup group in this.groups)
            {
                tileFinded = group.getTile(tileTextDescription);
                if (tileFinded != null)
                {
                    break;
                }
            }
            return tileFinded;
        }
    }
}
