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
    /// Record Labels controller.
    /// </summary>
    [RoutePrefix("api/label")]
    public class LabelsController : ApiController
    {
        private MusicServiceContext _context = new MusicServiceContext();

        /// <summary>
        /// Return all Record Labels.
        /// </summary>
        [HttpGet]
        [Route("~/api/labels")]
        [ResponseType(typeof(Label))]
        public IHttpActionResult GetLabels()
        {
            return Ok(_context.Labels);
        }

        /// <summary>
        /// Return a specific Record Label.
        /// </summary>
        /// <param name="labelId">Record Label identifier.</param>
        [HttpGet]
        [Route("{labelId}")]
        [ResponseType(typeof(Label))]
        // Return a specific Record Label based on {labelId}
        public async Task<IHttpActionResult> GetLabel(int labelId)
        {
            Label label = await _context.Labels.FindAsync(labelId);
            if (label == null)
            {
                return NotFound();
            }

            return Ok(label);
        }

        /// <summary>
        /// Update an entire Record Label.
        /// </summary>
        /// <param name="labelId">Record Label identifier.</param>
        /// <param name="label">New object to be inserted.</param>
        [HttpPut]
        [Route("{labelId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLabel(int labelId, Label label)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (labelId != label.LabelId)
            {
                return BadRequest();
            }

            _context.Entry(label).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabelExists(labelId))
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
        /// Create a Record Label.
        /// </summary>
        /// <param name="label">Object to be created.</param>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Label))]
        public async Task<IHttpActionResult> PostLabel(Label label)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Labels.Add(label);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = label.LabelId }, label);
        }

        /// <summary>
        /// Delete a Record Label.
        /// </summary>
        /// <param name="labelId">Record Label identifier.</param>
        [HttpDelete]
        [Route("{labelId}")]
        [ResponseType(typeof(Label))]
        public async Task<IHttpActionResult> DeleteLabel(int labelId)
        {
            Label label = await _context.Labels.FindAsync(labelId);
            if (label == null)
            {
                return NotFound();
            }

            _context.Labels.Remove(label);
            await _context.SaveChangesAsync();

            return Ok(label);
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

        private bool LabelExists(int id)
        {
            return _context.Labels.Count(e => e.LabelId == id) > 0;
        }
    }
}
