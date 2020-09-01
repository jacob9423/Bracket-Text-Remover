using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketTextRemover
{
    class Data
    {
        public List<string> OldFileNames { get; set; }
        public List<string> NewFileNames { get; set; }
        public string Path { get; set; }
        public string PWD { get; set; } // for opening up directory viewer in the path that was previously selected
        public string FileType { get; set; }
        public int NumOfFiles { get; set; }
        public bool NoPath = true;
    }
}