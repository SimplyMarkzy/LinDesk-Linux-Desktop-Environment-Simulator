using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class DirectoryHandler
    {
        public DirectoryConstructor Root { get; }
        public DirectoryConstructor Home { get; }

        public DirectoryHandler()
        {
            Root = new DirectoryConstructor("/", null); //root directory
            Home = new DirectoryConstructor("home", Root);
            Root.SubDirectories.Add(Home);
            Root.Files.Add("test.txt");
        }
    }
}
