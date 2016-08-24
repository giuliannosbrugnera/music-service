using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    // Represent a Track. Associated with an Album
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Number { get; set; }
        // Foreign key for Album
        [ForeignKey("LabelId")]
        public int AlbumRefId { get; set; }
        // Navigation property
        public Album Album { get; set; }
    }
}
