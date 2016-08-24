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
    [RoutePrefix("api/album")]
    public class AlbumsController : ApiController
    {
        private MusicServiceContext db = new MusicServiceContext();

        [HttpGet]
        [Route("~/api/albums")]
        public IHttpActionResult GetLabels()
        {
            return Ok(db.Albums);
        }

        [HttpGet]
        [Route("{albumId}")]
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> GetAlbum(int albumId)
        {
            Album album = await db.Albums.FindAsync(albumId);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        [HttpPut]
        [Route("{albumId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlbum(int albumId, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (albumId != album.AlbumId)
            {
                return BadRequest();
            }

            db.Entry(album).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(albumId))
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
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = album.AlbumId }, album);
        }

        [HttpDelete]
        [Route("{albumId}")]
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> DeleteAlbum(int albumId)
        {
            Album album = await db.Albums.FindAsync(albumId);
            if (album == null)
            {
                return NotFound();
            }

            db.Albums.Remove(album);
            await db.SaveChangesAsync();

            return Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id)
        {
            return db.Albums.Count(e => e.AlbumId == id) > 0;
        }
    }
}
