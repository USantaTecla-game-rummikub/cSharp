using Rummy.models;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers
{
    public abstract class ResumeController: AcceptorController
    {
        public ResumeController(Session session): base(session)
        {

        }

        public override void accept(ControllerVisitor controllerVisitor)
        {
            controllerVisitor.visit(this);
        }

        public void init()
        {
            this.setState(StateValue.INITIAL);
        }

        public void play()
        {
            this.setState(StateValue.IN_GAME);
        }

        public abstract void resume(bool newGame);        
    }
}
