using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    [Table("Song")]
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }

        [Required(ErrorMessage = "Enter a song title, please")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Ten bai hat")]
        public string SongTitle { get; set; }

        [Display(Name = "Ma Nhac Si")]
        public int MusicianId { get; set; }

        [Display(Name = "Ma Ca Si")]
        public int SingerId { get; set; }



        public int AlbumId { get; set; }

        public int MusicGenresId { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string PathMusic { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DateUpload { get; set; }
        [DefaultValue(0)]
        public int? Views { get; set; }
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string WhoUp { get; set; }
        public Musician Musicians { get; set; }
        public Singer Singer { get; set; }

        public Album Album { get; set; }

        public MusicGenres MusicGenres { get; set; }


        public virtual ICollection<Favorite> listFavorite { get; set; }

    }
}