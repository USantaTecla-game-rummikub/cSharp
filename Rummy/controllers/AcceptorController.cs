using Rummy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers
{
    public abstract class AcceptorController: Controller
    {
        public AcceptorController(Session session): base(session)
        {
            
        }
        public abstract void accept(ControllerVisitor controllerVisitor);
    }
}
