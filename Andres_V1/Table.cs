using System;
using System.Diagnostics;

namespace escuela_it
{
    public class Table
    {
        const int MAX_TILES_GROUP = 46;
        TableTilesGroup[] tilesGroup;
        int countTileGroup = 0;
        public Table()
        {
            tilesGroup = new TableTilesGroup[MAX_TILES_GROUP];            
        }

        public TableTilesGroup getTilesGroup(int index)
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

        public TableTilesGroup createNewGroup()
        {
            return new TableTilesGroup(new Checker[]{new RunChekcer(), new SerieChecker()});
        }

        public void clean()
        {
            throw new NotImplementedException();
        }
    }
}