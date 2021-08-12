using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser
{
    public class OriginGroup: Parser
    {
        public OriginGroup(Input input): base(input)
        {

        }

        public override void parse()
        {            
            if (!int.TryParse(this.input.getToken(), out int result))
            {
                this.input.generateError(ErrorMessage.WRONG_GROUP);
            }
        }
    }
}
