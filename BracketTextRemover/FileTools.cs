using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace BracketTextRemover
{
    class FileTools
    {
        public Data FileData = new Data();

        //<summary> Gets the list of files in a directory. and puts them in there internal varibles </summary>
        // For everything to work I need the number of files in that directory, The file paths, the ext, and then
        // order them starting from episode 0
        // Arguments: None
        // Returns:   None
        public void GetFileList()
        {
            FileData.NumOfFiles = Directory.GetFiles(FileData.Path).Count();
            FileData.OldFileNames = Directory.GetFiles(FileData.Path).ToList();
        }

        //<summary> gets the file ext form the first postion of a list of file paths </summary>
        // Arguments: 
        //            FileNames - A list of file names
        // Returns:   None
        public string GetExt(List<string> FileNames)
        {
            return Path.GetExtension(FileNames[0]);
        }

        //<summary> generates names for the files based on the number of files </summary>
        //Arguments: 
        //           List: OldNames - a list of file paths
        //           int:  OldNameCount - the number of files in that list
        //        String:  path - FilePath
        //Returns: 
        //           List: the list of new file names 

       public List<string> GenerateNewNames(List<string> OldNames, int OldNameCount,string path)
        {
            List<string> NewNames = new List<string>();

            for (int i = 0; i < OldNameCount; i++)
            {
                string NewName = null;
                string OldName = Path.GetFileName(OldNames[i]); 
                NewName = Regex.Replace(OldName, @"[\(\[].*?[\)\]]"," ");
                NewName = Regex.Replace(NewName,@"[ ]{2,}"," ");
                NewName = Regex.Replace(NewName,@"^ +","");
                NewNames.Add(path + "/" + NewName);
            }

            return NewNames;
        } 

      
        // <summary> Renames the files in the directory </summary>
        // Arguments: None
        // Returns: None
        public void RenameFiles()
        {
            for (int i = 0; i < FileData.NumOfFiles; i++)
            {
                System.IO.File.Move(FileData.OldFileNames[i], FileData.NewFileNames[i]);
            }
        }
    }
}