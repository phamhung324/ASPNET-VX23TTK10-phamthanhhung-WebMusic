using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
       
        [Required(ErrorMessage = "Enter full name, please")]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Ho va ten")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Enter username, please")]
        [StringLength(64, ErrorMessage = "Username must from 3-64 character length")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Ten dang nhap")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter password, please")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Mat khau")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter email, please")]
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Thong tin email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Anh dai dien")]
        public string Avatar { get; set; }

        [Display(Name = "La quan tri")]
        public byte? IsAdmin { get; set; }

        //Thuoc tinh Navigation

        public virtual ICollection<Favorite> favorite { get; set; }


    }
}