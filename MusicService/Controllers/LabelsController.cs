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
    [RoutePrefix("api/label")]
    public class LabelsController : ApiController
    {
        private MusicServiceContext db = new MusicServiceContext();

        [HttpGet]
        [Route("~/api/labels")]
        public IHttpActionResult GetLabels()
        {
            return Ok(db.Labels);
        }

        [HttpGet]
        [Route("{labelId}")]
        [ResponseType(typeof(Label))]
        public async Task<IHttpActionResult> GetLabel(int labelId)
        {
            Label label = await db.Labels.FindAsync(labelId);
            if (label == null)
            {
                return NotFound();
            }

            return Ok(label);
        }

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

            db.Entry(label).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Label))]
        public async Task<IHttpActionResult> PostLabel(Label label)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Labels.Add(label);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = label.LabelId }, label);
        }

        [HttpDelete]
        [Route("{labelId}")]
        [ResponseType(typeof(Label))]
        public async Task<IHttpActionResult> DeleteLabel(int labelId)
        {
            Label label = await db.Labels.FindAsync(labelId);
            if (label == null)
            {
                return NotFound();
            }

            db.Labels.Remove(label);
            await db.SaveChangesAsync();

            return Ok(label);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LabelExists(int id)
        {
            return db.Labels.Count(e => e.LabelId == id) > 0;
        }
    }
}
