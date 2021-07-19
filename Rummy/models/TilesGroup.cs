using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class TilesGroup
    {
        private const int SIZE_MIN_GROUP = 3;
        private const int SIZE_MAX_SERIE = 4;
        private const int SIZE_MAX_RUN = 13;
        private int id;
        private Tile[] tiles;
        private int size;
        
        protected TilesGroup() {
            this.tiles = new Tile[SIZE_MAX_RUN];
            this.size = 0;
        }       
       
        public void addTile(Tile tile) {
            if (this.tiles.Length < SIZE_MAX_RUN - 1) {
                int i = 0;
                for (i = 0; i < this.size; i++) {
                    if (tile.isNumberLessOrEqualThan(this.tiles[i])) {
                        for (int j = this.size + 1; j > i; j--) {
                            this.tiles[j] = this.tiles[j - 1];
                        }                        
                        break;
                    }
                }
                this.tiles[i] = tile;
                this.size++;
            }
        }       

        public bool isValid() {            
            return this.isRunValid() || this.isSerieValid();
        }

        private bool isRunValid() {
            bool validGroup = true;
            for (int i = 0; i < this.size; i++) {
                if (this.tiles[i].isNumberGreaterThan(this.tiles[i + 1])) {
                    validGroup = false;
                    break;
                }
            }
            return this.isSizeValidForRun() && validGroup;
        }

        private bool isSerieValid() {            
                bool validGroup = true;
                for (int i = 1; i < this.size; i++) {
                    for (int j = 0; j < i; j++) {
                        if (tiles[i].isNumberDistinctTo(tiles[j]) || tiles[i].isColorEqualsTo(tiles[j])) {
                            validGroup = false;
                            break;
                        }
                    }
                }
                return this.isSizeValidForSerie() && validGroup;            
        }
      
        private bool isSizeValidForSerie() {
            return this.size >= SIZE_MIN_GROUP && this.size <= SIZE_MAX_SERIE;
        }

        private bool isSizeValidForRun() {
            return this.size >= SIZE_MIN_GROUP && this.size <= SIZE_MAX_RUN;
        }
    }
}
