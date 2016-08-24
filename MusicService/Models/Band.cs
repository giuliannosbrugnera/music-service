using System.ComponentModel.DataAnnotations.Schema;

namespace MusicService.Models
{
    // Represent a Band. Associated with a Record Label. It has 0 to many Albums
    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public string MembersNames { get; set; }
        public string Genre { get; set; }
        public int FormationYear { get; set; }
        // Foreign key for Label
        [ForeignKey("LabelId")]
        public int LabelRefId { get; set; }
        // Navigation property
        public Label Label { get; set; }
    }
}
