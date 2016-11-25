using System.Collections.Generic;
using System;
using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdMove : DosCommand
    {
        public CmdMove(string name, IDrive drive)
            : base(name, drive)
        {
            
        }

        public override void Execute(IOutputter outputter)
        {

        }
    }
}
