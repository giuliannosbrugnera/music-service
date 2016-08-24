using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    // Represent an Album. Associated with a Band. It has 1 to many Tracks
    public class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        // Foreign key for Band
        [ForeignKey("BandId")]
        public int BandRefId { get; set; }
        // Navigation property
        public Band Band { get; set; }
    }
}
