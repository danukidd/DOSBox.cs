using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DosBox.Command.Library;
using DosBox.Filesystem;
using DosBoxTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DosBoxTest.Command.Library
{
    [TestClass]
    public class CmdVerTest : CmdTest
    {
        [TestInitialize]
        public void setUp()
        {
            // Check this filestructure in base class: crucial to understand the tests.
            this.CreateTestFileStructure();

            // Add all commands which are necessary to execute this unit test
            // Important: Other commands are not available unless added here.
            commandInvoker.AddCommand(new CmdVer("ver", drive));
        }

        [TestMethod]
        public void CmdVer_NoParameter()
        {
            // given
            const string commandName = "";

            // when
            ExecuteCommand("ver " + commandName);

            // then
            TestHelper.AssertContains("Microsoft Windows XP [Version 5.1.2600] \n", testOutput.ToString());

        }

        [TestMethod]
        public void CmdVer_WithParameter()
        {
            // given
            const string commandName = "/W";

            // when
            ExecuteCommand("ver " + commandName);

            // then
            TestHelper.AssertContains("hsaputra@bps.go.id.", testOutput.ToString());

        }

        
    }
}
