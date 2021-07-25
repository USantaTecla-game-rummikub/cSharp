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
                int index = -1;
                for (int i = 0; i < this.tiles.Count; i++) {
                    if (tile.isNumberLessOrEqualThan(this.tiles[i])) {
                        index = i;
                        for (int j = this.tiles.Count; j > i; j--) {
                            this.tiles.Insert(j, this.tiles[j - 1]);
                        }                        
                        break;
                    }
                }
                Tile newTile = new Tile();
                newTile.clone(tile);
                if (index != -1)
                {
                    this.tiles.Insert(index, newTile);
                } else
                {
                    this.tiles.Add(newTile);
                }
            }
        }       

        public bool isValid() {
            return this.isSerieValid() || this.isRunValid();
        }

        public bool isSerieValid() {
            Debug.Assert(this.tiles != null && this.tiles.Count >= SIZE_MIN_GROUP);
            bool validGroup = true;
            for (int i = 1; i < this.tiles.Count; i++)
            {
               if (tiles[i].isNumberDistinctTo(tiles[i - 1])) {
                    validGroup = false;
                }
            }
          /*  for (int i = 1; i < this.tiles.Count; i++) {
                for (int j = 0; j < i; j++) {
                    if (!this.tiles[i].isJoker() && (tiles[i].isNumberDistinctTo(tiles[j]) || tiles[i].isColorEqualsTo(tiles[j]))) {
                        validGroup = false;
                        break;
                    }
                }
                if (!validGroup) {
                    break;
                }
            } */
            return this.isSizeValidForSerie() && validGroup;
        }

        public bool isRunValid() {
            bool validGroup = true;
            for (int i = 0; i < this.tiles.Count - 1; i++) {
                if (!this.tiles[i].isJoker() && (this.tiles[i].isNumberGreaterThan(this.tiles[i + 1]) || this.tiles[i].isColorDistinct(this.tiles[i + 1]))) {
                    validGroup = false;
                    break;
                }
            }
            return this.isSizeValidForRun() && validGroup;
        }


        public bool isSizeValidForSerie()
        {
            return this.tiles.Count >= SIZE_MIN_GROUP && this.tiles.Count <= SIZE_MAX_SERIE;
        }

        public bool isSizeValidForRun()
        {
            return this.tiles.Count >= SIZE_MIN_GROUP && this.tiles.Count <= SIZE_MAX_RUN;
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
