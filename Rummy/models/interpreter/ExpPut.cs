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
            foreach (ExpPutIn expIn in lstExpIn) {
                expIn.interpret(player);
                if (expIn.hasError())
                {
                    this.error = expIn.getError();
                    break;
                }
            }           
        }
    }
}
