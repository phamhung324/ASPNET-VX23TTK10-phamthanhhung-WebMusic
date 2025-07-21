using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicViet.DataModel
{
    public class MusicDbContext: DbContext
    {
        public MusicDbContext()
            : base("MusicVietConStr")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<MusicGenres> MusicGenres { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}