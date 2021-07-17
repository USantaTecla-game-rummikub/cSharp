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

        private Player[] players;
        private int currentPlayer;
        private Table table;

        public Turn(int numPlayers) {
            this.table = new Table();
            this.createPlayers(numPlayers);
            this.distributeTiles();            
            this.selectStartingPlayer();           
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
            this.currentPlayer = ++this.currentPlayer % this.players.Length;
        }
      
        internal bool isEnd() {
            return this.players[this.currentPlayer].isEnd();            
        }

        public void write()
        {
            this.table.write();
            this.writePlayers();
        }

        private void writePlayers() {
            for (int i = 0; i < this.players.Length; i++) {
                this.players[i].write();
            }
        }
    }
}
