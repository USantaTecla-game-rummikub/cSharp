using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.controllers;

namespace Rummy.models.interpreter.InputParser.Commands
{
    public class Mov : Command
    {
        private int originGroup;        

        public Mov()
        {
            this._params = new List<Params>();
        }
       
        public void setOriginGroup(int index)
        {
            this.originGroup = index;
        }

        public override void execute(PlayController playController)
        {
            throw new NotImplementedException();
        }
    }
}
