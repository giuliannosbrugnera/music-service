namespace MusicService.Models
{
    /// <summary>
    /// Represent a Record Label. It has 0 to many Bands.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// Label ID.
        /// </summary>
        public int LabelId { get; set; }
        
        /// <summary>
        /// Name given to a Label.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Year that the Label was founded.
        /// </summary>
        public int FoundationYear { get; set; }

        /// <summary>
        /// Name of the Label founder.
        /// </summary>
        public string FounderName { get; set; }
    }
}
