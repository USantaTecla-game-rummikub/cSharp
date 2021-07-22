using System;
using Rummy.types;

namespace Rummy.models.interpreter
{
    public class ExpTileRack: Expression
    {
        private string tileDescription;

        public ExpTileRack(string tileDescription)
        {
            this.tileDescription = tileDescription;
        }
        
        public override void interpret(IPlayerCommand player)
        {
            if (!player.existTileInRack(this.tileDescription)) {
                this.error = ErrorMessage.WRONG_TILE;
            } 
        }

        public string getDescription()
        {
            return this.tileDescription;
        }
    }
}