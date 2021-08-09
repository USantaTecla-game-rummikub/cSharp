using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.DAO
{
    public class SessionImplementationDAO
    {
        public static string EXTENSION = ConfigurationManager.AppSettings["EXTENSION"];
        public static string DIRECTORY = ConfigurationManager.AppSettings["DIRECTORY"];

        private SessionImplementation sessionImplementation;
        private GameDAO gameDAO;

        internal string[] getFilesNames()
        {
            string[] files = Directory.GetFiles(DIRECTORY);
            string[] filesOut = new string[files.Length];
            int index = 0;
            foreach (string file in files)
            {
                string[] aux = file.Split('\\');
                filesOut[index++] = aux[aux.Length - 1];
            }
            return filesOut;
        }

        internal void load(string name)
        {
            try
            {
                StreamReader streamReader = new StreamReader(DIRECTORY + "/" + name);
                this.gameDAO.load(streamReader);
                streamReader.Close();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void save(string name)
        {            
            try
            {
                StreamWriter streamWriter = new StreamWriter(DIRECTORY + "/" + name);
                this.gameDAO.save(streamWriter);
                streamWriter.Close();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void associate(SessionImplementation session)
        {
            this.sessionImplementation = session;
            this.gameDAO = new GameDAO(this.sessionImplementation.getGame());
        }
    }
}
