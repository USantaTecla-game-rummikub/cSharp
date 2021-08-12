using Rummy.controllers;
using Rummy.types;
using System;
using System.Collections.Generic;

namespace Rummy.models.interpreter
{
    public class PutIn: Command
    {
        private List<TileRack> tilesExp;
        private Group tgroup;

        public PutIn(List<TileRack> tilesExp, Group tgroup)
        {
            this.tilesExp = tilesExp;
            this.tgroup = tgroup;
        }

        public override void execute(PlayController playController)
        {
            foreach (TileRack tileExp in this.tilesExp) {
                tileExp.execute(playController);
                this.error = tileExp.getError();
                if (this.hasError()) {
                    break;
                }
            }
            if (!this.hasError()) {
                this.tgroup.execute(playController);
                this.error = tgroup.getError();
            }                  
        }

        public List<string> getTiles()
        {
            List<string> tiles = new List<string>();
            foreach (TileRack tileExp in this.tilesExp)
            {
                tiles.Add(tileExp.getDescription());
            }
            return tiles;
        }

        internal void addTilesToGroup(PlayController playController) {
            List<string> tiles = new List<string>();            
            foreach (TileRack tileExp in this.tilesExp)
            {
                tiles.Add(tileExp.getDescription());
            }
            if (this.tgroup.getGroup() == Group.NEW || playController.isValidAddTilesInGroup(tiles, int.Parse(this.tgroup.getGroup())))
            {
                playController.addTilesToGroup(tiles, this.tgroup.getGroup());
            } else
            {
                this.error = ErrorMessage.ILEGAL_MOVEMENT;
            }
        }              
    }
}