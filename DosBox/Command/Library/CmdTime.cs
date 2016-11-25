// DOSBox, Scrum.org, Professional Scrum Developer Training
// Authors: Rainer Grau, Daniel Tobler, Zühlke Technology Group
// Copyright (c) 2012 All Right Reserved

using System.Collections.Generic;
using System;
using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdTime : DosCommand
    {
        private static readonly string COMMAND_REJECTED = "Command rejected";

        private static List<String> param;

        public CmdTime(string name, IDrive drive)
            : base(name, drive)
        {
            param = new List<string>(new string[] { "21:30:10", "gaga" });
        }

        protected override bool CheckNumberOfParameters(int numberOfParameters)
        {
            return numberOfParameters == 0 || numberOfParameters == 1;
        }

        //protected override bool CheckParameterValues(IOutputter outputter)
        //{
        //    if (GetParameterCount() == 0 || GetParameterCount() == 1 && param.Contains(GetParameterAt(0).ToLower()))
        //        return true;
        //    return false;
        //}

        public override void Execute(IOutputter outputter)
        {
            if (GetParameterCount() == 0)
            {
                PrintTime(DateTime.Now, outputter);
            }
            else if (GetParameterCount() == 1)
            {
                switch (GetParameterAt(0).ToLower())
                {
                    case "gaga":
                        PrintError(outputter);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintTime(DateTime timeToshow, IOutputter outputter)
        {
            outputter.PrintLine(timeToshow.ToString());
            //outputter.NewLine();
        }

        private static void PrintError(IOutputter outputter)
        {
            outputter.PrintLine(COMMAND_REJECTED);
            //outputter.NewLine();
        }
    }
}