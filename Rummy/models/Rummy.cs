using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public class Rummy
    {
        private const int TILES_PER_PLAYER = 14;
        private const int NUM_PLAYERS_MAX = 4;
        private const int NUM_INITIAL_POINTS = 30;

        private Player[] players;
        private Table table;
        private Turn turn;

        public Rummy(int numPlayers) {
            Debug.Assert(numPlayers <= NUM_PLAYERS_MAX);
            this.table = new Table();
            this.createPlayers(numPlayers);            
            this.turn = new Turn(this.players);            
            this.distributeTiles();
            this.selectStartingPlayer();
        }
       
        private void createPlayers(int numPlayers) {
            Debug.Assert(numPlayers <= NUM_PLAYERS_MAX);
            this.players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; i++) {                
                Player player = new Player(this.table);
                this.players[i] = player;                
            }
        }
        private void distributeTiles() {
            foreach (Player player in this.players) {
                for (int i = 1; i <= TILES_PER_PLAYER; i++) {
                    player.takeTile();
                }
            }
        }
        private void selectStartingPlayer()
        {
            Random rnd = new Random();
            int indexPlayer = rnd.Next(0, this.players.Length);
            for (int i = 0; i < indexPlayer; i++) {
                turn.change();
            }
        }

        public void play() {
            Player player = null;
            this.writeHead();
            do {
                player = turn.take();
                this.writePlay();
                do {
                    this.turn.requestAction().execute();
                } while (!turn.isEnd());
                if (!turn.isEnd()) {
                    turn.change();
                }
            } while (!player.isResume() && !player.isWinner());
        }

        private void writeHead()
        {
            Console.WriteLine("RUMMY");
            Console.WriteLine();
            Console.WriteLine("Possible options: PUT to put tiles on the table, MOV to move tiles between groups, END to end turn or extract tile. ");
            Console.WriteLine("HELP for more options.");
            Console.WriteLine();
            Console.WriteLine("HELP: EXIT to exit the game, SAVE to save the game, UNDO to undo move, REDO to redo move");
            Console.WriteLine();
            Console.WriteLine("Ejem: Put on group 2 of the table the combination 10B 10G 10R");
            Console.WriteLine("PUT 10B 10G 10R IN 2");
        }

        private void writePlay() {
            this.table.write();
            this.writePlayers();
            table.write();            
        }

        private void writePlayers() {
            for (int i = 0; i < this.players.Length; i++) {
                this.players[i].write();
            }
        }
    }
}
