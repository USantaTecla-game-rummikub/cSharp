using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public abstract class Command {      
                       
        public abstract void interpret(string[] expression);
    }      
}
