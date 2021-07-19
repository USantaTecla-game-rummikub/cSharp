using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter
{
    public class Sentence: Command {

        private Instruction instruction;
        private Arguments arguments;

        public Sentence(): base() {
            this.instruction = new Instruction();
            this.arguments = new Arguments();
        }

        public override void interpret(string[] expression) {
            
            this.instruction.interpret(expression);
        }
    }
}
