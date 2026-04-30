using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class MusicHandler
    {
        public SongConstructor CurrentSong { get; set; }
        public SongConstructor On_My_Own { get; }
        public List<SongConstructor> Songs = new List<SongConstructor>();
        public int currentIndex;
  
        public MusicHandler()
        { 
           
        }

    }

}
