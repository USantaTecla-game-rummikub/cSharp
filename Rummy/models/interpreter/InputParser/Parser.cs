using Rummy.models.interpreter.InputParser.Commands;
using Rummy.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rummy.models.interpreter.InputParser
{
    public abstract class Parser
    {
        protected Input input;        

        public Parser(Input input)
        {
            this.input = input;
        }

        protected void testSpaceRequired()
        {
            if (!this.input.isEnd() && !this.input.isSpace())
            {
                this.input.generateError(ErrorMessage.SPACE_REQUIRED);
            }
            else
            {
                this.input.jumpSpaces();
            }
        }

        protected void testSpaceOrComaRequired()
        {
            if (!this.input.isEnd() && (this.input.isSpace() || this.input.isEqual(",")))
            {
                if (this.input.isSpace()) {
                    this.input.jumpSpaces();
                }
            } 
        }

        public abstract void parse();
    }
}
