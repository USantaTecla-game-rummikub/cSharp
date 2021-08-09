using Rummy.models;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers
{
    public abstract class Controller
    {
        private Session session;

        public Controller(Session session)
        {
            this.session = session;
        }

        public void next()
        {
            session.next();
        }

        public StateValue getState()
        {
            return this.session.getState();
        }

        public void setState(StateValue value)
        {
            this.session.setState(value);
        }
       
    }
}
