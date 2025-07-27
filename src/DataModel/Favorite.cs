using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    [Table("Favorite")]
    public class Favorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FavoriteId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int SongId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }

        public virtual Song song { get; set; }
        public virtual Account account { get; set; }

    }
}