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
                new Band() { BandId = 15, Name = "Hammerfall", Genre = "Heavy Metal", Country = "Sweden", LabelRefId = 3 }
            });

            context.Albums.AddOrUpdate(new Album[] {
                new Album() { AlbumId = 1, Name = "City of Evil", ReleaseYear = 2005, BandRefId = 1 },
                new Album() { AlbumId = 2, Name = "All Beyond Perception", ReleaseYear = 2016, BandRefId = 2 },
                new Album() { AlbumId = 3, Name = "Scream Aim Fire", ReleaseYear = 2007, BandRefId = 3 },
                new Album() { AlbumId = 4, Name = "We Are Not Alone", ReleaseYear = 2004, BandRefId = 4 },
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
                new Album() { AlbumId = 15, Name = "Chapter V: Unbent, Unbowed, Unbroken", ReleaseYear = 2005, BandRefId = 15 },
                new Album() { AlbumId = 16, Name = "Glory to the Brave", ReleaseYear = 1997, BandRefId = 15 }
            });

            context.Tracks.AddOrUpdate(new Track[] {
                // City of Evil
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
                new Track() { TrackId = 11, Name = "M.I.A.", Lenght = "8:48", Number = 11, AlbumRefId = 1 },
                // All Beyond Perception
                new Track() { TrackId = 12, Name = "Protofuture", Lenght = "5:42", Number = 1, AlbumRefId = 2 },
                new Track() { TrackId = 13, Name = "The Edge", Lenght = "5:00", Number = 2, AlbumRefId = 2 },
                new Track() { TrackId = 14, Name = "Beyond the Red", Lenght = "6:34", Number = 3, AlbumRefId = 2 },
                new Track() { TrackId = 15, Name = "Miragem", Lenght = "5:13", Number = 4, AlbumRefId = 2 },
                new Track() { TrackId = 16, Name = "Onironaut", Lenght = "5:53", Number = 5, AlbumRefId = 2 },
                new Track() { TrackId = 17, Name = "The Right to be Forgotten", Lenght = "5:32", Number = 6, AlbumRefId = 2 },
                new Track() { TrackId = 18, Name = "L.u.p.i", Lenght = "7:01", Number = 7, AlbumRefId = 2 },
                new Track() { TrackId = 19, Name = "Sun", Lenght = "7:10", Number = 8, AlbumRefId = 2 },
                // Scream Aim Fire
                new Track() { TrackId = 20, Name = "Scream Aim Fire", Lenght = "5:42", Number = 1, AlbumRefId = 3 },
                new Track() { TrackId = 21, Name = "Eye of the Storm", Lenght = "5:00", Number = 2, AlbumRefId = 3 },
                new Track() { TrackId = 22, Name = "Hearts Burst into Fire", Lenght = "6:34", Number = 3, AlbumRefId = 3 },
                new Track() { TrackId = 23, Name = "Waking the Demon", Lenght = "5:13", Number = 4, AlbumRefId = 3 },
                new Track() { TrackId = 24, Name = "Disappear", Lenght = "5:53", Number = 5, AlbumRefId = 3 },
                new Track() { TrackId = 25, Name = "Deliver Us from Evil", Lenght = "5:32", Number = 6, AlbumRefId = 3 },
                new Track() { TrackId = 26, Name = "Take It Out on Me", Lenght = "7:01", Number = 7, AlbumRefId = 3 },
                new Track() { TrackId = 27, Name = "Say Goodnight", Lenght = "7:10", Number = 8, AlbumRefId = 3 },
                new Track() { TrackId = 28, Name = "End of Days", Lenght = "9:14", Number = 9, AlbumRefId = 3 },
                new Track() { TrackId = 29, Name = "Last to Know", Lenght = "6:47", Number = 10, AlbumRefId = 3 },
                new Track() { TrackId = 30, Name = "Forever and Always", Lenght = "8:48", Number = 11, AlbumRefId = 3 },
                // We Are Not Alone
                new Track() { TrackId = 31, Name = "So Cold", Lenght = "5:42", Number = 1, AlbumRefId = 4 },
                new Track() { TrackId = 32, Name = "Simple Design", Lenght = "5:00", Number = 2, AlbumRefId = 4 },
                new Track() { TrackId = 33, Name = "Follow", Lenght = "6:34", Number = 3, AlbumRefId = 4 },
                new Track() { TrackId = 34, Name = "Firefly", Lenght = "5:13", Number = 4, AlbumRefId = 4 },
                new Track() { TrackId = 35, Name = "Break My Fall", Lenght = "5:53", Number = 5, AlbumRefId = 4 },
                new Track() { TrackId = 36, Name = "Forget It", Lenght = "5:32", Number = 6, AlbumRefId = 4 },
                new Track() { TrackId = 37, Name = "Sooner or Later", Lenght = "7:01", Number = 7, AlbumRefId = 4 },
                new Track() { TrackId = 38, Name = "Breakdown", Lenght = "7:10", Number = 8, AlbumRefId = 4 },
                new Track() { TrackId = 39, Name = "Away", Lenght = "9:14", Number = 9, AlbumRefId = 4 },
                new Track() { TrackId = 40, Name = "Believe", Lenght = "6:47", Number = 10, AlbumRefId = 4 },
                new Track() { TrackId = 41, Name = "Rain", Lenght = "8:48", Number = 11, AlbumRefId = 4 },
                // Eaten Back to Life
                new Track() { TrackId = 42, Name = "Shredded Humans", Lenght = "5:42", Number = 1, AlbumRefId = 5 },
                new Track() { TrackId = 43, Name = "Edible Autopsy", Lenght = "5:00", Number = 2, AlbumRefId = 5 },
                new Track() { TrackId = 44, Name = "Put Them to Death", Lenght = "6:34", Number = 3, AlbumRefId = 5 },
                new Track() { TrackId = 45, Name = "Mangled", Lenght = "5:13", Number = 4, AlbumRefId = 5 },
                new Track() { TrackId = 46, Name = "Scattered Remains, Splattered Brains", Lenght = "5:53", Number = 5, AlbumRefId = 5 },
                new Track() { TrackId = 47, Name = "Born in a Casket", Lenght = "5:32", Number = 6, AlbumRefId = 5 },
                new Track() { TrackId = 48, Name = "Rooting Head", Lenght = "7:01", Number = 7, AlbumRefId = 5 },
                new Track() { TrackId = 49, Name = "The Undead Will Feast", Lenght = "7:10", Number = 8, AlbumRefId = 5 },
                new Track() { TrackId = 50, Name = "Bloody Chunks", Lenght = "9:14", Number = 9, AlbumRefId = 5 },
                new Track() { TrackId = 51, Name = "A Skull Full of Maggots", Lenght = "6:47", Number = 10, AlbumRefId = 5 },
                new Track() { TrackId = 52, Name = "Buried in the Backyard", Lenght = "8:48", Number = 11, AlbumRefId = 5 },
                // Hats Off to the Bull
                new Track() { TrackId = 53, Name = "Face to the Floor", Lenght = "5:42", Number = 1, AlbumRefId = 6 },
                new Track() { TrackId = 54, Name = "Same Old Trip", Lenght = "5:00", Number = 2, AlbumRefId = 6 },
                new Track() { TrackId = 55, Name = "Ruse", Lenght = "6:34", Number = 3, AlbumRefId = 6 },
                new Track() { TrackId = 56, Name = "The Meddler", Lenght = "5:13", Number = 4, AlbumRefId = 6 },
                new Track() { TrackId = 57, Name = "Piñata", Lenght = "5:53", Number = 5, AlbumRefId = 6 },
                new Track() { TrackId = 57, Name = "Envy", Lenght = "5:32", Number = 6, AlbumRefId = 6 },
                new Track() { TrackId = 58, Name = "Hats Off to the Bull", Lenght = "7:01", Number = 7, AlbumRefId = 6 },
                new Track() { TrackId = 59, Name = "Arise", Lenght = "7:10", Number = 8, AlbumRefId = 6 },
                new Track() { TrackId = 60, Name = "Revenge", Lenght = "9:14", Number = 9, AlbumRefId = 6 },
                new Track() { TrackId = 61, Name = "Prime Donna", Lenght = "6:47", Number = 10, AlbumRefId = 6 },
                new Track() { TrackId = 62, Name = "Clones", Lenght = "8:48", Number = 11, AlbumRefId = 6 },
                // Ten Thousand Fists
                new Track() { TrackId = 63, Name = "Ten Thousand Fists", Lenght = "5:42", Number = 1, AlbumRefId = 7 },
                new Track() { TrackId = 64, Name = "Just Stop", Lenght = "5:00", Number = 2, AlbumRefId = 7 },
                new Track() { TrackId = 65, Name = "Guarded", Lenght = "6:34", Number = 3, AlbumRefId = 7 },
                new Track() { TrackId = 66, Name = "Deify", Lenght = "5:13", Number = 4, AlbumRefId = 7 },
                new Track() { TrackId = 67, Name = "Stricken", Lenght = "5:53", Number = 5, AlbumRefId = 7 },
                new Track() { TrackId = 68, Name = "I'm Alive", Lenght = "5:32", Number = 6, AlbumRefId = 7 },
                new Track() { TrackId = 69, Name = "Sons of Plunder", Lenght = "7:01", Number = 7, AlbumRefId = 7 },
                new Track() { TrackId = 70, Name = "Overburdened", Lenght = "7:10", Number = 8, AlbumRefId = 7 },
                new Track() { TrackId = 71, Name = "Decadence", Lenght = "9:14", Number = 9, AlbumRefId = 7 },
                new Track() { TrackId = 72, Name = "Forgiven", Lenght = "6:47", Number = 10, AlbumRefId = 7 },
                new Track() { TrackId = 73, Name = "Land of Confusion", Lenght = "8:48", Number = 11, AlbumRefId = 7 },
                new Track() { TrackId = 74, Name = "Sacred Lie", Lenght = "8:48", Number = 12, AlbumRefId = 7 },
                new Track() { TrackId = 75, Name = "Pain Redefined", Lenght = "8:48", Number = 13, AlbumRefId = 7 },
                new Track() { TrackId = 76, Name = "Avarice", Lenght = "8:48", Number = 14, AlbumRefId = 7 },
                // Yetzer Ha'ra
                new Track() { TrackId = 77, Name = "The Hell in Heaven", Lenght = "5:42", Number = 1, AlbumRefId = 8 },
                new Track() { TrackId = 78, Name = "The Devil in the Chain", Lenght = "5:00", Number = 2, AlbumRefId = 8 },
                new Track() { TrackId = 79, Name = "Heaven in Hell", Lenght = "6:34", Number = 3, AlbumRefId = 8 },
                new Track() { TrackId = 80, Name = "The Maze of Madness", Lenght = "5:13", Number = 4, AlbumRefId = 8 },
                new Track() { TrackId = 81, Name = "Vicious Circle", Lenght = "5:53", Number = 5, AlbumRefId = 8 },
                new Track() { TrackId = 82, Name = "The Call", Lenght = "5:32", Number = 6, AlbumRefId = 8 },
                new Track() { TrackId = 83, Name = "Wind Cry", Lenght = "7:01", Number = 7, AlbumRefId = 8 },
                // Peace, Love, Death Metal
                new Track() { TrackId = 84, Name = "I Only Want You", Lenght = "5:42", Number = 1, AlbumRefId = 9 },
                new Track() { TrackId = 85, Name = "Speaking in Tongues", Lenght = "5:00", Number = 2, AlbumRefId = 9 },
                new Track() { TrackId = 86, Name = "So Easy", Lenght = "6:34", Number = 3, AlbumRefId = 9 },
                new Track() { TrackId = 87, Name = "Flames Go Higher", Lenght = "5:13", Number = 4, AlbumRefId = 9 },
                new Track() { TrackId = 88, Name = "Bad Dream Mama", Lenght = "5:53", Number = 5, AlbumRefId = 9 },
                new Track() { TrackId = 89, Name = "English Girl", Lenght = "5:32", Number = 6, AlbumRefId = 9 },
                new Track() { TrackId = 90, Name = "Stacks o' Money", Lenght = "7:01", Number = 7, AlbumRefId = 9 },
                new Track() { TrackId = 91, Name = "Midnight Creeper", Lenght = "7:10", Number = 8, AlbumRefId = 9 },
                new Track() { TrackId = 92, Name = "Stuck in the Metal", Lenght = "9:14", Number = 9, AlbumRefId = 9 },
                new Track() { TrackId = 93, Name = "Already Died", Lenght = "6:47", Number = 10, AlbumRefId = 9 },
                new Track() { TrackId = 94, Name = "Kiss the Devil", Lenght = "8:48", Number = 11, AlbumRefId = 9 },
                new Track() { TrackId = 95, Name = "Whorehoppin' (Shit, Goddamn)", Lenght = "8:48", Number = 12, AlbumRefId = 9 },
                new Track() { TrackId = 96, Name = "San Berdoo Sunburn", Lenght = "8:48", Number = 13, AlbumRefId = 9 },
                new Track() { TrackId = 97, Name = "Wastin' My Time", Lenght = "8:48", Number = 14, AlbumRefId = 9 },
                new Track() { TrackId = 98, Name = "Miss Alissa", Lenght = "8:48", Number = 15, AlbumRefId = 9 },
                // Conquering the Elements
                new Track() { TrackId = 99, Name = "Intro", Lenght = "5:42", Number = 1, AlbumRefId = 10 },
                new Track() { TrackId = 100, Name = "Our Forsaken Homeland", Lenght = "5:00", Number = 2, AlbumRefId = 10 },
                new Track() { TrackId = 101, Name = "Conquering the Elements", Lenght = "6:34", Number = 3, AlbumRefId = 10 },
                new Track() { TrackId = 102, Name = "Winds from an Ancient Time", Lenght = "5:13", Number = 4, AlbumRefId = 10 },
                new Track() { TrackId = 103, Name = "In the Gloom of the Woodland God", Lenght = "5:53", Number = 5, AlbumRefId = 10 },
                new Track() { TrackId = 104, Name = "The Furthest Shore", Lenght = "5:32", Number = 6, AlbumRefId = 10 },
                new Track() { TrackId = 105, Name = "The Shroud of Enchantment", Lenght = "7:01", Number = 7, AlbumRefId = 10 },
                new Track() { TrackId = 106, Name = "Upon Vast Foothills", Lenght = "7:10", Number = 8, AlbumRefId = 10 },
                new Track() { TrackId = 107, Name = "A Treacherous Road", Lenght = "9:14", Number = 9, AlbumRefId = 10 },
                new Track() { TrackId = 108, Name = "Outro", Lenght = "6:47", Number = 10, AlbumRefId = 10 },
                // Say Hello to Sunshine
                new Track() { TrackId = 109, Name = "Insomniatic Meat", Lenght = "5:42", Number = 1, AlbumRefId = 11 },
                new Track() { TrackId = 110, Name = "Revelation Song", Lenght = "5:00", Number = 2, AlbumRefId = 11 },
                new Track() { TrackId = 111, Name = "Brother Bleed Brother", Lenght = "6:34", Number = 3, AlbumRefId = 11 },
                new Track() { TrackId = 112, Name = "A Piece of Mind", Lenght = "5:13", Number = 4, AlbumRefId = 11 },
                new Track() { TrackId = 113, Name = "Ink", Lenght = "5:53", Number = 5, AlbumRefId = 11 },
                new Track() { TrackId = 114, Name = "Fireflies", Lenght = "5:32", Number = 6, AlbumRefId = 11 },
                new Track() { TrackId = 115, Name = "Hopeless Host", Lenght = "7:01", Number = 7, AlbumRefId = 11 },
                new Track() { TrackId = 116, Name = "Reduced to Teeth", Lenght = "7:10", Number = 8, AlbumRefId = 11 },
                new Track() { TrackId = 117, Name = "A Man Alone", Lenght = "9:14", Number = 9, AlbumRefId = 11 },
                new Track() { TrackId = 118, Name = "Miro", Lenght = "6:47", Number = 10, AlbumRefId = 11 },
                new Track() { TrackId = 119, Name = "Ravenous", Lenght = "8:48", Number = 11, AlbumRefId = 11 },
                new Track() { TrackId = 120, Name = "Bitemarks and Bloodstains", Lenght = "8:48", Number = 12, AlbumRefId = 11 },
                new Track() { TrackId = 121, Name = "The Casket of Roderick Usher", Lenght = "8:48", Number = 13, AlbumRefId = 11 },
                new Track() { TrackId = 122, Name = "Dreams of Psilocybin", Lenght = "8:48", Number = 14, AlbumRefId = 11 },
                // A New Light
                new Track() { TrackId = 123, Name = "Fly", Lenght = "5:42", Number = 1, AlbumRefId = 12 },
                new Track() { TrackId = 124, Name = "Do Not Care", Lenght = "5:00", Number = 2, AlbumRefId = 12 },
                new Track() { TrackId = 125, Name = "The Top", Lenght = "6:34", Number = 3, AlbumRefId = 12 },
                new Track() { TrackId = 126, Name = "Nightmare", Lenght = "5:13", Number = 4, AlbumRefId = 12 },
                new Track() { TrackId = 127, Name = "Sober Mind", Lenght = "5:53", Number = 5, AlbumRefId = 12 },
                new Track() { TrackId = 128, Name = "Hate and Passion", Lenght = "5:32", Number = 6, AlbumRefId = 12 },
                new Track() { TrackId = 129, Name = "Insane", Lenght = "7:01", Number = 7, AlbumRefId = 12 },
                new Track() { TrackId = 130, Name = "Little Black Devil", Lenght = "7:10", Number = 8, AlbumRefId = 12 },
                new Track() { TrackId = 131, Name = "A New Light", Lenght = "9:14", Number = 9, AlbumRefId = 12 },
                // Stomping Ground
                new Track() { TrackId = 132, Name = "I'm Down", Lenght = "5:42", Number = 1, AlbumRefId = 13 },
                new Track() { TrackId = 133, Name = "Pick a Fight", Lenght = "5:00", Number = 2, AlbumRefId = 13 },
                new Track() { TrackId = 134, Name = "Carry On", Lenght = "6:34", Number = 3, AlbumRefId = 13 },
                new Track() { TrackId = 135, Name = "The End of the Day", Lenght = "5:13", Number = 4, AlbumRefId = 13 },
                new Track() { TrackId = 136, Name = "Don't Say Goodbye", Lenght = "5:53", Number = 5, AlbumRefId = 13 },
                new Track() { TrackId = 137, Name = "Counting the Days", Lenght = "5:32", Number = 6, AlbumRefId = 13 },
                new Track() { TrackId = 138, Name = "Bro", Lenght = "7:01", Number = 7, AlbumRefId = 13 },
                new Track() { TrackId = 139, Name = "San Simeon", Lenght = "7:10", Number = 8, AlbumRefId = 13 },
                new Track() { TrackId = 140, Name = "You Think It's a Joke", Lenght = "9:14", Number = 9, AlbumRefId = 13 },
                new Track() { TrackId = 141, Name = "Forgiveness", Lenght = "6:47", Number = 10, AlbumRefId = 13 },
                new Track() { TrackId = 142, Name = "Margaret Ann", Lenght = "8:48", Number = 11, AlbumRefId = 13 },
                new Track() { TrackId = 143, Name = "Get Away", Lenght = "8:48", Number = 12, AlbumRefId = 13 },
                new Track() { TrackId = 144, Name = "99 Red Ballons", Lenght = "8:48", Number = 13, AlbumRefId = 13 },
                new Track() { TrackId = 145, Name = "Donut Dan", Lenght = "8:48", Number = 14, AlbumRefId = 13 },
                // The Blind lead the Blind
                new Track() { TrackId = 146, Name = "Eye to Eye", Lenght = "5:42", Number = 1, AlbumRefId = 14 },
                new Track() { TrackId = 147, Name = "Stainless Steel", Lenght = "5:00", Number = 2, AlbumRefId = 14 },
                new Track() { TrackId = 148, Name = "Digger", Lenght = "6:34", Number = 3, AlbumRefId = 14 },
                new Track() { TrackId = 149, Name = "Alone", Lenght = "5:13", Number = 4, AlbumRefId = 14 },
                new Track() { TrackId = 150, Name = "End of Evolution", Lenght = "5:53", Number = 5, AlbumRefId = 14 },
                // Chapter V: Unbent, Unbowed, Unbroken
                new Track() { TrackId = 151, Name = "Secrets", Lenght = "5:42", Number = 1, AlbumRefId = 15 },
                new Track() { TrackId = 152, Name = "Blood Bound", Lenght = "5:00", Number = 2, AlbumRefId = 15 },
                new Track() { TrackId = 153, Name = "Fury of the Wild", Lenght = "6:34", Number = 3, AlbumRefId = 15 },
                new Track() { TrackId = 154, Name = "Hammer of Justice", Lenght = "5:13", Number = 4, AlbumRefId = 15 },
                new Track() { TrackId = 155, Name = "Never, Ever", Lenght = "5:53", Number = 5, AlbumRefId = 15 },
                new Track() { TrackId = 156, Name = "Born to Rule", Lenght = "5:32", Number = 6, AlbumRefId = 15 },
                new Track() { TrackId = 157, Name = "The Templar Flame", Lenght = "7:01", Number = 7, AlbumRefId = 15 },
                new Track() { TrackId = 158, Name = "Imperial", Lenght = "7:10", Number = 8, AlbumRefId = 15 },
                new Track() { TrackId = 159, Name = "Take the Black", Lenght = "9:14", Number = 9, AlbumRefId = 15 },
                new Track() { TrackId = 161, Name = "Knights of the 21st Century", Lenght = "6:47", Number = 10, AlbumRefId = 15 },
                // Glory to the Brave
                new Track() { TrackId = 162, Name = "The Dragon Lies Bleeding", Lenght = "5:42", Number = 1, AlbumRefId = 16 },
                new Track() { TrackId = 163, Name = "The Metal Age", Lenght = "5:00", Number = 2, AlbumRefId = 16 },
                new Track() { TrackId = 164, Name = "I Believe", Lenght = "6:34", Number = 3, AlbumRefId = 16 },
                new Track() { TrackId = 165, Name = "Child of the Damned", Lenght = "5:13", Number = 4, AlbumRefId = 16 },
                new Track() { TrackId = 166, Name = "Steel Meets Steel", Lenght = "5:53", Number = 5, AlbumRefId = 16 },
                new Track() { TrackId = 167, Name = "Stone Cold", Lenght = "5:32", Number = 6, AlbumRefId = 16 },
                new Track() { TrackId = 168, Name = "Unchained", Lenght = "7:01", Number = 7, AlbumRefId = 16 },
                new Track() { TrackId = 169, Name = "Glory to the Brave", Lenght = "7:10", Number = 8, AlbumRefId = 16 },
                new Track() { TrackId = 170, Name = "Ravenlord", Lenght = "9:14", Number = 9, AlbumRefId = 16 },
                new Track() { TrackId = 171, Name = "Hammerfall", Lenght = "6:47", Number = 10, AlbumRefId = 16 },
                new Track() { TrackId = 172, Name = "Glory to the Brave", Lenght = "8:48", Number = 11, AlbumRefId = 16 }
            });
        }
    }
}