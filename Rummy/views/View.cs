using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.controllers;

namespace Rummy.views
{
    public abstract class View
    {
        public abstract void interact(AcceptorController acceptorController);        
    }
}
