using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class ExpTileGroup : Expression
    {
        private string tileDescription;

        public ExpTileGroup(string tileDescription)
        {
            this.tileDescription = tileDescription;
        }

        public override void interpret(IPlayerCommand player)
        {
            if (!player.existTileInTable(this.tileDescription))
            {
                this.error = ErrorMessage.WRONG_TILE;
            }
        }

        public string getDescription()
        {
            return this.tileDescription;
        }
    }
}
