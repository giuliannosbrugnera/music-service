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
    [RoutePrefix("api/track")]
    public class TracksController : ApiController
    {
        private MusicServiceContext db = new MusicServiceContext();

        [HttpGet]
        [Route("~/api/tracks")]
        public IHttpActionResult GetLabels()
        {
            return Ok(db.Tracks);
        }

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

        [HttpPut]
        [Route("{trackId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrack(int trackId, Track track)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (trackId != track.Id)
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

            return CreatedAtRoute("DefaultApi", new { id = track.Id }, track);
        }

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
            return db.Tracks.Count(e => e.Id == id) > 0;
        }
    }
}
