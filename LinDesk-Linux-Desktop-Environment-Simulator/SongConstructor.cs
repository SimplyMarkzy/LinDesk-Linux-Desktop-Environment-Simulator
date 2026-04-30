using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TagLib;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class SongConstructor
    {

        public string Title { get; set; }
        public string Artist { get; set; }
        public string FilePath { get; set; }
        public TimeSpan Duration { get; set; }
        public Image AlbumArt { get; set; }
        public SongConstructor(TimeSpan duration)
        {
            Duration = duration;
        }

        public SongConstructor LoadSong(string path)
        {
            var file = TagLib.File.Create(path);

            return new SongConstructor(file.Properties.Duration)
            {
                FilePath = path,

                Title = string.IsNullOrWhiteSpace(file.Tag.Title)
                    ? System.IO.Path.GetFileNameWithoutExtension(path)
                    : file.Tag.Title,

                Artist = file.Tag.FirstPerformer ?? "Unknown"
            };
        }

    }
}
