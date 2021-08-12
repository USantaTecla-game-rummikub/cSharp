using System;
using System.Collections.Generic;
using System.Configuration;
using Rummy.models.interpreter;
using Rummy.types;
using Rummy.views;

namespace Rummy.models
{
    public class Game
    {
        private Player player;
        private Turn turn;        

        public Game()
        {            
            
        }      

        public bool isNumberPlayersValid(int numPlayers)
        {
            return Turn.isNumberPlayersValid(numPlayers);
        }

        public void setNumberPlayers(int numPlayers)
        {
            this.turn = new Turn(numPlayers);
            this.player = this.turn.take();
        }

        internal int getPounchTilesNumber()
        {
            return this.turn.getPounchTilesNumber();
        }

        internal bool canCreateMemento()
        {
            return this.player.getLastAction() != ActionType.UNDO && this.player.getLastAction() != ActionType.REDO;
        }

        public void set(GameMemento gameMemento)
        {
            this.turn.restore(gameMemento);            
        }

        internal GameMemento getMemento()
        {
            return this.turn.getMemento();
        }

        internal string getErrorLastAction()
        {
            return this.player.getErrorLastAction();
        }
      
        internal string getTable()
        {
            return this.turn.getTable();
        }
      
        internal string getCurrentPlayerNumber()
        {
            return this.turn.getCurrentPlayerNumber();
        }

        internal string getCurrentPlayerRackByGroups()
        {
            return this.player.getRackByGroups();
        }

        internal void takeTurn()
        {
            this.player = this.turn.take();
        }

        internal void changeTurn()
        {
            this.turn.change();
            this.takeTurn();
        }

        internal string getLastExtractionTile()
        {
            return this.player.getLastExtractedTile().ToString();
        }

        internal bool hasWinner()
        {
            return this.player.isWinner() || this.turn.hasWinnerByPoints();
        }

        internal bool isLastActionAnExtraction()
        {
            return this.player.getLastAction() == ActionType.ENDTURN_WITH_EXTRACT;
        }

        internal bool isLastActionEndTurn()
        {
            return this.player.getLastAction() == ActionType.ENDTURN;
        }

        internal bool isLastActionUndo()
        {
            return this.player.getLastAction() == ActionType.UNDO;
        }

        public bool isLastActionRedo()
        {
            return this.player.getLastAction() == ActionType.REDO;
        }

        internal bool isLastActionSave()
        {
            return this.player.getLastAction() == ActionType.SAVE;
        }

        internal bool isLastActionLoad()
        {
            return this.player.getLastAction() == ActionType.LOAD;
        }

        internal bool isValidGroups()
        {
            return this.player.isValidGroups();
        }

        internal bool existTileInRack(string tileDescription)
        {
            return this.player.existTileInRack(tileDescription);
        }

        internal bool existTileInTable(string tileDescription)
        {
            return this.player.existTileInTable(tileDescription);
        }

        internal bool existGroup(string group)
        {
            return this.player.existGroup(group);
        }

        internal bool isValidAddTilesInGroup(List<string> tiles, int group)
        {
            return this.player.isValidAddTilesInGroup(tiles, group);
        }

        internal void redo()
        {
            this.player.redo();
        }

        internal void undo()
        {
            this.player.undo();
        }

        internal bool isAllowedToTileDown(List<List<string>> tiles)
        {
            return this.player.isAllowedToTileDown(tiles);
        }

        internal void addTilesToGroup(List<string> tiles, string group)
        {
            this.player.addTilesToGroup(tiles, group);
        }

        internal bool existsTileInGroup(string tile, int group)
        {
            return this.player.existsTileInGroup(tile, group);
        }

        internal void moveTileFromGroupToGroup(string tile, int originGroup, int targetGroup)
        {
            this.player.moveTileFromGroupToGroup(tile, originGroup, targetGroup);
        }

        internal void finishTurn()
        {
            this.player.finishTurn();
        }

        internal bool hasPlayed30FirstPoints()
        {
            return this.player.hasPlayed30FirstPoints();
        }
    }
}