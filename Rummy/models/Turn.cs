using Rummy.types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class Turn
    {
        private const int NUM_PLAYERS_MAX = 4;
        private const int TILES_PER_PLAYER = 14;
        private const int POINTS_MAX = 728;

        private Player[] players;
        private int currentPlayer;
        private Table table;
        private int turnsAfterEmptyPounch;

        public Turn(int numPlayers) {
            this.table = new Table();
            this.createPlayers(numPlayers);
            this.distributeTiles();            
            this.selectStartingPlayer();
            this.turnsAfterEmptyPounch = 0;
        }

        private void createPlayers(int numPlayers) {
            Debug.Assert(numPlayers <= 2 && numPlayers <= NUM_PLAYERS_MAX);
            this.players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; i++) {
                this.players[i] = new Player(this.table);
            }
        }
      
        private void distributeTiles() {
            foreach (Player player in this.players) {
                for (int i = 1; i <= TILES_PER_PLAYER; i++) {
                    player.extractTile();
                }
            }
        }

        private void selectStartingPlayer() {
            Random rnd = new Random();
            this.currentPlayer = rnd.Next(0, this.players.Length);            
        }

        internal Player take() {            
            return this.players[this.currentPlayer];
        }
       
        internal void change() {        
            if (this.table.isEmptyPounch()) {
                this.turnsAfterEmptyPounch++;
            }
            this.currentPlayer = ++this.currentPlayer % this.players.Length;
        }
      
        internal bool isEnd() {
            return this.players[this.currentPlayer].isEnd();            
        }

        public void write() {
            Console.WriteLine("---------------------------------------------------------------------------------");
            this.table.write();
            this.writePlayers();
        }

        private void writePlayers() {
            for (int i = 0; i < this.players.Length; i++) {
                this.players[i].write();
            }
        }

        public Player getWinnerByPoints() {
            Player winner = null;
            if (this.table.isEmptyPounch()) {
                int i = 0;
                int pointsMin = POINTS_MAX;
                while (i < this.players.Length) {
                    if (this.players[i].getPoints() < pointsMin) {
                       winner = this.players[i];
                    }
                    i++;                   
                }            
            }
            return winner;
        }      

        public bool hasWinnerByPoints() {                   
            if (this.table.isEmptyPounch() && this.noPlayerCouldGoTileDown()) {                
                int pointsMin = POINTS_MAX;
                for (int i = 0; i < this.players.Length; i++) {
                    if (this.players[i].getPoints() < pointsMin) {
                        pointsMin = this.players[i].getPoints();
                    }
                    i++;
                }
                return pointsMin < POINTS_MAX;
            } 
            return false;            
        }

        private bool noPlayerCouldGoTileDown() {
            if (this.turnsAfterEmptyPounch == this.players.Length - 1) {
                bool noPlayerCouldGoTileDown = true;
                foreach (Player player in this.players) {
                   if (player.getLastAction() == ActionType.TILEDOWN) {
                        noPlayerCouldGoTileDown = false;
                   }
                }
                return noPlayerCouldGoTileDown;
            }
            return false;
        }
    }
}
