namespace MusicService.Models
{
    // Represent a Track. Associated with an Album
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Number { get; set; }

        // Foreign key
        public int AlbumId { get; set; }
        // Navigation property
        public Album Album { get; set; }
    }
}