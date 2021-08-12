using Rummy.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser.Commands
{
    public class Put : Command
    {        
        public Put()
        {
            this._params = new List<Params>();
        }      

        public override void execute(PlayController playController)
        {
            foreach (Params param in this._params) {
                // playController.
            }
        }
    }
}
