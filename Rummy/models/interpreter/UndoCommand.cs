using Rummy.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class UndoCommand : Command
    {
        public override void execute(PlayController playController)
        {
            playController.undo();
        }
    }
}
