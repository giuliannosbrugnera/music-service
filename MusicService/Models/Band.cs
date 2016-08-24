namespace MusicService.Models
{
    // Represent a Band. Associated with a Record Label. It has 0 to many Albums
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MembersNames { get; set; }
        public string Genre { get; set; }
        public int FormationYear { get; set; }

        // Foreign key
        public int LabelId { get; set; }
        // Navigation property
        public Label Label { get; set; }
    }
}