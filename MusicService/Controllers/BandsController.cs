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
    /// Bands controller.
    /// </summary>
    [RoutePrefix("api/band")]
    public class BandsController : ApiController
    {
        private MusicServiceContext _context = new MusicServiceContext();

        /// <summary>
        /// Return all Bands.
        /// </summary>
        [HttpGet]
        [Route("~/api/bands")]
        [ResponseType(typeof(Band))]
        public IHttpActionResult GetBands()
        {
            var bands = _context.Bands.Include(b => b.Label);
            return Ok(bands);
        }

        /// <summary>
        /// Return a specific Band.
        /// </summary>
        /// <param name="bandId">Band identifier.</param>
        [HttpGet]
        [Route("{bandId}")]
        [ResponseType(typeof(Band))]
        public async Task<IHttpActionResult> GetBand(int bandId)
        {
            Band band = await _context.Bands
                                    .Include(b => b.Label)
                                    .SingleOrDefaultAsync(c => c.BandId == bandId);
            if (band == null)
            {
                return NotFound();
            }

            return Ok(band);
        }

        /// <summary>
        /// Update an entire Band.
        /// </summary>
        /// <param name="bandId">Band identifier.</param>
        /// <param name="band">New object to be inserted.</param>
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

            _context.Entry(band).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        /// <summary>
        /// Create a new Band.
        /// </summary>
        /// <param name="band">Object to be created.</param>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Band))]
        public async Task<IHttpActionResult> PostBand(Band band)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bands.Add(band);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = band.BandId }, band);
        }

        /// <summary>
        /// Delete a Band.
        /// </summary>
        /// <param name="bandId">Band identifier.</param>
        [HttpDelete]
        [Route("{bandId}")]
        [ResponseType(typeof(Band))]
        public async Task<IHttpActionResult> DeleteBand(int bandId)
        {
            Band band = await _context.Bands.FindAsync(bandId);
            if (band == null)
            {
                return NotFound();
            }

            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();

            return Ok(band);
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

        private bool BandExists(int id)
        {
            return _context.Bands.Count(e => e.BandId == id) > 0;
        }
    }
}
