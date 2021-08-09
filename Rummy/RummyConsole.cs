using Rummy.controllers;
using Rummy.controllers.implementation;
using Rummy.views;
using Rummy.views.console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy
{
    class RummyConsole: Rummy
    {
       public override Logic createLogic()
        {
            return new LogicImplementation();
        }

        public override View createView()
        {
            return new ConsoleView();
        }

        static void Main(string[] args)
        {
            new RummyConsole().play();
        }       
    }
}
