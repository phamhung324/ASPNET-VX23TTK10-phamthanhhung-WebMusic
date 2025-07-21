using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    [Table("Album")]
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string AlbumTitle { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string AblumPhoto { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar")]
        public string DesAlbum { get; set; }

        public virtual ICollection<Song> listSong { get; set; }

    }
}