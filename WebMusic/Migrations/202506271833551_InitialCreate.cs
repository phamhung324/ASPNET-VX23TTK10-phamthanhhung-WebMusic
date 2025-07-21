namespace MusicViet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Username = c.String(nullable: false, maxLength: 64, unicode: false),
                        Password = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Avatar = c.String(maxLength: 255, unicode: false),
                        IsAdmin = c.Byte(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        SongId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FavoriteId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => new { t.SongId, t.UserId })
                .ForeignKey("dbo.Account", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Song", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        SongTitle = c.String(nullable: false, maxLength: 100),
                        MusicianId = c.Int(nullable: false),
                        SingerId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        MusicGenresId = c.Int(nullable: false),
                        PathMusic = c.String(maxLength: 100, unicode: false),
                        DateUpload = c.DateTime(storeType: "date"),
                        Views = c.Int(),
                        WhoUp = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.MusicGenres", t => t.MusicGenresId, cascadeDelete: true)
                .ForeignKey("dbo.Musician", t => t.MusicianId, cascadeDelete: true)
                .ForeignKey("dbo.Singer", t => t.SingerId, cascadeDelete: true)
                .Index(t => t.MusicianId)
                .Index(t => t.SingerId)
                .Index(t => t.AlbumId)
                .Index(t => t.MusicGenresId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumTitle = c.String(nullable: false, maxLength: 100),
                        AblumPhoto = c.String(nullable: false, maxLength: 255, unicode: false),
                        DesAlbum = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.MusicGenres",
                c => new
                    {
                        MusicGenresId = c.Int(nullable: false, identity: true),
                        MusicGenresName = c.String(nullable: false, maxLength: 100),
                        MusicGenresPic = c.String(nullable: false, maxLength: 255, unicode: false),
                        DesMusicGenres = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.MusicGenresId);
            
            CreateTable(
                "dbo.Musician",
                c => new
                    {
                        MusicianId = c.Int(nullable: false, identity: true),
                        MusicianName = c.String(nullable: false, maxLength: 255),
                        MusicianPic = c.String(nullable: false, maxLength: 255, unicode: false),
                        MusicianStory = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.MusicianId);
            
            CreateTable(
                "dbo.Singer",
                c => new
                    {
                        SingerId = c.Int(nullable: false, identity: true),
                        SingerName = c.String(nullable: false, maxLength: 255),
                        SingerPic = c.String(nullable: false, maxLength: 255, unicode: false),
                        SingerStory = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.SingerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "SingerId", "dbo.Singer");
            DropForeignKey("dbo.Song", "MusicianId", "dbo.Musician");
            DropForeignKey("dbo.Song", "MusicGenresId", "dbo.MusicGenres");
            DropForeignKey("dbo.Favorite", "SongId", "dbo.Song");
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Favorite", "UserId", "dbo.Account");
            DropIndex("dbo.Song", new[] { "MusicGenresId" });
            DropIndex("dbo.Song", new[] { "AlbumId" });
            DropIndex("dbo.Song", new[] { "SingerId" });
            DropIndex("dbo.Song", new[] { "MusicianId" });
            DropIndex("dbo.Favorite", new[] { "UserId" });
            DropIndex("dbo.Favorite", new[] { "SongId" });
            DropTable("dbo.Singer");
            DropTable("dbo.Musician");
            DropTable("dbo.MusicGenres");
            DropTable("dbo.Album");
            DropTable("dbo.Song");
            DropTable("dbo.Favorite");
            DropTable("dbo.Account");
        }
    }
}
