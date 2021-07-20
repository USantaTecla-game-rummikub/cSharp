using System;
using System.Diagnostics;

namespace escuela_it
{
    public class Table
    {
        const int MAX_TILES_GROUP = 46;
        TilesGroup[] tilesGroup;
        int countTileGroup = 0;
        public Table()
        {
            tilesGroup = new TilesGroup[MAX_TILES_GROUP];
            
        }

        public TilesGroup getTilesGroup(int index)
        {
            throw new NotImplementedException();
        }

        public void show()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.Write("Table: ");
            if (this.empty())
            {
                Console.WriteLine("(Empty)");
            }
            else
            {
                Console.WriteLine("{0}", countTileGroup);
            }
        }       
     
        private bool empty()
        {
            return countTileGroup == 0;
        }

        internal void delete(TilesGroup origen)
        {
            throw new NotImplementedException();
        }

        internal void clean()
        {
            throw new NotImplementedException();
        }
    }
}