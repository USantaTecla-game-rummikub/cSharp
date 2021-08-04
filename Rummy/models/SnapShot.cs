using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class SnapShot
    {
        private int currentPlayer;
        private int turnsAfterEmptyPounch;
        private string playerState;
        private string tilesPounch;
        private string tilesGroup;

        public SnapShot(int currentPlayer, int turnsAfterEmptyPounch, string playerState, 
                 string tilesPounch, string tilesGroup)
        {
            this.currentPlayer = currentPlayer;
            this.turnsAfterEmptyPounch = turnsAfterEmptyPounch;
            this.playerState = playerState;
            this.tilesPounch = tilesPounch;
            this.tilesGroup = tilesGroup;
        }
               
        public int getCurrentPlayer()
        {
            return this.currentPlayer;
        }

        public int getTurnsAfterEmptyPounch()
        {
            return this.turnsAfterEmptyPounch;
        }

        public string getPlayerState()
        {
            return this.playerState;
        }

        public string getTilesPounch()
        {
            return this.tilesPounch;
        }

        public string getTilesGroup()
        {
            return this.tilesGroup;
        }
    }
}
