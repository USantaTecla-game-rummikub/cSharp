using Rummy.models;
using Rummy.models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.controllers.implementation
{
    public class SaveControllerImplementation: SaveController
    {
        private SessionImplementation session;
        private SessionImplementationDAO sessionDAO;

        public SaveControllerImplementation(Session session, SessionImplementationDAO sessionImplementationDAO) : base(session)
        {
            this.session = (SessionImplementation)session;
            this.sessionDAO = sessionImplementationDAO;
        }       

        public override void save(string name)
        {
            try
            {
                this.sessionDAO.save(name);
            } catch (Exception ex)
            {
                
            }
            this.session.continuePlay();
        }

        internal override string[] getSavedPreviousFiles()
        {
            return this.sessionDAO.getFilesNames();
        }
    }
}
