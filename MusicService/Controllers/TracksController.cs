using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MusicService.Models;
using System;
using MusicService.Utility;

namespace MusicService.Controllers
{
    /// <summary>
    /// Tracks controller.
    /// </summary>
    [RoutePrefix("api/tracks")]
    public class TracksController : ApiController
    {
        private MusicServiceContext _context = new MusicServiceContext();

        /// <summary>
        /// Find all tracks
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(Track))]
        public IHttpActionResult GetTracks()
        {
            // Include the associated Album, Band and Record Label.
            var tracks = _context.Tracks
                                .Include(a => a.Album)
                                .Include(a => a.Album.Band)
                                .Include(a => a.Album.Band.Label);
            return Ok(tracks);
        }

        /// <summary>
        /// Find all tracks, supports pagination
        /// </summary>
        /// <param name="pageSize">Size of he page</param>
        /// <param name="pageNumber">Number of the page</param>
        /// <param name="orderBy">Attribute to order the results</param>
        [HttpGet]
        [Route("{pageSize:int}/{pageNumber:int}/{orderBy:alpha?}")]
        [ResponseType(typeof(Track))]
        public IHttpActionResult Get(int pageSize, int pageNumber, string orderBy = "")
        {
            // Total number of Track items.
            var totalCount = _context.Tracks.Count();
            // Calculates the total number of pages required.
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            // Include the associated Album, Band and Record Label.
            IQueryable<Track> trackQuery = _context.Tracks
                                .Include(a => a.Album)
                                .Include(a => a.Album.Band)
                                .Include(a => a.Album.Band.Label);
            
            // Check if the property exists.
            if (QueryHelper.PropertyExists<Track>(orderBy))
            {
                // If yes, order the results by the requested property.
                var orderByExpression = QueryHelper.GetPropertyExpression<Track>(orderBy);
                trackQuery = trackQuery.OrderBy(orderByExpression);
            }
            else
            {
                // Otherwise, order the results by the TrackId.
                trackQuery = trackQuery.OrderBy(c => c.TrackId);
            }

            // Get pageSize number of elements at the pageNumber page number.
            var tracks = trackQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            // Create a result object, containing the results.
            var result = new
            {
                totalCount = totalCount,
                totalPages = totalPages,
                tracks = tracks
            };

            return Ok(result);
        }

        /// <summary>
        /// Find track by ID
        /// </summary>
        /// <param name="trackId">Track identifier</param>
        [HttpGet]
        [Route("{trackId}")]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> GetTrack(int trackId)
        {
            Track track = await _context.Tracks
                                    .Include(a => a.Album)
                                    .Include(a => a.Album.Band)
                                    .Include(a => a.Album.Band.Label)
                                    .SingleOrDefaultAsync(t => t.TrackId == trackId);
            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        /// <summary>
        /// Find track by track name
        /// </summary>
        /// <param name="trackName">Track name</param>
        [HttpGet]
        [Route("search/{trackName}")]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> GetTrackByName(string trackName)
        {
            // Get all tracks.
            var tracks = _context.Tracks
                                .Include(a => a.Album)
                                .Include(a => a.Album.Band)
                                .Include(a => a.Album.Band.Label);


            if (!String.IsNullOrEmpty(trackName))
            {
                // Select the tracks based on the trackName parameter.
                tracks = tracks.Where(t => t.Name.ToLower().Contains(trackName.ToLower()));
            }

            if (tracks == null)
            {
                return NotFound();
            }

            await tracks.ToListAsync();

            return Ok(tracks);
        }

        /// <summary>
        /// Update an entire track
        /// </summary>
        /// <param name="trackId">Track identifier</param>
        /// <param name="track">New object to be inserted</param>
        [HttpPut]
        [Route("{trackId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrack(int trackId, Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (trackId != track.TrackId)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(trackId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Create a new track
        /// </summary>
        /// <param name="track">Object to be created</param>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = track.TrackId }, track);
        }

        /// <summary>
        /// Delete a specific track
        /// </summary>
        /// <param name="trackId">Track identifier</param>
        [HttpDelete]
        [Route("{trackId}")]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> DeleteTrack(int trackId)
        {
            Track track = await _context.Tracks.FindAsync(trackId);
            if (track == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return Ok(track);
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Count(e => e.TrackId == id) > 0;
        }
    }
}
