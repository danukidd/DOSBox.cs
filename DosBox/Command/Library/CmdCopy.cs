using System.Collections.Generic;
using System;
using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdCopy : DosCommand
    {
        private readonly string SYSTEM_CANNOT_FIND_THE_PATH_SPECIFIED = "Destination can not be found or is not a directory";
        private readonly string SYSTEM_CANNOT_FIND_THE_FILE_SPECIFIED = "File to be copied is not found or is directory";
        private Directory destinantionDirectory;
        private File fileToCopy;
        private bool isOverwrite;

        public CmdCopy(string name, IDrive drive)
            : base(name, drive)
        {
        }

        //protected override bool CheckNumberOfParameters(int numberOfParameters)
        //{
        //    return numberOfParameters == 2 || numberOfParameters == 3;
        //}

        protected override bool CheckParameterValues(IOutputter outputter)
        {
            if (GetParameterCount() >= 2)
            {
                fileToCopy = CheckIsFileAndExist(GetParameterAt(0), outputter);
                destinantionDirectory = CheckIsDirectoryAndExist(GetParameterAt(1), outputter);
                if (GetParameterCount() == 3)
                    isOverwrite = GetParameterAt(2).ToUpper() == "/Y" ? true : false;
            }
            return this.fileToCopy != null && this.destinantionDirectory != null;
        }

        private Directory CheckIsDirectoryAndExist(string pathName, IOutputter outputter)
        {
            FileSystemItem fsi = Drive.GetItemFromPath(pathName);
            if (fsi == null || !fsi.IsDirectory())
            {
                outputter.PrintLine(SYSTEM_CANNOT_FIND_THE_PATH_SPECIFIED);
                return null;
            }
            return (Directory)fsi;
        }

        private File CheckIsFileAndExist(string pathName, IOutputter outputter)
        {
            FileSystemItem fsi = Drive.GetItemFromPath(Drive.CurrentDirectory.Path + "\\" + pathName);
            if (fsi == null || fsi.IsDirectory())
            {
                outputter.PrintLine(SYSTEM_CANNOT_FIND_THE_FILE_SPECIFIED);
                return null;
            }
            return (File)fsi;
        }

        public override void Execute(IOutputter outputter)
        {
            try
            {
                if (fileToCopy != null && destinantionDirectory != null)
                {
                    File newfile = new File(fileToCopy.Name, fileToCopy.FileContent);
                    FileSystemItem currentFile = this.Drive.GetItemFromPath(destinantionDirectory.Path + "\\" + newfile.Name);
                    if (currentFile != null)
                    { 
                        if (!isOverwrite)
                            throw new Exception("File already exists in " + destinantionDirectory.Path);
                        else
                            destinantionDirectory.Remove(currentFile);
                    }

                    destinantionDirectory.Add(newfile);
                }
            }
            catch (Exception ex)
            {
                outputter.PrintLine(ex.Message);
            }
        }
    }
}
