using System;
using System.Diagnostics;

namespace escuela_it
{
    internal class Table
    {
        const int MAX_TILES_GROUP = 46;
        TilesGroup[] tilesGroup;
        int countTileGroup = 0;
        public Table()
        {
            tilesGroup = new TilesGroup[MAX_TILES_GROUP];
        }
        public void show()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.Write("Table: ");
            if(this.empty()){
                Console.WriteLine("(Empty)");                
            }
            else{
                Console.WriteLine("{0}",countTileGroup);
            }
        }

        public void moveTilesFromGroupToGroup()
        {
            TilesGroup origin = this.getGroup();
            if(origin==null){
                Console.WriteLine("Error....");
                return;
            }
            TilesGroup destination = this.getGroup();             
            if(destination==null){
                destination = this.createEmptyTileGroup();
                this.addTilesGroup(destination.readFrom(origin));
                return;
            }
            destination.readFrom(origin);
        }

        private void addTilesGroup(TilesGroup v)
        {
            Debug.Assert(v!=null);
            tilesGroup[countTileGroup] = v;
            countTileGroup++;
        }

        private TilesGroup createEmptyTileGroup()
        {
            return new Incomplete();
        }

        private TilesGroup getGroup()
        {
            throw new NotImplementedException();
        }

        private bool empty()
        {
            return countTileGroup == 0;
        }
    }
}