using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicViet.Models
{
    public class ListSong
    {
        public int Id { get; set; }
        public string SongTitle { get; set; }
        public string SingerName { get; set; }
        public int? Views { get; set; }
        public string PathMusic { get; set; }

        public string PathSinger { get; set; }
        public int SingerId { get; set; }
    }
}