using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    // Represent a Track. Associated with an Album
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Lenght { get; set; }
        public int Number { get; set; }
        // Foreign key for Album
        [ForeignKey("Album")]
        public int AlbumRefId { get; set; }
        // Navigation property
        public Album Album { get; set; }
    }
}
