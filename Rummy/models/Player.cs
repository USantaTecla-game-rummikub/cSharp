using Rummy.models.interpreter;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rummy.models
{
    public class Player: IPlayerCommand
    {
        private const int TEST_GROUP_INDEX = -1;
        private const int POINTS_FOR_FIRST_TILES_DOWN = 30;
        private List<Tile> rack;        
        private Table table;
        private ActionType lastAction;
        private bool hasPlayedHis30Points;

        public Player(Table table) {
            this.table = table;
            this.rack = new List<Tile>();
            this.lastAction = ActionType.NULL;
            this.hasPlayedHis30Points = false;
        }
      
        public void extractTile() {
            this.lastAction = ActionType.EXTRACT;
            this.rack.Add(this.table.extract());
        }

        public void addTileInRack(Tile tile)
        {
            Tile newTile = new Tile();
            newTile.clone(tile);
            this.rack.Add(newTile);
        }

        public bool isWinner() {
            return this.rack.Count == 0;
        }

        public int getPoints() {
            int points = 0;
            foreach (Tile tile in this.rack)
            {
                points += (int)tile.getNumber();
            }
            return points;
        }

        private int getPointsByGroupsToDown(List<string> tiles)
        {
            return this.getPointsRunsToDown(tiles) + this.getPointsSeriesToDown(tiles);
        }

        private int getPointsSeriesToDown(List<string> tiles) {
            TilesGroup group = this.createTestGroup(tiles);
            if (group.isSerieValid())
            {
                return group.getPoints();
            }
            return 0;
        }

        private int getPointsRunsToDown(List<string> tiles)
        {
            TilesGroup group = this.createTestGroup(tiles);
            if (group.isRunValid())
            {
                return group.getPoints();
            }
            return 0;
        }

        private TilesGroup createTestGroup(List<string> tiles)
        {
            TilesGroup group = new TilesGroup(TEST_GROUP_INDEX);
            for (int i = 0; i < tiles.Count - 1; i++)
            {
                group.addTile(this.findTileInRack(tiles[i]));
            }
            return group;
        }       

        public void write() {

            List<Tile> redGroup = new List<Tile>();
            List<Tile> blueGroup = new List<Tile>();
            List<Tile> yellowGroup = new List<Tile>();
            List<Tile> greenGroup = new List<Tile>();
            List<Tile> jokerGroup = new List<Tile>();
            foreach (Tile tile in this.rack) {
                if (tile.isColorEqualsTo(Color.RED)) {
                    redGroup.Add(tile);
                } else if (tile.isColorEqualsTo(Color.BLUE)) {
                    blueGroup.Add(tile);
                } else if (tile.isColorEqualsTo(Color.GREEN)) {
                    greenGroup.Add(tile);
                } else if (tile.isColorEqualsTo(Color.YELLOW)) {
                    yellowGroup.Add(tile);
                } else if (tile.isColorEqualsTo(Color.JOKER)) {
                    jokerGroup.Add(tile);
                }
            }
            this.writeGroup(redGroup);
            Console.Write("| ");            
            this.writeGroup(greenGroup);
            Console.Write("| ");
            this.writeGroup(blueGroup);
            Console.Write("| ");
            this.writeGroup(yellowGroup);            
            Console.Write("| ");
            this.writeGroup(jokerGroup);
        }
        
        private void writeGroup(List<Tile> colorGroup) {
            foreach (Tile tile in colorGroup) {
                tile.write();
                Console.Write(" ");
            }
        }

        public void executeAction()
        {
            Console.Write(Message.REQUEST_ACTION);            
            CommandParser parser = new CommandParser(Console.ReadLine(), this);
            parser.parse();
        }

        public bool isResume() {
            return false;
        }

        public void writeCongratulations() {
            Console.WriteLine("¡¡ Congratulations, you made a RUMMY !!");
        }

        public bool isEnd() {
            return this.lastAction == ActionType.TILEDOWN || this.lastAction == ActionType.EXTRACT;
        }

        public ActionType getLastAction() {
            return this.lastAction;
        }

        private void addTileToGroup(Tile tile, int groupIndex)
        {            
           this.table.addTileToGroup(tile, groupIndex);
           this.rack.Remove(tile);                    
        }

        public void addTilesToGroup(List<string> tilesString, string groupIndex)
        {            
            Debug.Assert(tilesString != null && tilesString.Count > 0);
            List<Tile> tiles = new List<Tile>();
            foreach (string tile in tilesString)
            {               
                tiles.Add(this.findTileInRack(tile));             
            }
            if (groupIndex == null || groupIndex == "")
            {
                this.table.addTilesToGroup(tiles, TilesGroup.NEW);
            } else
            {
                this.table.addTilesToGroup(tiles, int.Parse(groupIndex));
            }            
            foreach (Tile tile in tiles)
            {
                this.rack.Remove(tile);
            }
            this.hasPlayedHis30Points = true;
            this.lastAction = ActionType.TILEDOWN;
        }

     /*   public void addTileToGroup(string tileString, int groupIndex)
        {
            Debug.Assert(this.findTileInRack(tileString) != null);            
            this.addTileToGroup(this.findTileInRack(tileString), groupIndex);
        } */

        public bool isAllowedToTileDown(List<string> tiles)
        {
            return (!this.hasPlayedHis30Points && this.getPointsByGroupsToDown(tiles) >= POINTS_FOR_FIRST_TILES_DOWN) || this.hasPlayedHis30Points;
        }
      
        private Tile findTileInRack(string tileString)
        {
            Debug.Assert(tileString.Length >= 2 && tileString.Length <= 3);
            Tile tileFinded = null;
            foreach (Tile tile in this.rack) {
                if (tile.isColorEqualsTo(tileString) && tile.isNumberEqualTo(tileString))
                {
                    tileFinded = tile;
                    break;
                }
            }
            return tileFinded;
        }

        public bool existGroup(string targetGroup) {
            if (int.TryParse(targetGroup, out int result)) {
                return this.table.hasGroup(int.Parse(targetGroup));
            } else {
                return false;
            }
        }
        
        public bool existTileInRack(string tileDescription)
        {
            return this.findTileInRack(tileDescription) != null;
        }

        public bool existTileInTable(string tileDescription)
        {
            return this.table.existTileInTable(tileDescription);
        }

        public void moveTileFromGroupToGroup(string tileString, int origin, int target)
        {
            this.table.moveTileFromOriginGroupToTargetGroup(tileString, origin, target);
            this.lastAction = ActionType.GROUPMOVEMENT;
        }       

        public void finishTurn()
        {
            if (this.lastAction == ActionType.EXTRACT)
            {
                this.addTileInRack(this.table.extract());                
            } 
        }            
    }
}