using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.types
{
    public enum ActionType {        
        STARTTURN,
        EXTRACT,        
        TILEDOWN,
        GROUPMOVEMENT,        
        ENDTURN
    }
}