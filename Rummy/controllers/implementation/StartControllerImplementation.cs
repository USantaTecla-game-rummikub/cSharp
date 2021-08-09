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
    public class StartControllerImplementation : StartController
    {
        private SessionImplementation session;
        public StartControllerImplementation(Session session): base(session)
        {
            this.session = (SessionImplementation)session;
        }

        public override bool isNumberPlayersValid(int numPlayers)
        {
            return this.session.isNumberPlayersValid(numPlayers);
        }

        public override void play(int numberPlayers)
        {            
            this.session.play(numberPlayers);
            this.session.next();
        }
    }
}
