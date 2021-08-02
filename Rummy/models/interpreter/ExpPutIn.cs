using Rummy.types;
using System;
using System.Collections.Generic;

namespace Rummy.models.interpreter
{
    public class ExpPutIn: Expression
    {
        private List<ExpTileRack> tilesExp;
        private Group tgroup;

        public ExpPutIn(List<ExpTileRack> tilesExp, Group tgroup)
        {
            this.tilesExp = tilesExp;
            this.tgroup = tgroup;
        }

        public override void interpret(IPlayerCommand player)
        {
            foreach (ExpTileRack tileExp in this.tilesExp) {
                tileExp.interpret(player);
                this.error = tileExp.getError();
                if (this.hasError()) {
                    break;
                }
            }
            if (!this.hasError()) {
                this.tgroup.interpret(player);
                this.error = tgroup.getError();
            }                  
        }

        public List<string> getTiles()
        {
            List<string> tiles = new List<string>();
            foreach (ExpTileRack tileExp in this.tilesExp)
            {
                tiles.Add(tileExp.getDescription());
            }
            return tiles;
        }

        internal void addTilesToGroup(IPlayerCommand player) {
            List<string> tiles = new List<string>();            
            foreach (ExpTileRack tileExp in this.tilesExp)
            {
                tiles.Add(tileExp.getDescription());
            }
            if (this.tgroup.getGroup() == Group.NEW || player.isValidAddTilesInGroup(tiles, int.Parse(this.tgroup.getGroup())))
            {
                player.addTilesToGroup(tiles, this.tgroup.getGroup());
            } else
            {
                this.error = ErrorMessage.WRONG_GROUP;
            }
        }              
    }
}