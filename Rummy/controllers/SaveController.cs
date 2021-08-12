using Rummy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers
{
    public abstract class SaveController : AcceptorController
    {        
        public SaveController(Session session): base(session)
        {
            
        }

        public override void accept(ControllerVisitor controllerVisitor)
        {
            controllerVisitor.visit(this);
        }

        public abstract void save(string name);

        public abstract void continuePlay();

        internal abstract string[] getSavedPreviousFiles();

        internal abstract bool hasCommandError();        

        internal abstract string getCommandError();
    }
}
