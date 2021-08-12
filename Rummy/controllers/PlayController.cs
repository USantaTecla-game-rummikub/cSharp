using Rummy.models;
using Rummy.models.interpreter;
using Rummy.types;
using Rummy.views.console.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers
{
    public abstract class PlayController : AcceptorController
    {
        public PlayController(SessionImplementation session): base(session)
        {

        }

        public override void accept(ControllerVisitor controllerVisitor)
        {
            controllerVisitor.visit(this);
        }

        internal abstract bool hasPlayed30FirstPoints();

        internal void exit()
        {
            this.setState(StateValue.INITIAL);
        }

        internal void resume()
        {
            this.setState(StateValue.RESUME);
        }
        internal abstract void undo();
        internal abstract void redo();
        internal abstract bool existTileInRack(string tileDescription);

        internal abstract bool isValidGroups();        

        internal abstract bool existTileInTable(string tileDescription);

        internal abstract bool existGroup(string group);        

        public abstract void takeTurn();

        public abstract void changeTurn();

        public abstract int getPounchTilesNumber();

        public abstract string getTable();

        public abstract string getCurrentPlayerNumber();

        public abstract string getCurrentPlayerRackByGroups();

        public abstract void executeAction(Command command);

        public abstract bool isActionError();

        public abstract string getActionError();

        public abstract bool hasWinner();
        internal abstract bool isValidAddTilesInGroup(List<string> tiles, int v);
        internal abstract bool isAllowedToTileDown(List<List<string>> tiles);
        internal abstract void addTilesToGroup(List<string> tiles, string v);
        public abstract bool hasErrorLastAction();

        public abstract bool isLastActionAnExtraction();

        internal abstract bool existsTileInGroup(string tile, int group);        

        internal abstract void moveTileFromGroupToGroup(string tile, int originGroup, int targetGroup);
        public abstract string getLastExtractionTile();
        public abstract bool isLastActionEndTurn();
        internal abstract bool isLastActionSave();
        
        internal abstract bool isLastActionLoad();        

        internal void save()
        {
            this.setState(StateValue.SAVE);
        }

        internal void load()
        {
            this.setState(StateValue.LOAD);
        }

        internal abstract void finishTurn();        
    }
}
