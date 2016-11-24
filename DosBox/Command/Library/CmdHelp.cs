using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    /// <summary>
    /// Command to show Help.
    /// Example for a command with optional parameters.
    /// </summary>
    public class CmdHelp : DosCommand
    {

        Dictionary<string, string> dictHelp;
        public CmdHelp(string name, IDrive drive)
            : base(name, drive)
        {
            //initial
            dictHelp = new Dictionary<string, string>();
            dictHelp.Add("cd", "Displays the name of or changes the current directory.");
            dictHelp.Add("dir", "Displays a list of files and subdirectories in a directory.");
            dictHelp.Add("exit", "Quits the CMD.EXE program (Command interpreter).");
            dictHelp.Add("format", "Formats a disk for use with windows.");
            dictHelp.Add("help", "Provides Help information for Windows Commnad.");
            dictHelp.Add("label", "Creates,changes,or deletes the volume label of a disk.");
            dictHelp.Add("mkdir", "Creates a directory.");
            dictHelp.Add("mkfile", "Creates a file.");
            dictHelp.Add("move", "Move one or more files from one directory to another directory.");
           
        }



        public override void Execute(IOutputter outputter)
        {

            if (GetParameterCount() == 0)
            {

                outputter.PrintLine("All available commands are listed on te sceen as follows : \n");
                foreach (KeyValuePair<string, string> entry in dictHelp)
                {
                    outputter.PrintLine(entry.Key.ToUpper() + "\t" + entry.Value);
                }

            }
            else
            {
                string commandName = GetParameterAt(0).ToLower();
                string commandDesc = "";
                bool hasValue = dictHelp.TryGetValue(commandName, out commandDesc);
                if (hasValue)
                {
                    outputter.PrintLine(commandName.ToUpper() + "\t" + commandDesc);
                }
                else
                {
                    outputter.Print("Error : This command is not supported by the help utility.");
                }

               

            }
                 
        }

       
    }
}
