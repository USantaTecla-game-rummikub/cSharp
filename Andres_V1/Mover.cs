using System;
using System.Diagnostics;

namespace escuela_it
{
    public class Mover
    {
        private Table table;
        private Origin origin;
        private Destination destination;
        private Tile[] tiles;
        public Mover(Table table)
        {
            this.table = table;
        }
        public Mover from(int index)
        {
            this.origin = table.getTilesGroup(index);
            return this;
        }

        public Mover from(Origin origin){
            this.origin = origin;
            return this;
        }
        public Mover to(int index)
        {
            if(index !=-1)
                this.destination = table.getTilesGroup(index);
            else 
                this.destination = this.createNewGroup();
            return this;
        }
        private TableTilesGroup createNewGroup()
        {
            return table.createNewGroup();
        }
        public Mover these(Tile[] tiles){
            this.tiles = tiles;
            return this;
        }
        public void move(){
            Debug.Assert(origin!=null && table!= null && tiles!=null && tiles.Length > 0);
            if(!this.origin.contains(this.tiles)){
                Console.WriteLine("Error: Origin not contains tiles.");
                return;
            }
            this.destination.insert(tiles);
            this.origin.takeOut(tiles);                      
        }        
    }
}