using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class Parser
    {        
        public Parser(string command)
        {
            Sentence sentence = new Sentence();
            string[] tokens = command.Split(' ');
            sentence.interpret(tokens);
        } 
    }
}
