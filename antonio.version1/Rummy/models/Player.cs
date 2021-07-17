using Rummy.types;
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
            this.table = table;
            this.rack = new Tile[Table.TILES_TOTALES];            
            this.topRack = 0;
        }

        internal void extractTile()
        {
           this.rack[topRack++] = this.table.extract();
        }

        internal bool isWinner()
        {
            throw new NotImplementedException();
        }

        internal void write()
        {
            throw new NotImplementedException();
        }

        internal void executeAction()
        {
            Console.Write(Message.REQUEST_ACTION);
            string respond = Console.ReadLine();
            // new CommandInterpreter(respond).;
        }

        internal bool isResume()
        {
            throw new NotImplementedException();
        }

        internal void writeCongratulations()
        {
            throw new NotImplementedException();
        }

        internal bool isEnd()
        {
            throw new NotImplementedException();
        }
    }
}