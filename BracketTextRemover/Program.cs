using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace BracketTextRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                ConRed();
                Console.WriteLine("please enter a path. Or PWD for the current directory you are in");
            }
            else if(Directory.Exists(args[0]))
            {
                ProgramStart(args[0]);
            }
            else if(args[0] == "PWD")
            {
                ProgramStart(Directory.GetCurrentDirectory());
            }
            else
            {
                manual();
            }
        }
        //<summary> Starts the program. must provid path)
        private static void ProgramStart(string path)
        {
            bool userChoiceBool = false;
            string userChoice;
            string ConString = "-----------------------------------------";
            FileTools app = new FileTools();
            app.FileData.Path = path;

            app.GetFileList(); 
            do
            {
                ConGreen();
                Console.WriteLine("Currrent Files");
                Console.WriteLine(ConString);
                ConResetColor();

                DisplayList(app.FileData.OldFileNames);
                Console.WriteLine(ConString);

                Console.Write("Are you sure you want to rename? Y/N: ");
                userChoice = Console.ReadLine();

                if(userChoice.ToUpper() == "Y")
                {
                    app.FileData.NewFileNames = app.GenerateNewNames(app.FileData.OldFileNames,app.FileData.OldFileNames.Count());
                    app.RenameFiles();

                    ConGreen();
                    Console.WriteLine("Files renamed:");
                    Console.WriteLine(ConString);
                    ConResetColor();

                    DisplayList(app.FileData.NewFileNames);
                    userChoiceBool = true;
                }
                else if (userChoice.ToUpper() == "N")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    ConRed();
                    Console.WriteLine("Please Enter Y/N");
                    ConResetColor();
                }
            }
            while(!userChoiceBool);
        }

            
        //<summary> List To dispaly. String ver </summary>
        private static void DisplayList(List<string> ListToDisplay)
        {
            foreach(var i in ListToDisplay)
            {
                Console.WriteLine(i);
            }
        }
        private static void ConGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        private static void ConRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        private static void ConResetColor()
        {
            Console.ResetColor();
        }
        private static void manual()
        {
            ConGreen();
            Console.WriteLine("Bracket Text Remover Manual");
            Console.WriteLine("-----------------------------------------");
            ConResetColor();
            Console.WriteLine("Command Line Arguments:");
            Console.WriteLine("To give the program a file path just give it a directory. EX BracketTextRemover /some/path/");
            Console.WriteLine("PWD: The PWD argument will use the current working directory to rename the files. EX BracketTextRemover PWD");
        }
    }
}
