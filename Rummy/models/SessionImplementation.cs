using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.controllers;
using Rummy.models.interpreter;
using Rummy.types;

namespace Rummy.models
{
    public class SessionImplementation: Session
    {
        private State state;
        private Game game;
        private GameRegistry gameRegistry;
        private string errorLastCommand;

        public SessionImplementation()
        {
            this.state = new State();
            this.game = new Game();
            this.gameRegistry = new GameRegistry(this.game);
            this.errorLastCommand = null;
        }

        public void next()
        {
            this.state.next();
        }

        internal bool isNumberPlayersValid(int numPlayers)
        {
            return this.game.isNumberPlayersValid(numPlayers);
        }

        public StateValue getState()
        {
            return this.state.getStateValue();
        }

        internal void continuePlay()
        {
            this.setState(StateValue.IN_GAME);
        }

        internal void setActionError(string message)
        {
            this.errorLastCommand = message;
        }
        
        public void executeAction(Command command, PlayController playController)
        {
            this.gameRegistry.register();
            command.execute(playController);
            this.errorLastCommand = command.getError();           
        }

        internal Game getGame()
        {
            return this.game;
        }

        public void setState(StateValue state)
        {
            this.state.setState(state);
        }

        internal string getCurrentPlayerNumber()
        {
            return this.game.getCurrentPlayerNumber();
        }

        public void play(int numPlayers)
        {
            this.game.setNumberPlayers(numPlayers);
        }

        internal void takeTurn()
        {
            this.game.takeTurn();
        }

        internal void changeTurn()
        {
            this.game.changeTurn();
        }

        internal bool hasWinner()
        {
            return this.game.hasWinner();
        }

        internal bool isActionError()
        {
            return !String.IsNullOrEmpty(this.errorLastCommand);
        }

        internal int getPounchTilesNumber()
        {
            return this.game.getPounchTilesNumber();
        }

        internal string getTable()
        {
            return this.game.getTable();
        }

        internal string getCurrentPlayerRackByGroups()
        {
            return this.game.getCurrentPlayerRackByGroups();
        }

        internal bool isLastActionSave()
        {
            return this.game.isLastActionSave();
        }

        internal string getActionError()
        {
            return this.errorLastCommand;
        }

        internal void undo()
        {
            if (this.gameRegistry.isUndoable())
            {
                this.gameRegistry.undo();
            }
        }

        internal void redo()
        {
            if (this.gameRegistry.isRedoable())
            {
                this.gameRegistry.redo();
            }
        }

        internal bool existTileInRack(string tileDescription)
        {
            return this.game.existTileInRack(tileDescription);
        }

        internal bool isValidGroups()
        {
            return this.game.isValidGroups();
        }

        internal bool existTileInTable(string tileDescription)
        {
            return this.game.existTileInTable(tileDescription);
        }

        internal bool existGroup(string group)
        {
            return this.game.existGroup(group);
        }

        internal bool isValidAddTilesInGroup(List<string> tiles, int group)
        {
            return this.game.isValidAddTilesInGroup(tiles, group);
        }

        internal bool isAllowedToTileDown(List<List<string>> tiles)
        {
            return this.game.isAllowedToTileDown(tiles);
        }

        internal bool hasPlayed30FirstPoints()
        {
            return this.game.hasPlayed30FirstPoints();
        }

        internal bool isLastActionLoad()
        {
            return this.game.isLastActionLoad();
        }

        internal void finishTurn()
        {
            this.game.finishTurn();
        }

        internal void addTilesToGroup(List<string> tiles, string group)
        {
            this.game.addTilesToGroup(tiles, group);
        }

        internal bool existsTileInGroup(string tile, int group)
        {
            return this.game.existsTileInGroup(tile, group);
        }

        internal void moveTileFromGroupToGroup(string tile, int originGroup, int targetGroup)
        {
            this.game.moveTileFromGroupToGroup(tile, originGroup, targetGroup);
        }

        internal bool isLastActionAnExtraction()
        {
            return this.game.isLastActionAnExtraction();
        }

        internal bool isLastActionEndTurn()
        {
            return this.game.isLastActionEndTurn();
        }

        internal string getLastExtractionTile()
        {
            return this.game.getLastExtractionTile();
        }

        public bool isLastActionUndo()
        {
            return this.game.isLastActionUndo();
        }

        public bool isLastActionRedo()
        {
            return this.game.isLastActionRedo();
        }
    }
}
