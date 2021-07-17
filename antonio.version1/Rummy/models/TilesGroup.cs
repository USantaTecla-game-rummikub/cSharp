using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public abstract class TilesGroup
    {
        protected const int SIZE_MIN_GROUP = 3;        
        private int id;
        protected Tile[] tiles;
        protected int size;

        protected TilesGroup()
        {            
            this.size = 0;
        }
        
        public bool isAccepted(Tile tile) {            
            return this.size == 0 || this.isValidInsertion(tile);
        }

        public abstract bool isSizeValid();

        public abstract void addTile(Tile tile);
        public abstract bool isValidInsertion(Tile tile);

        public abstract bool isValid();
        
    }
}
