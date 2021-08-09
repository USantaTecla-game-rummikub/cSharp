using System;
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

        internal void executeAction(string input)
        {
            this.player.executeAction(input);            
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
    }
}