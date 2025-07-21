using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    [Table("MusicGenres")]
    public class MusicGenres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicGenresId { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string MusicGenresName { get; set; }
        [Required]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string MusicGenresPic { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar")]
        public string DesMusicGenres { get; set; }

        public virtual ICollection<Song> listSong { get; set; }
    }
}