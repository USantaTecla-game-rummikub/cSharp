using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class ExpUndo : Expression
    {
        public override void interpret(IPlayerCommand player)
        {
            player.undo();
        }
    }
}
