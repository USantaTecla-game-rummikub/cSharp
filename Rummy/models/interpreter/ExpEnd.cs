using Rummy.types;

namespace Rummy.models.interpreter
{
    public class ExpEnd: Expression
    {
        public ExpEnd()
        {
        }

        public override void interpret(IPlayerCommand player)
        {
            player.finishTurn();
            if (!player.isValidGroups())
            {
                this.error = ErrorMessage.WRONG_GROUP;
            }
        }
    }
}