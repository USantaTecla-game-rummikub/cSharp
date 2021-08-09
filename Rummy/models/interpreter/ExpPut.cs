using Rummy.types;
using Rummy.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class ExpPut : Expression {
        private List<ExpPutIn> lstExpIn;

        public ExpPut(List<ExpPutIn> lstExpIn) {
            this.lstExpIn = lstExpIn;
        }

        public override void interpret(IPlayerCommand player) {

            List<List<string>> tiles = new List<List<string>>();
            foreach (ExpPutIn expIn in lstExpIn) {
                expIn.interpret(player);
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
                this.addTilesToGroup(player, tiles);
            }
        }

        private void addTilesToGroup(IPlayerCommand player, List<List<string>> tiles)
        {                                   
            if (player.isAllowedToTileDown(tiles))
            {
                foreach (ExpPutIn expIn in lstExpIn)
                {
                    expIn.addTilesToGroup(player);
                    if (expIn.hasError())
                    {
                        this.error = expIn.getError();
                        break;
                    }
                }
            }
            else
            {
                this.error = Message.WRONG_POINTS;
            }
        }
    }
}
