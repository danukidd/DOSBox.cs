// DOSBox, Scrum.org, Professional Scrum Developer Training
// Authors: Rainer Grau, Daniel Tobler, Zühlke Technology Group
// Copyright (c) 2012 All Right Reserved

using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdMkFile : DosCommand
    {
        public CmdMkFile(string cmdName, IDrive drive)
            : base(cmdName, drive)
        {
        }

        public override void Execute(IOutputter outputter)
        {
            if (GetParameterCount() == 0)
                outputter.PrintLine("syntax of the command is incorrect");
            else
            {
                string fileName = GetParameterAt(0);
                File newFile = null;

                if (GetParameterCount() > 1)// GetParameterAt(1) != null)
                {
                    string fileContent = GetParameterAt(1);
                    newFile = new File(fileName, fileContent);
                }
                else
                {
                    newFile = new File(fileName, "");
                }

                FileSystemItem tempo = this.Drive.GetItemFromPath(this.Drive.CurrentDirectory.Path + "\\" + fileName);
                if (tempo != null)
                    this.Drive.CurrentDirectory.Remove(tempo);


                this.Drive.CurrentDirectory.Add(newFile);
            }
        }
    }
}