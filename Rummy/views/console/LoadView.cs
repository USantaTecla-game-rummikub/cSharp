using System;
using Rummy.controllers;
using Rummy.types;

namespace Rummy.views.console
{
    public class LoadView: View
    {
        public override void interact(AcceptorController acceptorController)
        {
            LoadController loadController = (LoadController)acceptorController;
            this.showPreviousFiles(loadController);
            this.requestFileNumber(loadController);
        }

        private void requestFileNumber(LoadController loadController)
        {
            Console.Write(Message.INTRODUCE_FILE_NUMBER);            
            string[] files = loadController.getSavedPreviousFiles();
            int index = 0;
            try
            {
                index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < files.Length)
                {
                    loadController.load(files[index]);                    
                }
                else
                {
                    Console.WriteLine(ErrorMessage.WRONG_FILE_INDEX);
                    loadController.init();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ErrorMessage.WRONG_FILE_INDEX);
                loadController.init();
            }                 
        }

        private void showPreviousFiles(LoadController loadController)
        {
            Console.WriteLine();
            Console.WriteLine(Message.PREVIOUS_FILES);
            string[] files = loadController.getSavedPreviousFiles();
            if (files == null || files.Length == 0)
            {
                Console.WriteLine(Message.NOT_PREVIOUS_FILES);
            }
            else
            {
                int i = 0;
                foreach (string file in files)
                {
                    Console.WriteLine(i + Message.POINT + Message.SPACE + file);
                    i++;
                }
            }
        }
    }
}