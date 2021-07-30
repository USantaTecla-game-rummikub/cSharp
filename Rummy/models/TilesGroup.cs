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
            Debug.Assert(tile != null);
            if (this.tiles.Count < SIZE_MAX_RUN - 1) {
                int index = -1;
                for (int i = 0; i < this.tiles.Count; i++) {
                    if (!tile.isJoker() && tile.isNumberLessThan(this.tiles[i])) {
                        index = i;
                        for (int j = this.tiles.Count; j > i; j--) {
                            this.tiles.Insert(j, this.tiles[j - 1]);
                        }                        
                        break;
                    }
                }
                Tile newTile = new Tile();
                newTile.clone(tile);
                if (index != -1) {
                    this.tiles.Insert(index, newTile);
                } else {
                    this.tiles.Add(newTile);
                }
            }
        }       

        public bool isValid() {
            return this.isSerieValid() || this.isRunValid();
        }

        public bool isSerieValid() {
            Debug.Assert(this.tiles != null);
            bool validGroup = true;
            for (int i = 1; i < this.tiles.Count; i++) {
                for (int j = 0; j < i; j++) {
                    if ((!this.tiles[i].isJoker() && !this.tiles[j].isJoker()) && (tiles[i].isNumberDistinctTo(tiles[j]) || tiles[i].isColorEqualsTo(tiles[j]))) {
                        validGroup = false;
                        break;
                    }
                }
                if (!validGroup) {
                    break;
                }
            } 
            return this.isSizeValidForSerie() && validGroup;
        }

        public bool isRunValid() {
            Debug.Assert(this.tiles != null);
            bool validGroup = true;
            for (int i = 0; i < this.tiles.Count - 1; i++) {
                if ((!this.anyHaveJokers(this.tiles[i], this.tiles[i + 1])) && (!this.hasDistanceAndColorOk(this.tiles[i], this.tiles[i + 1]))) {
                    validGroup = false;
                    break;
                }
            }
            return this.isSizeValidForRun() && validGroup;
        }

        private bool anyHaveJokers(Tile tile1, Tile tile2)
        {
            return (tile1.isJoker() || tile2.isJoker());
        }

        private bool hasDistanceAndColorOk(Tile tile1, Tile tile2)
        {
            return tile1.isNumberLessThan(tile2) && tile1.distanceIsOne(tile2) && tile1.isColorEqualsTo(tile2);
        }

        public bool isSizeValidForSerie()
        {
            return this.tiles.Count >= SIZE_MIN_GROUP && this.tiles.Count <= SIZE_MAX_SERIE;
        }

        public bool isSizeValidForRun()
        {
            return this.tiles.Count >= SIZE_MIN_GROUP && this.tiles.Count <= SIZE_MAX_RUN;
        }

        public int getPoints()
        {
            int points = 0;
            foreach (Tile tile in this.tiles)
            {
                points = points + (int)tile.getNumber();
            }
            return points;
        }
       
        internal void write()
        {
            Console.Write(this.id + ". ");
            foreach (Tile tile in this.tiles)
            {                
                tile.write(); Console.Write(" ");               
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

        public Tile getTile(string tileString)
        {
            Debug.Assert(tileString.Length >= 1 && tileString.Length <= 3);
            Tile tileFinded = null;
            foreach (Tile tile in this.tiles) {
                if (tile.isColorEqualsTo(tileString) && tile.isNumberEqualTo(tileString)) {
                    tileFinded = tile;
                    break;
                }
            }
            return tileFinded;
        }

        public Tile getTile(Tile tileToSearch) {            
            Tile tileFinded = null;
            foreach (Tile tile in this.tiles) {
                if (tile.isColorEqualsTo(tileToSearch) && tile.isNumberEqualTo(tileToSearch)) {
                    tileFinded = tile;
                    break;
                }
            }
            return tileFinded;
        }
    }
}
