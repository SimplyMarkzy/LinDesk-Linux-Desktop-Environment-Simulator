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
        public FileConstructor Test { get; }
        public DirectoryHandler()
        {
            Root = new DirectoryConstructor("/", null); //root directory
            Home = new DirectoryConstructor("home", Root);
            Root.SubDirectories.Add(Home);
            Test = new FileConstructor("test.txt");
            Test.Content = "This is a test file.";
            Root.Files.Add(Test);
        }
    }
}
