using System.Collections.Generic;

namespace Rummy.models.interpreter.InputParser.Commands
{
    public class Params
    {
        private List<string> tiles;
        private int targetGroup;

        public Params()
        {
            this.tiles = new List<string>();
            this.targetGroup = TilesGroup.NEW;
        }

        public void addTile(string tile)
        {
            this.tiles.Add(tile);
        }

        public void setGroupIndex(int index)
        {
            this.targetGroup = index;
        }
    }
}