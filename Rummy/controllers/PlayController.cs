using Rummy.models;
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

        public abstract void takeTurn();

        public abstract void changeTurn();

        public abstract int getPounchTilesNumber();

        public abstract string getTable();

        public abstract string getCurrentPlayerNumber();

        public abstract string getCurrentPlayerRackByGroups();

        public abstract void executeAction(string input);

        public abstract bool isActionError();

        public abstract string getActionError();

        public abstract bool hasWinner();

        public abstract bool hasErrorLastAction();

        public abstract bool isLastActionAnExtraction();

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
    }
}
