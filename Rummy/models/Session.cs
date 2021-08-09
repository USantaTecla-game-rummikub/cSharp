using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models
{
    public interface Session
    {
        StateValue getState();
        void next();
        void setState(StateValue stateValue);
    }
}
