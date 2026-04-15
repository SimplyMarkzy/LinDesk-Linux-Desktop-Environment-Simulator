using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class DirectoryConstructor
    {
        public string DirectoryName { get; set; }
        public DirectoryConstructor? ParentDirectory { get; set; }
        public List<DirectoryConstructor> SubDirectories { get; set; }
        public List<string> Files { get; set; }

        public DirectoryConstructor(string directoryName, DirectoryConstructor? parentDirectory)
        {
            DirectoryName = directoryName;
            ParentDirectory = parentDirectory;

            SubDirectories = new List<DirectoryConstructor>();
            Files = new List<string>();
        }
    }

}

