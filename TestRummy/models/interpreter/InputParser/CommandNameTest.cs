using NUnit.Framework;
using Rummy.models.interpreter.InputParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRummy.models.interpreter.InputParser
{
    public class CommandNameTest
    {
        [Test]
        public void givenPutWithoutErrorAndWithJokerWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input("PUT 10G 10B J");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenPutWithoutErrorWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input("PUT 4R 5R J, 10R 10G 10B");            
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenSomeRackTilesGroupWithtErrorWhenParseHasErrorThenIsTrue()
        {
            Input input = new Input("PUT 4R 5R 6R, 8R 8G 9M");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsTrue(input.hasSintaxErrors());
        }

        [Test]
        public void givenPutWithTwoTargetGroupWithoutErrorWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input("PUT 4R 5R 6R IN 1, 8R 8G 8B IN 2");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTableGroupForMoveToNewGroupTWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input("MOV FROM 1 4R 5R 6R");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTableGroupForMoveToExistingGroupTWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input("MOV FROM 1 4R 5R 6R IN 2");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }

        [Test]
        public void givenTableGroupForMoveWhenParseHasErrorThenIsTrue()
        {
            Input input = new Input("MOV FROM 1 4R 5R 6R IN");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsTrue(input.hasSintaxErrors());
        }

        [Test]
        public void givenTableGroupForMoveToNewGroupTWhenParseHasErrorThenIsTrue()
        {
            Input input = new Input("MOV FROM 4R 5R 6R");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsTrue(input.hasSintaxErrors());
        }

        [Test]
        public void givenTwoTableGroupForMoveWhenParseHasErrorThenIsFalse()
        {
            Input input = new Input("MOV FROM 1 4R 5R 6R, FROM 2 8R 8G 8B IN 1");
            CommandParser commandName = new CommandParser(input);
            commandName.parse();
            Assert.IsFalse(input.hasSintaxErrors());
        }
    }
}
