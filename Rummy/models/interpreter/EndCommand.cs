using Rummy.controllers;
using Rummy.types;

namespace Rummy.models.interpreter
{
    public class EndCommand: Command
    {
        public EndCommand()
        {
        }

        public override void execute(PlayController playController)
        {
            playController.finishTurn();
            if (!playController.isValidGroups())
            {
                this.error = ErrorMessage.WRONG_GROUP;
            }
        }
    }
}