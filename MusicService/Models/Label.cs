namespace MusicService.Models
{
    // Represent a Record Label. It has 0 to many Bands
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundationYear { get; set; }
        public string FounderName { get; set; }
    }
}