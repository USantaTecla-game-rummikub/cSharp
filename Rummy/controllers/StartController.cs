using Rummy.models;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers
{
    public abstract class StartController : AcceptorController
    {
        public StartController(Session session): base(session)
        {

        }

        public override void accept(ControllerVisitor controllerVisitor)
        {
            controllerVisitor.visit(this);
        }

        public abstract void play(int numberPlayers);

        public abstract bool isNumberPlayersValid(int numPlayers);

        public void exit()
        {
            this.setState(StateValue.EXIT);
        }

        public void load()
        {
            this.setState(StateValue.LOAD);
        }
    }
}
