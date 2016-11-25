// DOSBox, Scrum.org, Professional Scrum Developer Training
// Authors: Rainer Grau, Daniel Tobler, Zühlke Technology Group
// Copyright (c) 2012 All Right Reserved

using System.Diagnostics;
using DosBox.Command.Library;
using DosBox.Filesystem;
using DosBoxTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DosBoxTest.Command.Library
{
    [TestClass]
    public class CmdExitTest : CmdTest
    {
        [TestInitialize]
        public void SetUp()
        {
            // Check this file structure in base class: crucial to understand the tests.
            this.CreateTestFileStructure();

            // Add all commands which are necessary to execute this unit test
            // Important: Other commands are not available unless added here.
            commandInvoker.AddCommand(new CmdExit("exit", drive));
        }

        //[TestMethod]
        //public void CmdCd_Exit()
        //{
        //    ExecuteCommand("exit");
        //    TestHelper.AssertOutputIsEmpty(testOutput);
        //}

        //[TestMethod]
        //public void CmdCd_ExitGugus()
        //{
        //    ExecuteCommand("exit gugus");
        //    TestHelper.AssertOutputIsEmpty(testOutput);
        //}

        [TestMethod]
        public void CmdCd_Exit1()
        {
            ExecuteCommand("exit1");
            
            TestHelper.AssertContains("'exit1' is not recognized", testOutput.ToString());
        }

        
    }
}