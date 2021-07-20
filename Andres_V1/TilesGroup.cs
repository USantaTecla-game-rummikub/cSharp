using System;
using System.Diagnostics;

namespace escuela_it
{
    public class TableTilesGroup : Group
    {
        
        private Checker[] checkers;        
        private const int SIZE_MAX = 13;
        public TableTilesGroup(Checker[] checkers) : base(new Tile[SIZE_MAX])
        {
            this.tilesCount = 0;
            this.checkers = checkers;
        }        

        public bool isEmpty()
        {
            return tilesCount == 0;
        }

        public bool isValidForPlay(){
            foreach(Checker checker in checkers){
                if(checker.check(tiles))
                    return true;
            }
            return false;
        } 
    }
}