using Rummy.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public abstract class Command
    {
        protected string error;
        public abstract void execute(PlayController playController);
        public string getError()
        {
            return this.error;
        }
        public bool hasError()
        {
            return this.error != null && this.error != "";
        }
    }
}
