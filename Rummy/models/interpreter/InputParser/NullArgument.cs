using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser
{
    public class NullArgument : Parser
    {
        public NullArgument(): base(new Input(""))
        {

        }

        public override void parse()
        {
            
        }
    }
}
