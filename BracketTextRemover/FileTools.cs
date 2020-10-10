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

        //<summary> generates names for the files based on the number of files </summary>
        //Arguments: 
        //           List: OldNames - a list of file paths
        //           int:  OldNameCount - the number of files in that list
        //        String:  path - FilePath
        //Returns: 
        //           List: the list of new file names 

       public List<string> GenerateNewNames(List<string> oldNames, int oldNameCount,string path)
        {
            List<string> newNames = new List<string>();

            for (int i = 0; i < oldNameCount; i++)
            {
                string newName = null;
                string oldName = Path.GetFileName(oldNames[i]); 
                newName = Regex.Replace(oldName, @"[\(\[].*?[\)\]]"," ");
                newName = Regex.Replace(newName,@"[ ]{2,}"," ");
                newName = Regex.Replace(newName,@"^ +","");
                newNames.Add(path + "/" + newName);
            }

            return newNames;
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