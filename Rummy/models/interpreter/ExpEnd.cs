namespace Rummy.models.interpreter
{
    internal class ExpEnd: Expression
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