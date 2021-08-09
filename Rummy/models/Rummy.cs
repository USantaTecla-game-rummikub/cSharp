using Rummy.types;
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
        private const int NUM_INITIAL_POINTS = 30;                
        private Turn turn;
        //private SnapshotHistory snapshots;

        public Rummy(int numPlayers) {                            
            this.turn = new Turn(numPlayers);
            //this.snapshots = new SnapshotHistory(this.turn);
        }   
                    
        public void play() {
            Player player = null;
            this.writeHead();
            do {
                player = turn.take();                
                //this.snapshots.backup(player);
                do {                   
                    //turn.write();
                    //player.executeAction();                    
                    // this.snapshots.restoreAccordingAction(player);                    
                } while (!turn.isEnd());
                if (turn.isEnd() && !player.isWinner() && !turn.hasWinnerByPoints()) {
                    turn.change();
                }
            } while (!player.isResume() && !player.isWinner() && !turn.hasWinnerByPoints());
            if (player.isWinner()) {
                // player.writeCongratulations();
            }
        }
               
        private void writeHead() {
            Console.WriteLine("RUMMY");
            Console.WriteLine();
            Console.WriteLine("Possible options: PUT to put tiles on the table, MOV to move tiles between groups, END to end turn or extract tile. ");
            Console.WriteLine("HELP for more options.");
            Console.WriteLine();
            Console.WriteLine("HELP: EXIT to exit the game, SAVE to save the game, UNDO to undo move, REDO to redo move");
            Console.WriteLine();
            Console.WriteLine("Example: Put on group 2 of the table the combination 10B 10G 10R");
            Console.WriteLine("PUT 10B 10G 10R IN 2");
            Console.WriteLine("Example: Move two tiles of a group at other group");
            Console.WriteLine("MOV FROM 1 10B 10G IN 2");
            Console.WriteLine();
        }       
    }
}
