using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers
{
    public interface ControllerVisitor
    {
        void visit(StartController controller);
        void visit(PlayController controller);
        void visit(LoadController controller);
        void visit(ResumeController controller);
        void visit(SaveController controller);
    }
}
