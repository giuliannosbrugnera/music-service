using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    /// <summary>
    /// Represent a Band. Associated with a Record Label. It has 0 to many Albums.
    /// </summary>
    public class Band
    {
        /// <summary>
        /// Band ID.
        /// </summary>
        public int BandId { get; set; }
        /// <summary>
        /// Name given to a Band.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Genre of a Band.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Country where the Band was created.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Foreign key for Label.
        /// </summary>
        [ForeignKey("Label")]
        public int LabelRefId { get; set; }

        /// <summary>
        /// Navigation property.
        /// </summary>
        public Label Label { get; set; }
    }
}
