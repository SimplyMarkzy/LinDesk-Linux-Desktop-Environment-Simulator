using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class FileConstructor
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public FileConstructor(string name)
        {
            Name = name;
            Content = "";
        }
    }
}
