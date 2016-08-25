using System.Data.Entity;

namespace MusicService.Models
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class MusicServiceContext : DbContext
    {
        /// <summary>
        /// Constructor.
        /// </summary>
                    
        public MusicServiceContext() : base("name=MusicServiceContext")
        {
        }

        /// <summary>
        /// Label entity.
        /// </summary>
        public System.Data.Entity.DbSet<MusicService.Models.Label> Labels { get; set; }

        /// <summary>
        /// Band entity.
        /// </summary>
        public System.Data.Entity.DbSet<MusicService.Models.Band> Bands { get; set; }

        /// <summary>
        /// Album entity.
        /// </summary>
        public System.Data.Entity.DbSet<MusicService.Models.Album> Albums { get; set; }

        /// <summary>
        /// Track entity.
        /// </summary>
        public System.Data.Entity.DbSet<MusicService.Models.Track> Tracks { get; set; }
    }
}
