using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public interface IPlayerCommand {
        void addTilesToGroup(List<string> tileString, string groupIndex);        
        bool existGroup(string targetGroup);
        bool existTileInRack(string tileDescription);

        bool existTileInTable(string tileDescription);

        void moveTileFromGroupToGroup(string tileString, int origin, int target);
        
        bool isAllowedToTileDown(List<string> tiles);

        void finishTurn();
    }
}
