using Rummy.types;
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

            List<string> tiles = new List<string>();

            foreach (ExpPutIn expIn in lstExpIn) {
                expIn.interpret(player);
                if (expIn.hasError())
                {
                    this.error = expIn.getError();
                    break;
                } else
                {
                    tiles.AddRange(expIn.getTiles());
                }
            }    
            if (!this.hasError())
            {
                this.addTilesToGroup(player, tiles);
            }
        }

        private void addTilesToGroup(IPlayerCommand player, List<string> tiles)
        {                       
            if (player.isAllowedToTileDown(tiles))
            {
                foreach (ExpPutIn expIn in lstExpIn)
                {
                    expIn.addTilesToGroup(player);
                }
            }
            else
            {
                this.error = Message.WRONG_POINTS;
            }
        }
    }
}
