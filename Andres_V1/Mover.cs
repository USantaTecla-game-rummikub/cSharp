using System;
using System.Diagnostics;

namespace escuela_it
{
    public class Mover
    {
        private Table table;
        private IOrigin origen;
        private TilesGroup destination;
        private Tile[] tiles;
        public Mover(Table table)
        {
            this.table = table;
        }
        public Mover from(int index)
        {
            this.origen = table.getTilesGroup(index);
            return this;
        }

        public Mover from(Player p){
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
        private TilesGroup createNewGroup()
        {
            return new TilesGroup(new IChecker[]{new RunChekcer(), new SerieChecker()});
        }
        public Mover these(Tile[] tiles){
            this.tiles = tiles;
            return this;
        }
        public void move(){
            Debug.Assert(origen!=null && table!= null && tiles!=null && tiles.Length > 0);
            if(!this.origen.contains(this.tiles)){
                Console.WriteLine("Error: Origin not contains tiles.");
                return;
            }
            this.destination.insert(tiles);
            this.origen.takeOut(tiles);                      
        }        
    }
}