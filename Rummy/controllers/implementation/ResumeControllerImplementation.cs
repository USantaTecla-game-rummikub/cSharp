using Rummy.models;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers.implementation
{
    public class ResumeControllerImplementation : ResumeController
    {
        private SessionImplementation session;

        public ResumeControllerImplementation(Session session): base(session)
        {
            this.session = (SessionImplementation)session;
        }

        public override void resume(bool newGame)
        {
            if (newGame)
            {
                this.play();
            } else
            {
                this.init();
            }
        }       
    }
}
