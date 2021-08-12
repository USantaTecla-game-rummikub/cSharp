using Rummy.controllers;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class TileGroup : Command
    {
        private string tileDescription;

        public TileGroup(string tileDescription)
        {
            this.tileDescription = tileDescription;
        }

        public override void execute(PlayController playController)
        {
            if (!playController.existTileInTable(this.tileDescription))
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
