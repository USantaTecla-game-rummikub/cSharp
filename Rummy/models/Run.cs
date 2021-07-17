using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    class Run : TilesGroup
    {
        protected const int SIZE_MAX_GROUP = 13;

        public Run(): base() {
            this.tiles = new Tile[SIZE_MAX_GROUP];
        }

        public override void addTile(Tile tile) {
            Debug.Assert(this.isValidInsertion(tile));
            int posToInsert = -1;
            for (int i = 0; i < this.size; i++) {
                if (tile.isNumberLessThan(this.tiles[i])) {
                    posToInsert = i;
                    break;
                }
            }
            if (posToInsert >= 0) {
                for (int i = this.size; i > posToInsert; i--) {
                    this.tiles[i] = this.tiles[i - 1];
                }
                this.tiles[posToInsert] = tile;
                this.size++;
            }
            else {
                this.tiles[this.size++] = tile;
            }
        }       
      
        public override bool isValidInsertion(Tile tile) {
           return this.size < SIZE_MAX_GROUP && (this.size == 0 || tile.isColorEqualsTo(this.tiles[0]));            
        }

        public override bool isValid() {
            bool validGroup = true;
            for (int i = 0; i < this.size; i++) {
               if (this.tiles[i].isNumberGreaterThan(this.tiles[i + 1])) {
                    validGroup = false;
                    break;
               }
            }
            return this.isSizeValid() && validGroup;
        }

        public override bool isSizeValid()
        {
            return this.size >= SIZE_MIN_GROUP && this.size <= SIZE_MAX_GROUP;
        }
    }
}
