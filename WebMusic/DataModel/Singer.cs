using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    [Table("Singer")]
    public class Singer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SingerId { get; set; }

        [Required(ErrorMessage = "Enter full name, please")]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Ten ca si")]
        public string SingerName { get; set; }
        [Required]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Anh dai dien")]
        public string SingerPic { get; set; }

        [StringLength(1000)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tieu su ca si")]
        public string SingerStory { get; set; }
        public virtual ICollection<Song> listSong { get; set; }
    }
}