using System;
using System.Diagnostics;

namespace escuela_it
{
    public abstract class Tile : TileAbstract
    {
        int number;
        Color color;
        public Tile(int number, Color color)
        {
            Debug.Assert(number>0 && number<=13);
            this.number = number;
            this.color = color;
        }

        public Tile(){

        }

        public bool isEqual(Tile tile)
        {
            throw new NotImplementedException();
        }

        public void show()
        {
            throw new NotImplementedException();
        }
    }
}