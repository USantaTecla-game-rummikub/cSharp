﻿using Rummy.types;
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
            this.groups = new List<TilesGroup>();            
        }
       
        public Tile extract() {
            return this.pounch.extract();
        }

        public void addTileToGroup(Tile tile, int groupIndex) {            
            TilesGroup group = this.getGroup(groupIndex);
            Tile newTile = new Tile();
            newTile.clone(tile);
            group.addTile(newTile);           
        }

        public void addTilesToGroup(List<Tile> tiles, int groupIndex)
        {
            if (groupIndex == TilesGroup.NEW) {
                groupIndex = this.groups.Count + 1;
                TilesGroup newGroup = new TilesGroup(this.groups.Count + 1);
                foreach (Tile tile in tiles) {
                    newGroup.addTile(tile);
                }
                this.groups.Add(newGroup);
            }
            else
            {
                foreach (Tile tile in tiles)
                {
                    this.addTileToGroup(tile, groupIndex);
                }                
            }
        }

        public bool isValidAddTilesInGroup(List<Tile> tiles, int groupIndex)
        {
            TilesGroup group = this.getGroup(groupIndex).clone();
            foreach (Tile tile in tiles)
            {
                group.addTile(tile);
            }
            return group.isValid();
        }

        public void moveTileFromOriginGroupToTargetGroup(string tileTextDescription, int originGroup, int targetGroup)
        {
            Tile tile = this.getTile(tileTextDescription);
            TilesGroup oGroup = this.getGroup(originGroup);
            TilesGroup tGroup = this.getGroup(targetGroup);
            Tile originTile = oGroup.getTile(tile);
            this.addTilesToGroup(new List<Tile>() { tile }, targetGroup);         
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
            Console.WriteLine("Table: ");
            foreach (TilesGroup group in this.groups) {
                group.write();                
                Console.WriteLine();                
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
            Debug.Assert(tileTextDescription.Length >= 1 && tileTextDescription.Length <= 3);
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

        public string tilesGroupToString()
        {
            string result = "";
            foreach (TilesGroup group in this.groups)
            {
                result += group.ToString();
            }
            return result;
        }

        public string pounchToString()
        {
            return this.pounch.ToString();
        }

        public void set(string groupString, string pounch)
        {
            string[] chunksStringGroups = groupString.Split('\n');
            this.groups = new List<TilesGroup>();
            foreach (string group in chunksStringGroups)
            {
                if (!String.IsNullOrEmpty(group))
                {
                    TilesGroup tilesGroup = new TilesGroup(TilesGroup.NEW);
                    tilesGroup.set(group);
                }
            }
            this.pounch.set(pounch);
        }

        public bool existsTileInGroup(string tileDescription, int group)
        {
            TilesGroup tilesGroup = this.getGroup(group);
            if (tilesGroup != null)
            {
                return tilesGroup.getTile(tileDescription) != null;
            } else
            {
                return false;
            }
        }
    }
}
