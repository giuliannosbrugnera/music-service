using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    /// <summary>
    /// Represent an Album. Associated with a Band. It has 1 to many Tracks.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Album ID.
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// The name given to an Album.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The year the Album was released.
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Foreign key for Band.
        /// </summary>
        [ForeignKey("Band")]

        public int BandRefId { get; set; }
        
        /// <summary>
        /// Navigation property.
        /// </summary>
        public Band Band { get; set; }
    }
}
