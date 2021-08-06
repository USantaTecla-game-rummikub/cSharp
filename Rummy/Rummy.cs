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

        public abstract View createView();
        public abstract Logic createLogic();

        public void play()
        {

        }
    }
}
