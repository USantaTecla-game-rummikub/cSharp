using NUnit.Framework;
using Rummy.models.interpreter.InputParser;
using Rummy.models.interpreter.InputParser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRummy.models.interpreter.InputParser
{
    public class PutArgumentsListTest
    {
        [Test]
        public void givenSomeRackTilesGroupWithoutErrorWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" 4R 5R 6R, 8R 8G J");            
            PutArgumentsList arguments = new PutArgumentsList(input);
            arguments.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenSomeRackTilesGroupWithtErrorWhenParseHasErrorThenIsTrue()
        {
            Input input = new Input(" 4R 5R 6R, 8R 8G 9M");            
            PutArgumentsList arguments = new PutArgumentsList(input);
            arguments.parse();
            Assert.IsTrue(input.hasSintaxErrors());
        }

        [Test]
        public void givenPutWithTwoTargetGroupWithoutErrorWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" 4R 5R 6R, 8R 8G 8B IN 2");            
            PutArgumentsList arguments = new PutArgumentsList(input);
            arguments.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenPutWithOneTargetGroupWithoutErrorWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" 4R 5R 6R IN 2");            
            PutArgumentsList arguments = new PutArgumentsList(input);
            arguments.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }
        
    }
}
