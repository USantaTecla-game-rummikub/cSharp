using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy
{
    class RummyConsole: Rummy
    {

        static void Main(string[] args)
        {
            new models.Rummy(int.Parse(args[0])).play();
        }

        public override Logic createLogic()
        {
            throw new NotImplementedException();
        }

        public override View createView()
        {
            throw new NotImplementedException();
        }
    }
}
