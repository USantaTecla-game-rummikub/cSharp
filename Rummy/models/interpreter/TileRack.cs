using System;
using Rummy.controllers;
using Rummy.types;

namespace Rummy.models.interpreter
{
    public class TileRack: Command
    {
        private string tileDescription;

        public TileRack(string tileDescription)
        {
            this.tileDescription = tileDescription;
        }
        
        public override void execute(PlayController playController)
        {
            if (!playController.existTileInRack(this.tileDescription)) {
                this.error = ErrorMessage.WRONG_TILE_NOT_EXIST_IN_RACK;
            } 
        }

        public string getDescription()
        {
            return this.tileDescription;
        }
    }
}