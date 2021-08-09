using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.types;

namespace Rummy.models
{
    public class SessionImplementation: Session
    {
        private State state;
        private Game game;
        private GameRegistry gameRegistry;

        public SessionImplementation()
        {
            this.state = new State();
            this.game = new Game();
            this.gameRegistry = new GameRegistry(this.game);
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

        internal void executeAction(string input)
        {
            if (!this.isLastActionUndo() && !this.isLastActionRedo()) {
                this.gameRegistry.register();
            }
            this.game.executeAction(input);   
            if (this.isLastActionUndo() && this.gameRegistry.isUndoable())
            {
                this.gameRegistry.undo();
            } else if (this.isLastActionRedo() && this.gameRegistry.isRedoable())
            {
                this.gameRegistry.redo();
            }
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
            return !String.IsNullOrEmpty(this.game.getErrorLastAction());
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
            return this.game.getErrorLastAction();
        }

        internal bool isLastActionLoad()
        {
            return this.game.isLastActionLoad();
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
