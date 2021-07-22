using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public interface IPlayerCommand {
        void addTileToGroup(string tileString, int groupIndex);
        void addTileToGroup(string tileString);
        bool existGroup(string targetGroup);
        bool existTileInRack(string tileDescription);

        bool existTileInTable(string tileDescription);

        void moveTileFromGroupToGroup(string tileString, int origin, int target);
        bool canEndTurn();

        bool isAllowedToTileDown(List<string> tiles);
    }
}
