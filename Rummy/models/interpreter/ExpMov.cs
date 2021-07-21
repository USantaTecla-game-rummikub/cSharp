using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class ExpMov : Expression {
        private List<ExpMovIn> lstExpMovIn;

        public ExpMov(List<ExpMovIn> lstExpIn) {
            this.lstExpMovIn = lstExpIn;
        }

        public override void interpret(IPlayerCommand player) {
            foreach (ExpMovIn expIn in lstExpMovIn) {
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
