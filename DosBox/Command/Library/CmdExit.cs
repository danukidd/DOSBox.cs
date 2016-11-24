// DOSBox, Scrum.org, Professional Scrum Developer Training
// Authors: Rainer Grau, Daniel Tobler, Zühlke Technology Group
// Copyright (c) 2012 All Right Reserved

using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdExit : DosCommand
    {
        public CmdExit(string cmdName, IDrive drive)
            : base(cmdName, drive)
        {
        }

        public override void Execute(IOutputter outputter)
        {
            if (GetParameterCount() == 0)
            {
                //outputter.PrintLine("EXIT");
                System.Environment.Exit(0);
            }

            else if (GetParameterCount() == 1 &&
                GetParameterAt(0).ToUpper() == "GUGUS")
                System.Environment.Exit(0);
        }
    }
}