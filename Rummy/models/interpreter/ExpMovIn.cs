using Microsoft.Build.Tasks;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rummy.models.interpreter
{
    public class ExpMovIn : Expression
    {
        private Group tGroup;
        private Group oGroup;
        private List<ExpTileGroup> tiles;

        public ExpMovIn(List<ExpTileGroup> tiles, Group oGroup, Group tGroup)
        {
            this.tiles = tiles;
            this.oGroup = oGroup;
            this.tGroup = tGroup;
        }

        public override void interpret(IPlayerCommand player)
        {
            foreach (ExpTileGroup tile in this.tiles)
            {
                tile.interpret(player);
                this.error = tile.getError();
                if (this.hasError())
                {
                    break;
                }
            }
            if (!this.hasError())
            {
                this.tGroup.interpret(player);
                this.error = tGroup.getError();                
            }
            if (!this.hasError())
            {
                this.move(player);
            }
        }

        private void move(IPlayerCommand player)
        {
            foreach (ExpTileGroup tile in this.tiles)
            {
                if (player.existsTileInGroup(tile.getDescription(), this.oGroup.toInt()))
                {
                    player.moveTileFromGroupToGroup(tile.getDescription(), this.oGroup.toInt(), this.tGroup.toInt());
                } else
                {
                    this.error = ErrorMessage.WRONG_TILE;
                    break;
                }
            }
        }
    }
}
