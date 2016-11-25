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
            try
            {
                if (GetParameterCount() != 2)
                    outputter.PrintLine("syntax of the command is incorrect type MOVE <filename> <destination>");
                else
                {
                    string fileName = GetParameterAt(0);
                    string destinationName = GetParameterAt(1);

                    File currentFile = null;
                    Directory currentDir = null;

                    File destinationFile = null;
                 


                    IsFileExist(Drive.CurrentDirectory.Name + "\\" + fileName, out currentFile);
                    IsDirectoryExist(Drive.CurrentDirectory.Name + "\\" + fileName, out currentDir);

                    if (currentFile != null)
                        moveFile(currentFile, destinationName);
                    else if(currentDir!= null)
                        moveDir(currentDir, destinationName);
                    else
                        throw new Exception("filename or directory name does not exist");


                    //this.IsFileExist(Drive.CurrentDirectory.Name + "\\" + fileName, out currentFile) == false)
                    //    throw new Exception("currentFile does not exist");

                    //if (this.IsDirectoryExist(destinationName, out destinationDir) == false)
                    //    throw new Exception("Destination directory does not exist");

                    //if (this.IsFileExist(destinationName+"\\"+ fileName, out destinationFile) == true)
                    //    throw new Exception("destination file already exist");

                    //remove file
                    //this.Drive.CurrentDirectory.Remove(currentFile);

                    ////copy
                    //Directory curDir = this.Drive.CurrentDirectory;
                    //this.Drive.ChangeCurrentDirectory(destinationDir);
                    //this.Drive.CurrentDirectory.Add(currentFile);

                    //this.Drive.ChangeCurrentDirectory(curDir);
                }
            }
            catch (Exception ex)
            {
                outputter.PrintLine(ex.Message);
            }
        }

        private void moveDir(Directory currentDir, string destinationName)
        {
            Directory destinationDir = null;

            if (this.IsDirectoryExist(destinationName, out destinationDir) == false)
                throw new Exception("destination directory does not exist");

            //remove file
            this.Drive.CurrentDirectory.Remove(currentDir);

            //copy
            Directory curDir = this.Drive.CurrentDirectory;
            this.Drive.ChangeCurrentDirectory(destinationDir);
            this.Drive.CurrentDirectory.Add(currentDir);

            this.Drive.ChangeCurrentDirectory(curDir);
        }

        private void moveFile(File currentFile, string destinationName)
        {
            Directory destinationDir = null;

            if (this.IsDirectoryExist(destinationName, out destinationDir) == false)
                throw new Exception("destination directory does not exist");

            //remove file
            this.Drive.CurrentDirectory.Remove(currentFile);

            //copy
            Directory curDir = this.Drive.CurrentDirectory;
            this.Drive.ChangeCurrentDirectory(destinationDir);
            this.Drive.CurrentDirectory.Add(currentFile);

            this.Drive.ChangeCurrentDirectory(curDir);
        }

        public bool IsDirectoryExist(string dirName,out Directory output)
        {
            bool result = false;
            FileSystemItem tempo = this.Drive.GetItemFromPath(dirName);

            if (tempo != null && tempo.IsDirectory())
                result = true;

            output = tempo as Directory;

            return result;
        }

        public bool IsFileExist(string name,out File output)
        {
            bool result = false;
            FileSystemItem tempo = this.Drive.GetItemFromPath( name);

            if (tempo != null && tempo.IsDirectory() == false)
                result = true;

            output = tempo as File;

            return result;
        }
    }
}
