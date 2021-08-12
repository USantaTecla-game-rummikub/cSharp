using Rummy.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser.Commands
{
    public abstract class Command
    {
        protected List<Params> _params;

        public abstract void execute(PlayController playController);

        public void addParams(Params paramsGroup)
        {
            this._params.Add(paramsGroup);
        }
    }
}
