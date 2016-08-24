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
    [RoutePrefix("api/band")]
    public class BandsController : ApiController
    {
        private MusicServiceContext db = new MusicServiceContext();

        [HttpGet]
        [Route("~/api/bands")]
        public IHttpActionResult GetLabels()
        {
            return Ok(db.Bands);
        }

        [HttpGet]
        [Route("{bandId}")]
        [ResponseType(typeof(Band))]
        public async Task<IHttpActionResult> GetBand(int bandId)
        {
            Band band = await db.Bands.FindAsync(bandId);
            if (band == null)
            {
                return NotFound();
            }

            return Ok(band);
        }

        [HttpPut]
        [Route("{bandId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBand(int bandId, Band band)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (bandId != band.BandId)
            {
                return BadRequest();
            }

            db.Entry(band).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BandExists(bandId))
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
        [ResponseType(typeof(Band))]
        public async Task<IHttpActionResult> PostBand(Band band)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bands.Add(band);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = band.BandId }, band);
        }

        [HttpDelete]
        [Route("{bandId}")]
        [ResponseType(typeof(Band))]
        public async Task<IHttpActionResult> DeleteBand(int bandId)
        {
            Band band = await db.Bands.FindAsync(bandId);
            if (band == null)
            {
                return NotFound();
            }

            db.Bands.Remove(band);
            await db.SaveChangesAsync();

            return Ok(band);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BandExists(int id)
        {
            return db.Bands.Count(e => e.BandId == id) > 0;
        }
    }
}
