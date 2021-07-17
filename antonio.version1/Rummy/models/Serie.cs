using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    class Serie : TilesGroup
    {
        protected const int SIZE_MAX_GROUP = 4;

        public Serie() : base() {
            this.tiles = new Tile[SIZE_MAX_GROUP];
        }

        public override void addTile(Tile tile) {
            Debug.Assert(this.isValidInsertion(tile));
            this.tiles[this.size++] = tile;
        }

        public override bool isValid() {
            if (this.size > 0) {
                bool validGroup = true;
                Tile tileRef = tiles[0];
                for (int i = 1; i < this.size; i++) {
                    if (tiles[i].isNumberDistinctTo(tileRef) || tiles[i].isColorEqualsTo(tileRef)) {
                        validGroup = false;
                        break;
                    }
                    tileRef = tiles[i];
                }
                return this.isSizeValid() && validGroup;
            }
            return true;
        }

        public override bool isValidInsertion(Tile tile) {             
            bool colorOk = true;
            foreach (Tile t in this.tiles) {
               if (t.isColorEqualsTo(tile)) {
                    colorOk = false;
                    break;
               }
            }
            return this.size < SIZE_MAX_GROUP && colorOk;
        }

        public override bool isSizeValid()
        {
            return this.size >= SIZE_MIN_GROUP && this.size <= SIZE_MAX_GROUP;
        }
    }
}
