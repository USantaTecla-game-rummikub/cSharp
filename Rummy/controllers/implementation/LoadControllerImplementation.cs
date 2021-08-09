using Rummy.models;
using Rummy.models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers.implementation
{
    public class LoadControllerImplementation : LoadController
    {
        private SessionImplementation session;
        private SessionImplementationDAO sessionDAO;

        public LoadControllerImplementation(Session session, SessionImplementationDAO sessionImplementationDAO): base(session)
        {
            this.session = (SessionImplementation)session;
            this.sessionDAO = sessionImplementationDAO;
        }       

        public override string[] getSavedPreviousFiles()
        {
            return this.sessionDAO.getFilesNames();
        }

        public override void load(string name)
        {            
            try
            {
                this.sessionDAO.load(name);                
                this.play();
            }
            catch (Exception ex)
            {

            }            
        }       
    }
}
