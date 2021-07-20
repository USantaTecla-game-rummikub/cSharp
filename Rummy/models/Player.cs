using Rummy.models.interpreter;
using Rummy.types;
using System;

namespace Rummy.models
{
    public class Player
    {
        private Tile[] rack;
        private int topRack;
        private Table table;
        private ActionType lastAction;

        public Player(Table table) {
            this.table = table;
            this.rack = new Tile[Table.TILES_TOTALES];            
            this.topRack = 0;
        }

        internal void extractTile() {
            this.lastAction = ActionType.EXTRACT;
            this.rack[topRack++] = this.table.extract();
        }

        internal bool isWinner() {
            return this.rack.Length == 0;
        }

        public int getPoints() {
            int points = 0;
            foreach (Tile tile in this.rack) {
                points += (int) tile.getNumber();
            }
            return points;
        }

        internal void write() {
            
        }

        internal void executeAction()
        {
            Console.Write(Message.REQUEST_ACTION);            
            Parser parser = new Parser(Console.ReadLine());
            this.lastAction = ActionType.TILEDOWN;
        }

        internal bool isResume() {
            return false;
        }

        internal void writeCongratulations() {
            Console.WriteLine("¡¡ Congratulations, you made a RUMMY !!");
        }

        internal bool isEnd() {
            return false;
        }

        internal ActionType getLastAction() {
            return this.lastAction;
        }
    }
}