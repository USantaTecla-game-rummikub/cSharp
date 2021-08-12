using System;

namespace Rummy.models.interpreter.InputParser
{
    internal class RestPutArgumentsList: Parser
    {
        private PutArgumentsList putArgumentsList;

        public RestPutArgumentsList(Input input): base(input)
        {
            
        }

        public override void parse()
        {
            this.input.jumpSpaces();
            if (this.input.getToken() == ",")
            {
                this.putArgumentsList = new PutArgumentsList(this.input);
                this.putArgumentsList.parse();
            }
        }
    }
}