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
        public SongConstructor City_of_Angels { get; }
        public List<SongConstructor> Songs = new List<SongConstructor>();
        public int currentIndex;

        public MusicHandler()
        {
            AddSong("On My Own", "C:\\Users\\jajin\\Source\\Repos\\LinDesk-Linux-Desktop-Environment-Simulator\\LinDesk-Linux-Desktop-Environment-Simulator\\Music\\On-my-own-Kyle-The-Hooligan.mp3");
            AddSong("CITY OF ANGELS", "C:\\Users\\jajin\\Source\\Repos\\LinDesk-Linux-Desktop-Environment-Simulator\\LinDesk-Linux-Desktop-Environment-Simulator\\Music\\24kGoldn - CITY OF ANGELS (Official Audio).mp3");
                On_My_Own = Songs[0];
                CurrentSong = On_My_Own;
                City_of_Angels = Songs[1];
        }
        public void AddSong(string nazov, string cestaKSuboru)
        {

            Songs.Add(new SongConstructor(TimeSpan.Zero)
            {
                Title = nazov,
                FilePath = cestaKSuboru
            });
        }
    }

}
