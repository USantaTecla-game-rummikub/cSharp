using Rummy.models;
using Rummy.types;
using System.Collections.Generic;

namespace Rummy.controllers
{
    public class Logic
    {
        protected SessionImplementation session;
        public Dictionary<StateValue, AcceptorController> acceptorControllers;

        public Logic()
        {            
            this.acceptorControllers = new Dictionary<StateValue, AcceptorController>();
        }
        public AcceptorController getController()
        {
            return this.acceptorControllers[this.session.getState()];
        }
    }
}