using Rummy.controllers;
using Rummy.types;
using Rummy.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class PutCommand : Command {
        private List<PutIn> lstExpIn;

        public PutCommand(List<PutIn> lstExpIn) {
            this.lstExpIn = lstExpIn;
        }

        public override void execute(PlayController playController) {                        
            List<List<string>> tiles = new List<List<string>>();
            foreach (PutIn expIn in lstExpIn) {
                expIn.execute(playController);
                if (expIn.hasError())
                {
                    this.error = expIn.getError();
                    break;
                } else
                {                    
                    tiles.Add(expIn.getTiles());
                }
            }    
            if (!this.hasError())
            {
                this.addTilesToGroup(playController, tiles);
            }
        }

        private void addTilesToGroup(PlayController playController, List<List<string>> tiles)
        {                                   
            if (playController.hasPlayed30FirstPoints() || playController.isAllowedToTileDown(tiles))
            {
                foreach (PutIn expIn in lstExpIn)
                {
                    expIn.addTilesToGroup(playController);
                    if (expIn.hasError())
                    {
                        this.error = expIn.getError();
                        break;
                    }
                }
            }
            else
            {
                this.error = ErrorMessage.WRONG_POINTS_OR_ILEGAL_MOVEMENT;
            }
        }
    }
}
