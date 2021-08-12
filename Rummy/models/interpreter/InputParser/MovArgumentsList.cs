using Rummy.types;

namespace Rummy.models.interpreter.InputParser
{
    public class MovArgumentsList : Parser
    {
        private OriginGroup originGroup;
        private Tiles tiles;
        private TargetGroup targetGroup;
        private RestMovArgumentsList restMovArgumentsList;
        
        public MovArgumentsList(Input input) : base(input)
        {
            this.originGroup = new OriginGroup(input);
            this.tiles = new Tiles(input);
            this.targetGroup = new TargetGroup(input);
            this.restMovArgumentsList = new RestMovArgumentsList(input);
        }

        public override void parse()
        {
            this.testSpaceRequired();            
            if (this.input.isEqual("FROM")) {
                this.input.movePointer(4);
                this.testSpaceRequired();                
                this.originGroup.parse();
                this.tiles.parse();
                this.testSpaceOrComaRequired();
                this.targetGroup.parse();
                this.restMovArgumentsList.parse();
            } else
            {
                this.input.generateError(ErrorMessage.SUBCOMMAND_IN_NOT_RECOGNIZED);
            }
        }
    }
}