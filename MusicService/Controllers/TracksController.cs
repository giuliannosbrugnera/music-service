using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MusicService.Models;

namespace MusicService.Controllers
{
    /// <summary>
    /// Tracks controller.
    /// </summary>
    [RoutePrefix("api/track")]
    public class TracksController : ApiController
    {
        private MusicServiceContext db = new MusicServiceContext();

        /// <summary>
        /// Return all Tracks.
        /// </summary>
        [HttpGet]
        [Route("~/api/tracks")]
        [ResponseType(typeof(Track))]
        public IHttpActionResult GetTracks()
        {
            return Ok(db.Tracks);
        }

        /// <summary>
        /// Return a specific Track.
        /// </summary>
        /// <param name="trackId">Track identifier.</param>
        [HttpGet]
        [Route("{trackId}")]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> GetTrack(int trackId)
        {
            Track track = await db.Tracks.FindAsync(trackId);
            if (track == null)
            {
                return NotFound();
            }

            return Ok(track);
        }

        /// <summary>
        /// Update an entire Track.
        /// </summary>
        /// <param name="trackId">Track identifier.</param>
        /// <param name="track">New object to be inserted.</param>
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

            db.Entry(track).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        /// Create a new Track.
        /// </summary>
        /// <param name="track">Object to be created.</param>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> PostTrack(Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tracks.Add(track);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = track.TrackId }, track);
        }

        /// <summary>
        /// Delete a specific Track.
        /// </summary>
        /// <param name="trackId">Track identifier.</param>
        [HttpDelete]
        [Route("{trackId}")]
        [ResponseType(typeof(Track))]
        public async Task<IHttpActionResult> DeleteTrack(int trackId)
        {
            Track track = await db.Tracks.FindAsync(trackId);
            if (track == null)
            {
                return NotFound();
            }

            db.Tracks.Remove(track);
            await db.SaveChangesAsync();

            return Ok(track);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackExists(int id)
        {
            return db.Tracks.Count(e => e.TrackId == id) > 0;
        }
    }
}
