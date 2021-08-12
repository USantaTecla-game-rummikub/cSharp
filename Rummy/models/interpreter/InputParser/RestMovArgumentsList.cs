namespace Rummy.models.interpreter.InputParser
{
    public class RestMovArgumentsList: Parser
    {
        private MovArgumentsList movArgumentsList;

        public RestMovArgumentsList(Input input): base(input)
        {

        }

        public override void parse()
        {
            this.input.jumpSpaces();
            if (this.input.getToken() == ",")
            {
                this.movArgumentsList = new MovArgumentsList(this.input);
                this.movArgumentsList.parse();
            }
        }
    }
}