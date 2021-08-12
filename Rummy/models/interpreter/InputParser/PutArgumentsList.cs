using System;
using Rummy.models.interpreter.InputParser.Commands;
using Rummy.types;

namespace Rummy.models.interpreter.InputParser
{
    public class PutArgumentsList: Parser
    {
        private Tiles rackTiles;
        private TargetGroup targetGroup;
        private RestPutArgumentsList restPutArgumentsList;        

        public PutArgumentsList(Input input): base(input)
        {
            this.rackTiles = new Tiles(input);
            this.targetGroup = new TargetGroup(input);
            this.restPutArgumentsList = new RestPutArgumentsList(input);            
        }

        public override void parse()
        {            
            this.rackTiles.parse();
            this.testSpaceOrComaRequired();
            this.targetGroup.parse();            
            this.restPutArgumentsList.parse();           
        }       
    }
}