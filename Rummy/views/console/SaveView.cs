using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.controllers;

namespace Rummy.views.console
{
    public class SaveView : View
    {
        public override void interact(AcceptorController acceptorController)
        {
            SaveController saveController = (SaveController)acceptorController;
            this.showPreviousFiles(saveController);
            this.requestFileName(saveController);
        }

        private void requestFileName(SaveController saveController)
        {
            Console.WriteLine(Message.INTRODUCE_FILE_NAME);
            saveController.save(Console.ReadLine());
        }

        private void showPreviousFiles(SaveController saveController)
        {
            Console.WriteLine(Message.PREVIOUS_FILES);
            string[] files = saveController.getSavedPreviousFiles();
            if (files == null || files.Length == 0)
            {
                Console.WriteLine(Message.NOT_PREVIOUS_FILES);
            }
            else
            {
                foreach (string file in files)
                {
                    Console.WriteLine(Message.POINT + file);
                }
            }
        }
    }
}
