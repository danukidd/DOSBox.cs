using DosBox.Command.Library;
using DosBox.Filesystem;
using DosBoxTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DosBoxTest.Command.Library
{
    [TestClass]
    public class CmdMoveTest : CmdTest
    {
        [TestInitialize]
        public void setUp()
        {
            // Check this filestructure in base class: crucial to understand the tests.
            this.CreateTestFileStructure();

            // Add all commands which are necessary to execute this unit test
            // Important: Other commands are not available unless added here.
            commandInvoker.AddCommand(new CmdMkFile("move", drive));
            commandInvoker.AddCommand(new CmdMkFile("mkfile", drive));
            commandInvoker.AddCommand(new CmdMkFile("mkdir", drive));
            commandInvoker.AddCommand(new CmdMkFile("cd", drive));


            ExecuteCommand("mkdir dd");
            ExecuteCommand("mkfile file.t");
            ExecuteCommand("mkfile file2.t");
            ExecuteCommand("cd dd");
            ExecuteCommand("mkfile file2.t");
            ExecuteCommand("cd ..");
        }

        //[TestMethod]
        //public void CmdMkFile_CreatesNewFile()
        //{
        //    // given
        //    const string newFileName = "testFile";

        //    // when
        //    ExecuteCommand("mkfile " + newFileName);

        //    // then
        //    Assert.AreEqual(numbersOfFilesBeforeTest + 1, drive.CurrentDirectory.GetNumberOfContainedFiles());
        //    TestHelper.AssertOutputIsEmpty(testOutput);
        //    File createdFile = TestHelper.GetFile(drive, drive.CurrentDirectory.Path, newFileName);
        //    Assert.IsNotNull(createdFile);
        //}

        //[TestMethod]
        //public void CmdMkFile_WithoutContent_CreatesEmptyFile()
        //{
        //    // given
        //    const string newFileName = "testFile";

        //    // when
        //    ExecuteCommand("mkfile " + newFileName);

        //    // then
        //    File createdFile = TestHelper.GetFile(drive, drive.CurrentDirectory.Path, newFileName);
        //    Assert.AreEqual("", createdFile.FileContent);
        //}

        //[TestMethod]
        //public void CmdMkFile_WithContent_CreatesFileWithContent()
        //{
        //    // given
        //    const string newFileName = "testFile";
        //    const string newFileContent = "ThisIsTheContent";

        //    // when
        //    ExecuteCommand("mkfile " + newFileName + " " + newFileContent);

        //    // then
        //    Assert.AreEqual(numbersOfFilesBeforeTest + 1, drive.CurrentDirectory.GetNumberOfContainedFiles());
        //    TestHelper.AssertOutputIsEmpty(testOutput);
        //    File createdFile = TestHelper.GetFile(drive, drive.CurrentDirectory.Path, newFileName);
        //    Assert.AreEqual(newFileContent, createdFile.FileContent);
        //}

        [TestMethod]
        public void CmdMove_WrongParameters_ReportsError()
        {
            ExecuteCommand("move");
            //Assert.AreEqual(numbersOfFilesBeforeTest, drive.CurrentDirectory.GetNumberOfContainedFiles());
            TestHelper.AssertContains("syntax of the command is incorrect", testOutput.ToString());
        }

        [TestMethod]
        public void CmdMove_AlreadyExist()
        {
            ExecuteCommand("move file2.t c:\\dd");
            //Assert.AreEqual(numbersOfFilesBeforeTest + 1, drive.CurrentDirectory.GetNumberOfContainedFiles());
            TestHelper.AssertContains("destination file already", testOutput.ToString());
        }
    }
}
