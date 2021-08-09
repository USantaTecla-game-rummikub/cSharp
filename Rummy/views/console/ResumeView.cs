using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.controllers;

namespace Rummy.views.console
{
    public class ResumeView : View
    {        

        public override void interact(AcceptorController acceptorController)
        {
            Console.Write(Message.RESUME);
            string respond = Console.ReadLine();
            ResumeController resumeController = (ResumeController)acceptorController;
            if (respond.ToLower() == Message.YES)
            {                
                resumeController.resume(true);
            } else
            {
                resumeController.resume(false);
            }
        }
    }
}
