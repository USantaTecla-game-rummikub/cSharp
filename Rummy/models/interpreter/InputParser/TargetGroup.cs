using Rummy.types;
using System;

namespace Rummy.models.interpreter.InputParser
{
    internal class TargetGroup : Parser
    {

        public TargetGroup(Input input) : base(input)
        {

        }

        public override void parse()
        {            
            if (this.input.isEqual("IN"))
            {                                
                this.input.next();
                this.input.next();
                this.testSpaceRequired();                
                if (!int.TryParse(this.input.getToken(), out int result))
                {
                    this.input.generateError(ErrorMessage.WRONG_GROUP);
                }                
            }
        }
    }
}
