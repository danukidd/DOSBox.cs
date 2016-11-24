using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DosBox.Command.Library;
using DosBoxTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DosBoxTest.Command.Library
{
    [TestClass]
    public class CmdTimeTest : CmdTest
    {
        [TestInitialize]
        public void setUp()
        {
            // Check this filestructure in base class: crucial to understand the tests.
            this.CreateTestFileStructure();

            // Add all commands which are necessary to execute this unit test
            // Important: Other commands are not available unless added here.
            commandInvoker.AddCommand(new CmdTime("time", drive));
        }

        [TestMethod]
        public void CmdTime_WithoutParameter()
        {
            ExecuteCommand("time");
            TestHelper.AssertContains(DateTime.Now.ToString(), testOutput.ToString());
        }

        [TestMethod]
        public void CmdTime_WithParameterTime()
        {
            ExecuteCommand("time 21:30:10");
            TestHelper.AssertOutputIsEmpty(testOutput);
        }

        [TestMethod]
        public void CmdTime_WithParameterGaga()
        {
            ExecuteCommand("time gaga");
            TestHelper.AssertContains("Command rejected", testOutput.ToString());
        }

        [TestMethod]
        public void CmdTime_WithParameterTwoMore()
        {
            ExecuteCommand("time gaga no");
            TestHelper.AssertContains("incorrect", testOutput.ToString());
        }
    }
}
