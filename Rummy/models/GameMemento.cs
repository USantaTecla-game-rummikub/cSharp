using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class GameMemento
    {
        private int playersNumber;
        private int currentPlayer;
        private int turnsAfterEmptyPounch;
        private List<string> playersStates;
        private string tilesPounch;
        private string tilesGroup;

        public GameMemento(int playersNumber, int currentPlayer, int turnsAfterEmptyPounch, List<string> playersStates, 
                 string tilesPounch, string tilesGroup)
        {
            this.playersNumber = playersNumber;
            this.currentPlayer = currentPlayer;
            this.turnsAfterEmptyPounch = turnsAfterEmptyPounch;
            this.playersStates = playersStates;
            this.tilesPounch = tilesPounch;
            this.tilesGroup = tilesGroup;
        }
               
        public int getPlayersNumber()
        {
            return this.playersNumber;
        }

        public int getCurrentPlayer()
        {
            return this.currentPlayer;
        }

        public int getTurnsAfterEmptyPounch()
        {
            return this.turnsAfterEmptyPounch;
        }

        public string getPlayerState(int playerIndex)
        {
            return this.playersStates[playerIndex];
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
