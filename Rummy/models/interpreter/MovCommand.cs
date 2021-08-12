using Rummy.controllers;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class MovCommand : Command {
        private List<MovIn> lstExpMovIn;

        public MovCommand(List<MovIn> lstExpIn) {
            this.lstExpMovIn = lstExpIn;
        }

        public override void execute(PlayController playController) {
            if (playController.hasPlayed30FirstPoints())
            {
                foreach (MovIn expIn in lstExpMovIn)
                {
                    expIn.execute(playController);
                    if (expIn.hasError())
                    {
                        this.error = expIn.getError();
                        break;
                    }
                }
            } else
            {
                this.error = ErrorMessage.WRONG_POINTS;
            }
        }
    }
}
