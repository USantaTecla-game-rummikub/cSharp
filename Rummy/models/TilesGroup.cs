using Rummy.types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class TilesGroup
    {
        public const int SIZE_MIN_GROUP = 3;
        public const int SIZE_MAX_SERIE = 4;
        public const int SIZE_MAX_RUN = 13;
        public const int NEW = 0;
        private int id;
        private List<Tile> tiles;        
        
        public TilesGroup(int id) {
            this.id = id;
            this.tiles = new List<Tile>();            
        }       
       
        public void addTile(Tile tile) {
            if (this.tiles.Count < SIZE_MAX_RUN - 1) {
                int i = 0;
                for (i = 0; i < this.tiles.Count; i++) {
                    if (tile.isNumberLessOrEqualThan(this.tiles[i])) {
                        for (int j = this.tiles.Count + 1; j > i; j--) {
                            this.tiles[j] = this.tiles[j - 1];
                        }                        
                        break;
                    }
                }
                this.tiles[i].clone(tile);                
            }
        }       

        public bool isValid() {            
            return this.isRunValid() || this.isSerieValid();
        }

        public bool isRunValid() {
            bool validGroup = true;
            for (int i = 0; i < this.tiles.Count; i++) {
                if (this.tiles[i].isNumberGreaterThan(this.tiles[i + 1]) || !this.tiles[i].isJoker()) {
                    validGroup = false;
                    break;
                }
            }
            return this.isSizeValidForRun() && validGroup;
        }

        internal int getPoints()
        {
            int points = 0;
            foreach (Tile tile in this.tiles)
            {
                points += (int)tile.getNumber();
            }
            return points;
        }

        public bool isSerieValid() {
            bool validGroup = true;
            for (int i = 1; i < this.tiles.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tiles[i].isNumberDistinctTo(tiles[j]) || tiles[i].isColorEqualsTo(tiles[j]) || !this.tiles[i].isJoker())
                    {
                        validGroup = false;
                        break;
                    }
                }
            }
            return this.isSizeValidForSerie() && validGroup;          
        }

        internal void write()
        {
            Console.Write(this.id + ". ");
            foreach (Tile tile in this.tiles)
            {                
                tile.write();                
            }
        }

        public void removeTile(Tile originTile)
        {
            this.tiles.Remove(originTile);
        }

        public bool hasIndex(int indexGroup)
        {
            return this.id == indexGroup;
        }

        private bool isSizeValidForSerie() {
            return this.tiles.Count >= SIZE_MIN_GROUP && this.tiles.Count <= SIZE_MAX_SERIE;
        }

        private bool isSizeValidForRun() {
            return this.tiles.Count >= SIZE_MIN_GROUP && this.tiles.Count <= SIZE_MAX_RUN;
        }

        public Tile getTile(string tileString)
        {
            Debug.Assert(tileString.Length >= 2 && tileString.Length <= 3);
            Tile tileFinded = null;
            foreach (Tile tile in this.tiles) {
                if (tile.isColorEqualsTo(tileString) && tile.isNumberEqualTo(tileString)) {
                    tileFinded = tile;
                    break;
                }
            }
            return tileFinded;
        }

        public Tile getTile(Tile tileToSearch)
        {            
            Tile tileFinded = null;
            foreach (Tile tile in this.tiles)
            {
                if (tile.isColorEqualsTo(tileToSearch) && tile.isNumberEqualTo(tileToSearch))
                {
                    tileFinded = tile;
                    break;
                }
            }
            return tileFinded;
        }
    }
}
