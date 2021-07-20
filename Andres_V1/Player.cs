using System;

namespace escuela_it
{
    public class Player : Group
    {
        const int MAX_SIZE_TILES = 104;
        private string name; 
        
        public Player(string v) :base(new Tile[MAX_SIZE_TILES])
        {
            this.name = v;
        }       

        public bool isWinner()
        {
            return this.tilesCount==0;
        }

        public void show()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Player {0}: ", this.name);
            foreach(var t in tiles){
                t.show();
            }
        }
    }
}