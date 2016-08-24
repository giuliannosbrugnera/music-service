namespace MusicService.Models
{
    // Represent an Album. Associated with a Band. It has 1 to many Tracks
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }

        // Foreign key
        public int BandId { get; set; }
        // Navigation property
        public Band Band { get; set; }
    }
}