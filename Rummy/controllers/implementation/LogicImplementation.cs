using Rummy.models;
using Rummy.models.DAO;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers.implementation
{
    public class LogicImplementation: Logic
    {
        protected SessionImplementationDAO sessionImplementationDAO;
        protected StartControllerImplementation startControllerImpl;
        protected LoadControllerImplementation loadControllerImpl;
        protected PlayControllerImplementation playControllerImpl;
        protected ResumeControllerImplementation resumeControllerImpl;
        protected SaveControllerImplementation saveControllerImpl;

        public LogicImplementation(): base()
        {
            this.session = new SessionImplementation();
            this.sessionImplementationDAO = new SessionImplementationDAO();
            this.sessionImplementationDAO.associate((SessionImplementation)this.session);
            this.startControllerImpl = new StartControllerImplementation(this.session);
            this.loadControllerImpl = new LoadControllerImplementation(this.session, this.sessionImplementationDAO);
            this.playControllerImpl = new PlayControllerImplementation(this.session, this.sessionImplementationDAO);
            this.resumeControllerImpl = new ResumeControllerImplementation(this.session);
            this.saveControllerImpl = new SaveControllerImplementation(this.session, this.sessionImplementationDAO);
            this.acceptorControllers.Add(StateValue.INITIAL, this.startControllerImpl);            
            this.acceptorControllers.Add(StateValue.IN_GAME, this.playControllerImpl);
            this.acceptorControllers.Add(StateValue.RESUME, this.resumeControllerImpl);
            this.acceptorControllers.Add(StateValue.LOAD, this.loadControllerImpl);
            this.acceptorControllers.Add(StateValue.SAVE, this.saveControllerImpl);
            this.acceptorControllers.Add(StateValue.EXIT, null);
        }
    }
}
