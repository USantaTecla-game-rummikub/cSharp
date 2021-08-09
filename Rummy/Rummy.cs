using Rummy.controllers;
using Rummy.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy
{
    public abstract class Rummy
    {
        private View view;
        private Logic logic;

        public Rummy()
        {
            this.logic = this.createLogic();
            this.view = this.createView();
        }

        public abstract View createView();
        public abstract Logic createLogic();

        public void play()
        {
            AcceptorController acceptorController;
            do
            {
                acceptorController = this.logic.getController();
                if (acceptorController != null)
                {
                    this.view.interact(acceptorController);
                }
            } while (acceptorController != null);
        }
    }
}
