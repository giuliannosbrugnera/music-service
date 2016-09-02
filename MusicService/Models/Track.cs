using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    /// <summary>
    /// Represent a Track. Associated with an Album.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Track Id.
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        /// Name given to a Track.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Track length in the pattern "minutes":"seconds".
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Track number in the Album.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Foreign key for Album.
        /// </summary>
        [ForeignKey("Album")]
        public int AlbumRefId { get; set; }
        
        /// <summary>
        /// Navigation property.
        /// </summary>
        public Album Album { get; set; }
    }
}
