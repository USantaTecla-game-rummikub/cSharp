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
        }
    }
}