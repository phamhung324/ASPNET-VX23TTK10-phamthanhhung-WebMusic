using MusicViet.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicViet.Models
{
    public class Artist
    {
        public string NameArtist { get; set; }
        public string PathArtist { get; set; }

        public string Story { get; set; }
        public IEnumerable<Song> listSong { get; set; }
    }
}