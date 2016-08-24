namespace MusicService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        BandRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Bands", t => t.BandRefId, cascadeDelete: true)
                .Index(t => t.BandRefId);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        BandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Genre = c.String(),
                        Country = c.String(),
                        LabelRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BandId)
                .ForeignKey("dbo.Labels", t => t.LabelRefId, cascadeDelete: true)
                .Index(t => t.LabelRefId);
            
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        LabelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FoundationYear = c.Int(nullable: false),
                        FounderName = c.String(),
                    })
                .PrimaryKey(t => t.LabelId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lenght = c.String(),
                        Number = c.Int(nullable: false),
                        AlbumRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Albums", t => t.AlbumRefId, cascadeDelete: true)
                .Index(t => t.AlbumRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "AlbumRefId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "BandRefId", "dbo.Bands");
            DropForeignKey("dbo.Bands", "LabelRefId", "dbo.Labels");
            DropIndex("dbo.Tracks", new[] { "AlbumRefId" });
            DropIndex("dbo.Bands", new[] { "LabelRefId" });
            DropIndex("dbo.Albums", new[] { "BandRefId" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Labels");
            DropTable("dbo.Bands");
            DropTable("dbo.Albums");
        }
    }
}
