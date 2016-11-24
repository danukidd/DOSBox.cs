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
    public class CmdVer : DosCommand
    {

        Dictionary<string, string> dictHelp;
        public CmdVer(string name, IDrive drive)
            : base(name, drive)
        {
            //initial
            dictHelp = new Dictionary<string, string>();
            dictHelp.Add("Addy Wahyu F", "addy@bps.go.id.");
            dictHelp.Add("Danuk Cahya P", "danuk@bps.go.id.");
            dictHelp.Add("Herman Saputra", "hsaputra@bps.go.id.");
            dictHelp.Add("Miswar \t", "miswar@bps.go.id.");         
        }



        public override void Execute(IOutputter outputter)
        {
            
            if (GetParameterCount() == 0)
            {

                outputter.PrintLine("Microsoft Windows XP [Version 5.1.2600] \n");
            }
            else if (GetParameterCount() == 1 && GetParameterAt(0).ToUpper() == "/W")
            {
                outputter.PrintLine("Microsoft Windows XP [Version 5.1.2600] \n");
                foreach (KeyValuePair<string, string> entry in dictHelp)
                {
                    outputter.PrintLine(entry.Key.ToUpper() + "\t" + entry.Value);
                }



            }
                 
        }

       
    }
}
