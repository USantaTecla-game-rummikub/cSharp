using Rummy.models.interpreter;
using Rummy.types;
using Rummy.views;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rummy.models
{
    public class Player: IPlayerCommand
    {        
        private const int POINTS_FOR_FIRST_TILES_DOWN = 30;
        private List<Tile> rack;        
        private Table table;
        private ActionType lastAction;
        private bool hasPlayedHis30Points;
        private string errorLastAction;

        public Player(Table table) {
            this.table = table;
            this.rack = new List<Tile>();
            this.lastAction = ActionType.STARTTURN;
            this.hasPlayedHis30Points = false;
        }
      
        public void extractTile() {
            // this.lastAction = ActionType.EXTRACT;
            this.addTileInRack(this.table.extract());
        }

        public Tile getLastExtractedTile() {
            if (this.lastAction == ActionType.EXTRACT || this.lastAction == ActionType.ENDTURN_WITH_EXTRACT) {
                return this.rack[this.rack.Count - 1];
            } else {
                return null;
            }
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

        private int getPointsRunsToDown(List<string> tiles) {
            TilesGroup group = this.createTestGroup(tiles);
            if (group.isRunValid())
            {
                return group.getPoints();
            }
            return 0;
        }

        private TilesGroup createTestGroup(List<string> tiles)
        {
            TilesGroup group = new TilesGroup(TilesGroup.NEW);
            for (int i = 0; i < tiles.Count; i++)
            {
                group.addTile(this.findTileInRack(tiles[i]));
            }
            return group;
        }       

        public string getRackByGroups() {            
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
            return this.getGroupString(redGroup) + "| " + this.getGroupString(greenGroup) + "| " + this.getGroupString(blueGroup) + "| " + this.getGroupString(yellowGroup) + "| " + this.getGroupString(jokerGroup);  
        }
        
        private string getGroupString(List<Tile> colorGroup) {
            string result = "";
            foreach (Tile tile in colorGroup) {
                result += tile.ToString() + " ";                
            }
            return result;
        }
       
        internal void executeAction(string input)
        {
            CommandParser parser = new CommandParser(input, this);
            parser.parse();
            if (parser.hasError())
            {
                this.errorLastAction = parser.getError();                
            } else
            {
                this.errorLastAction = null;
            }            
        }

        internal string getErrorLastAction()
        {
            return this.errorLastAction;
        }

        public string getState()
        {
            return (int)this.lastAction + Message.VERTICAL_SLASH + this.hasPlayedHis30Points.ToString() + Message.VERTICAL_SLASH + this.rackToString();
        }

        public string rackToString()
        {
            string result = "";
            foreach (Tile tile in this.rack)
            {
                result += tile.ToString() + Message.SPACE;
            }
            return result;
        }

        public void set(string state)
        {
            string[] chunks = state.Split(char.Parse(Message.VERTICAL_SLASH));
            this.lastAction = (ActionType)(int.Parse(chunks[0]));
            this.hasPlayedHis30Points = bool.Parse(chunks[1]);
            string[] tiles = chunks[2].Split(char.Parse(Message.SPACE));
            this.rack.Clear();
            foreach (string tile in tiles)
            {
                if (!String.IsNullOrEmpty(tile))
                {
                    this.addTileInRack(Pounch.getTileByDescription(tile));
                }
            }
        }

        public bool isResume() {
            return false;
        }
      
        public bool isEnd() {
            // return this.lastAction == ActionType.ENDTURN || this.lastAction == ActionType.ENDTURN_WITH_EXTRACT || this.lastAction == ActionType.UNDO || this.lastAction == ActionType.REDO;
            return this.lastAction == ActionType.ENDTURN || this.lastAction == ActionType.ENDTURN_WITH_EXTRACT;
        }

        public void startTurn()
        {
            this.lastAction = ActionType.STARTTURN;
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
     
        public bool isAllowedToTileDown(List<List<string>> tilesGroups)
        {
            int points = 0;
            foreach (List<string> tiles in tilesGroups)
            {
                points += this.getPointsByGroupsToDown(tiles);
            }
            return (!this.hasPlayedHis30Points && points >= POINTS_FOR_FIRST_TILES_DOWN) || this.hasPlayedHis30Points;
        }
      
        private Tile findTileInRack(string tileString)
        {
            Debug.Assert(tileString.Length >= 1 && tileString.Length <= 3);
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

        public bool existsTileInGroup(string tileDescription, int group)
        {
            return this.table.existsTileInGroup(tileDescription, group);
        }

        public void moveTileFromGroupToGroup(string tileString, int origin, int target)
        {
            this.table.moveTileFromOriginGroupToTargetGroup(tileString, origin, target);
            this.lastAction = ActionType.GROUPMOVEMENT;
        }       

        public void finishTurn()
        {
            if (this.lastAction == ActionType.STARTTURN || this.lastAction == ActionType.EXTRACT)
            {
                this.extractTile();
                this.lastAction = ActionType.ENDTURN_WITH_EXTRACT;
            } else {
                this.lastAction = ActionType.ENDTURN;
            }
        }            

        public bool isValidGroups()
        {
            bool valids = this.table.isValidGroups();
            if (!valids)
            {  
                this.lastAction = ActionType.STARTTURN;
            }
            return valids;
        }

        public bool isValidAddTilesInGroup(List<string> tiles, int groupIndex)
        {
            List<Tile> lstTiles = new List<Tile>();
            foreach (string tile in tiles)
            {                
                lstTiles.Add(Pounch.getTileByDescription(tile));
            }
            return this.table.isValidAddTilesInGroup(lstTiles, groupIndex);
        }

        public void undo()
        {
            this.lastAction = ActionType.UNDO;
        }

        public void redo()
        {
            this.lastAction = ActionType.REDO;
        }        

        public void save()
        {
            this.lastAction = ActionType.SAVE;
        }

        public void load()
        {
            this.lastAction = ActionType.LOAD;
        }
    }
}