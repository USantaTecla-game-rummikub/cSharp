using Microsoft.Build.Tasks;
using Rummy.controllers;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rummy.models.interpreter
{
    public class MovIn : Command
    {
        private Group tGroup;
        private Group oGroup;
        private List<TileGroup> tiles;

        public MovIn(List<TileGroup> tiles, Group oGroup, Group tGroup)
        {
            this.tiles = tiles;
            this.oGroup = oGroup;
            this.tGroup = tGroup;
        }

        public override void execute(PlayController playController)
        {
            foreach (TileGroup tile in this.tiles)
            {
                tile.execute(playController);
                this.error = tile.getError();
                if (this.hasError())
                {
                    break;
                }
            }
            if (!this.hasError())
            {
                this.tGroup.execute(playController);
                this.error = tGroup.getError();                
            }
            if (!this.hasError())
            {
                this.move(playController);
            }
        }

        private void move(PlayController playController)
        {
            foreach (TileGroup tile in this.tiles)
            {
                if (playController.existsTileInGroup(tile.getDescription(), this.oGroup.toInt()))
                {
                    playController.moveTileFromGroupToGroup(tile.getDescription(), this.oGroup.toInt(), this.tGroup.toInt());
                } else
                {
                    this.error = ErrorMessage.WRONG_TILE;
                    break;
                }
            }
        }
    }
}
