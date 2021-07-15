using System;

namespace Rummy.models
{
    public class Player
    {
        private Tile[] rack;
        private int topRack;
        private Table table;

        public Player(Table table)
        {
            this.rack = new Tile[Table.TILES_TOTALES];
            this.table = table;
            this.topRack = 0;
        }

        internal void takeTile()
        {
            this.rack[topRack++] = this.table.getTileFromPounch();
        }

        internal bool isWinner()
        {
            throw new NotImplementedException();
        }

        internal void write()
        {
            throw new NotImplementedException();
        }
    }
}