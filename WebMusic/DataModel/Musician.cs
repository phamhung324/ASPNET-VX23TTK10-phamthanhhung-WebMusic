using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    [Table("Musician")]
    public class Musician
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicianId { get; set; }

        [Required(ErrorMessage = "Enter full name, please")]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Ten nhac si")]
        public string MusicianName { get; set; }
        [Required]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Anh dai dien")]
        public string MusicianPic { get; set; }

        [StringLength(1000)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tieu su nhac si")]
        public string MusicianStory { get; set; }
 
        public virtual ICollection<Song> listSong { get; set; }
    }
}