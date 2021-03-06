﻿using System.Data.Entity;
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
    /// Albums controller.
    /// </summary>
    [RoutePrefix("api/albums")]
    public class AlbumsController : ApiController
    {
        private MusicServiceContext _context = new MusicServiceContext();

        /// <summary>
        /// Find all albums
        /// </summary>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(Album))]
        public IHttpActionResult GetAlbums()
        {
            // Include the Band and Record Label.
            var albums = _context.Albums
                                .Include(b => b.Band)
                                .Include(b => b.Band.Label);
            return Ok(albums);
        }

        /// <summary>
        /// Find album by ID
        /// </summary>
        /// <param name="albumId">Band identifier</param>
        [HttpGet]
        [Route("{albumId}")]
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> GetAlbum(int albumId)
        {
            Album album = await _context.Albums
                                .Include(b => b.Band)
                                .Include(b => b.Band.Label)
                                .SingleOrDefaultAsync(a => a.AlbumId == albumId);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        /// <summary>
        /// Update an album
        /// </summary>
        /// <param name="albumId">Album identifier</param>
        /// <param name="album">New object to be inserted</param>
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

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        /// <summary>
        /// Create a new album
        /// </summary>
        /// <param name="album">Object to be created</param>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return Ok(album);
        }

        /// <summary>
        ///  Deletes an album
        /// </summary>
        /// <param name="albumId">Album identifier</param>
        [HttpDelete]
        [Route("{albumId}")]
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> DeleteAlbum(int albumId)
        {
            Album album = await _context.Albums.FindAsync(albumId);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return Ok(album);
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

        private bool AlbumExists(int id)
        {
            return _context.Albums.Count(e => e.AlbumId == id) > 0;
        }
    }
}
