using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.controllers;

namespace Rummy.views.console
{
    public class ConsoleView: View, ControllerVisitor
    {
        private StartView startView;
        private PlayView playView;
        private LoadView loadView;
        private ResumeView resumeView;
        private SaveView saveView;

        public ConsoleView()
        {
            this.startView = new StartView();
            this.playView = new PlayView();
            this.loadView = new LoadView();
            this.resumeView = new ResumeView();
            this.saveView = new SaveView();
        }

        public override void interact(AcceptorController acceptorController)
        {
            acceptorController.accept(this);
        }

        public void visit(StartController controller)
        {
            this.startView.interact(controller);
        }

        public void visit(PlayController controller)
        {
            this.playView.interact(controller);
        }

        public void visit(LoadController controller)
        {
            this.loadView.interact(controller);
        }

        public void visit(ResumeController controller)
        {
            this.resumeView.interact(controller);
        }

        public void visit(SaveController controller)
        {
            this.saveView.interact(controller);
        }
    }
}
