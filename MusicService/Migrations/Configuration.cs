namespace MusicService.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicService.Models.MusicServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MusicService.Models.MusicServiceContext context)
        {
            context.Labels.AddOrUpdate(new Label[] {
                new Label() { LabelId = 1, Name = "Universal Music Group", FoundationYear = 1934, FounderName = "Lucian Grainge" },
                new Label() { LabelId = 2, Name = "Sony Music Entertainment", FoundationYear = 1929, FounderName = "Doug Morris" },
                new Label() { LabelId = 3, Name = "Warner Music Group", FoundationYear = 1958, FounderName = "Stephen Copper" }
            });

            context.Bands.AddOrUpdate(new Band[] {
                new Band() { BandId = 1, Name = "Avenged Sevenfold", Genre = "Heavy Metal", Country = "United States", LabelRefId = 1 },
                new Band() { BandId = 2, Name = "A B I S M O", Genre = "Stoner Metal", Country = "Brazil", LabelRefId = 1 },
                new Band() { BandId = 3, Name = "Bullet for My Valentine", Genre = "Heavy Metal", Country = "United States", LabelRefId = 1 },
                new Band() { BandId = 4, Name = "Breaking Benjamin", Genre = "Metal", Country = "United States", LabelRefId = 1 },
                new Band() { BandId = 5, Name = "Cannibal Corpse", Genre = "Death Metal", Country = "United States", LabelRefId = 1 },
                new Band() { BandId = 6, Name = "Chevelle", Genre = "Hard Rock", Country = "United States", LabelRefId = 2 },
                new Band() { BandId = 7, Name = "Disturbed", Genre = "Heavy Metal", Country = "United States", LabelRefId = 2 },
                new Band() { BandId = 8, Name = "Dagor Dagorath", Genre = "Symphonic Black Metal", Country = "Israel", LabelRefId = 2 },
                new Band() { BandId = 9, Name = "Eagles of Death Metal", Genre = "Hard Rock", Country = "United States", LabelRefId = 2 },
                new Band() { BandId = 10, Name = "Empyrean Plague", Genre = "Black Metal", Country = "Canada", LabelRefId = 2 },
                new Band() { BandId = 11, Name = "Finch", Genre = "Post-hardcore", Country = "United States", LabelRefId = 3 },
                new Band() { BandId = 12, Name = "F.A.C.E.", Genre = "Progressive Metal", Country = "Bulgaria", LabelRefId = 3 },
                new Band() { BandId = 13, Name = "Goldfinger", Genre = "Punk Rock", Country = "United States", LabelRefId = 3 },
                new Band() { BandId = 14, Name = "Galen", Genre = "Heavy Metal", Country = "Germany", LabelRefId = 3 },
                new Band() { BandId = 15, Name = "Hammerfall", Genre = "Heavy metal", Country = "Sweden", LabelRefId = 3 }
            });

            context.Albums.AddOrUpdate(new Album[] {
                new Album() { AlbumId = 1, Name = "City of Evil", ReleaseYear = 2005, BandRefId = 1 },
                new Album() { AlbumId = 2, Name = "All Beyond Perception", ReleaseYear = 2016, BandRefId = 2 },
                new Album() { AlbumId = 3, Name = "Scream Aim Fire", ReleaseYear = 2007, BandRefId = 3 },
                new Album() { AlbumId = 4, Name = "So Cold", ReleaseYear = 2004, BandRefId = 4 },
                new Album() { AlbumId = 5, Name = "Eaten Back to Life", ReleaseYear = 1990, BandRefId = 5 },
                new Album() { AlbumId = 6, Name = "Hats Off to the Bull", ReleaseYear = 2011, BandRefId = 6 },
                new Album() { AlbumId = 7, Name = "Ten Thousand Fists", ReleaseYear = 2005, BandRefId = 7 },
                new Album() { AlbumId = 8, Name = "Yetzer Ha'ra", ReleaseYear = 2009, BandRefId = 8 },
                new Album() { AlbumId = 9, Name = "Peace, Love, Death Metal", ReleaseYear = 2009, BandRefId = 9 },
                new Album() { AlbumId = 10, Name = "Conquering the Elements", ReleaseYear = 2004, BandRefId = 10 },
                new Album() { AlbumId = 11, Name = "Say Hello to Sunshine", ReleaseYear = 2005, BandRefId = 11 },
                new Album() { AlbumId = 12, Name = "A New Light", ReleaseYear = 2005, BandRefId = 12 },
                new Album() { AlbumId = 13, Name = "Stomping Ground", ReleaseYear = 2000, BandRefId = 13 },
                new Album() { AlbumId = 14, Name = "The Blind lead the Blind", ReleaseYear = 1993, BandRefId = 14 },
                new Album() { AlbumId = 15, Name = "Chapter V: Unbent, Unbowed, Unbroken", ReleaseYear = 2005, BandRefId = 15 }
            });

            context.Tracks.AddOrUpdate(new Track[] {
                new Track() { TrackId = 1, Name = "Beast and the Harlot", Lenght = "5:42", Number = 1, AlbumRefId = 1 },
                new Track() { TrackId = 2, Name = "Burn It Down", Lenght = "5:00", Number = 2, AlbumRefId = 1 },
                new Track() { TrackId = 3, Name = "Blinded in Chains", Lenght = "6:34", Number = 3, AlbumRefId = 1 },
                new Track() { TrackId = 4, Name = "Bat Country", Lenght = "5:13", Number = 4, AlbumRefId = 1 },
                new Track() { TrackId = 5, Name = "Trashed and Scattered", Lenght = "5:53", Number = 5, AlbumRefId = 1 },
                new Track() { TrackId = 6, Name = "Seize the Day", Lenght = "5:32", Number = 6, AlbumRefId = 1 },
                new Track() { TrackId = 7, Name = "Sidewinder", Lenght = "7:01", Number = 7, AlbumRefId = 1 },
                new Track() { TrackId = 8, Name = "The Wicked End", Lenght = "7:10", Number = 8, AlbumRefId = 1 },
                new Track() { TrackId = 9, Name = "Strength of the World", Lenght = "9:14", Number = 9, AlbumRefId = 1 },
                new Track() { TrackId = 10, Name = "Betrayed", Lenght = "6:47", Number = 10, AlbumRefId = 1 },
                new Track() { TrackId = 11, Name = "M.I.A.", Lenght = "8:48", Number = 11, AlbumRefId = 1 }
            });
        }
    }
}
