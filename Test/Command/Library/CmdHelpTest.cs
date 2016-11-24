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
    public class CmdHelpTest : CmdTest
    {
        [TestInitialize]
        public void setUp()
        {
            // Check this filestructure in base class: crucial to understand the tests.
            this.CreateTestFileStructure();

            // Add all commands which are necessary to execute this unit test
            // Important: Other commands are not available unless added here.
            commandInvoker.AddCommand(new CmdHelp("help", drive));
        }

        [TestMethod]
        public void CmdHelp_UnsupportCommand()
        {
            // given
            const string commandName = "cxy";

            // when
            ExecuteCommand("help " + commandName);

            // then
            TestHelper.AssertContains("Error : This command is not supported by the help utility.", testOutput.ToString());

        }

        [TestMethod]
        public void CmdHelp_NoParameter()
        {
            // given
            const string commandName = "";

            // when
            ExecuteCommand("help" + commandName);

            // then
            TestHelper.AssertContains("All available commands are listed on te sceen as follows :", testOutput.ToString());

        }

        [TestMethod]
        public void CmdHelp_SupportCommand()
        {
            // given
            const string commandName = "LABEL";

            // when
            ExecuteCommand("help " + commandName);

            // then
            TestHelper.AssertContains("Creates,changes,or deletes the volume label of a disk.", testOutput.ToString());

        }
    }
}
