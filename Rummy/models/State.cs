using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rummy.types;

namespace Rummy.models
{
    public class State
    {
        private StateValue stateValue;

        public State()
        {
            this.reset();
        }

        public void reset()
        {
            this.stateValue = StateValue.INITIAL;
        }

        public void next()
        {
            this.stateValue = (StateValue)( (int)this.stateValue + 1);
        }

        public void setState(StateValue state)
        {
            this.stateValue = state;
        }

        public StateValue getStateValue()
        {
            return this.stateValue;
        }
    }
}
