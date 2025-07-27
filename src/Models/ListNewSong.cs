using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicViet.Models
{
    public class ListNewSong
    {
        public int id { get; set; }
        public string SongTitle { get; set; }
        public string SingerName { get; set; }
        public int SingerId{get;set;}
        public DateTime? DateUpload { get; set; }
    }
}