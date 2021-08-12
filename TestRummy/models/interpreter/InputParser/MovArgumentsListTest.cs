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
    public class MovArgumentsListTest
    {
        [Test]
        public void givenTableGroupForMoveToNewGroupTWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" FROM 1 4R 5R 6R");
            MovArgumentsList arguments = new MovArgumentsList(input);
            arguments.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTableGroupForMoveToExistingGroupTWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" FROM 1 4R 5R 6R IN 2");           
            MovArgumentsList arguments = new MovArgumentsList(input);
            arguments.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTableGroupForMoveWhenParseHasErrorThenIsTrue()
        {
            Input input = new Input(" FROM 1 4R 5R 6R IN");           
            MovArgumentsList arguments = new MovArgumentsList(input);
            arguments.parse();
            Assert.IsTrue(input.hasSintaxErrors());
        }

        [Test]
        public void givenTableGroupForMoveToNewGroupTWhenParseHasErrorThenIsTrue()
        {
            Input input = new Input(" FROM 4R 5R 6R");           
            MovArgumentsList arguments = new MovArgumentsList(input);
            arguments.parse();
            Assert.IsTrue(input.hasSintaxErrors());
        }

        [Test]
        public void givenTwoTableGroupForMoveToExistentGroupsWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" FROM 1 4R 5R 6R IN 2, FROM 2 8R 8G 8B IN 1");            
            MovArgumentsList arguments = new MovArgumentsList(input);
            arguments.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTwoTableGroupForMoveAtNewGroupAndExistentGroupWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input(" FROM 1 4R 5R 6R, FROM 2 8R 8G 8B IN 1");
            MovArgumentsList arguments = new MovArgumentsList(input);
            arguments.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }
    }
}
