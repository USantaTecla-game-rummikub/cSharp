using Rummy.models;
using Rummy.models.DAO;
using Rummy.models.interpreter;
using Rummy.types;
using Rummy.views.console.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers.implementation
{
    public class PlayControllerImplementation : PlayController
    {
        private SessionImplementationDAO sessionImplementationDAO;
        private SessionImplementation session;

        public PlayControllerImplementation(SessionImplementation session, SessionImplementationDAO sessionImplementationDAO): base(session)
        {
            this.session = session;
            this.sessionImplementationDAO = sessionImplementationDAO;
        }
        
        public override void executeAction(string input)
        {            
            this.session.executeAction(input);
        }

        public override string getCurrentPlayerNumber()
        {
            return this.session.getCurrentPlayerNumber();
        }

        public override string getActionError()
        {
            return this.session.getActionError();
        }

        public override bool isActionError()
        {
            return this.session.isActionError();
        }

        public override bool hasWinner()
        {
            return this.session.hasWinner();
        }

        public override void takeTurn()
        {
            this.session.takeTurn();
        }

        public override void changeTurn()
        {
            this.session.changeTurn();
        }

        public override int getPounchTilesNumber()
        {
            return this.session.getPounchTilesNumber();
        }

        public override string getTable()
        {
            return this.session.getTable();
        }

        public override string getCurrentPlayerRackByGroups()
        {
            return this.session.getCurrentPlayerRackByGroups();
        }

        public override bool hasErrorLastAction()
        {
            return !String.IsNullOrEmpty(this.session.getActionError());
        }

        public override bool isLastActionAnExtraction()
        {
            return this.session.isLastActionAnExtraction();
        }

        public override bool isLastActionEndTurn()
        {
            return this.session.isLastActionEndTurn();
        }

        public override string getLastExtractionTile()
        {
            return this.session.getLastExtractionTile();
        }

        internal override bool isLastActionSave()
        {
            return this.session.isLastActionSave();
        }       

        internal override bool isLastActionLoad()
        {
            return this.session.isLastActionLoad();
        }       
    }
}
