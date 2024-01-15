using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.Server.Data;
using GameStore.Shared.Domain;
using GameStore.Server.IRepository;

namespace GameStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public GenresController(ApplicationDbContext context)
        public GenresController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Genres
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        public async Task<IActionResult> GetGenres()
        {
            var Genres = await _unitOfWork.Genres.GetAll();
            return Ok(Genres);
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Genre>> GetGenre(int id)
        public async Task<IActionResult> GetGenre(int id)
        {
            var Genre = await _unitOfWork.Genres.Get(q => q.Id == id);
            if (Genre == null)
            {
                return NotFound();
            }
            return Ok(Genre);
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutGenre(int id, Genre Genre)
        public async Task<IActionResult> PutGenre(int id, Genre Genre)
        {
            if (id != Genre.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Genre).State = EntityState.Modified;
            _unitOfWork.Genres.Update(Genre);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!GenreExists(id))
                if (!await GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre Genre)
        {
            /*
          if (_context.Genres == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Genres'  is null.");
          }
            _context.Genres.Add(Genre);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Genres.Insert(Genre);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGenre", new { id = Genre.Id }, Genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            /* if (_context.Genres == null)
             {
                 return NotFound();
             }
             var Genre = await _context.Genres.FindAsync(id); */

            var Genre = await _unitOfWork.Genres.Get(q => q.Id == id);
            if (Genre == null)
            {
                return NotFound();
            }

            //_context.Genres.Remove(Genre);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Genres.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool GenreExists(int id)
        private async Task<bool> GenreExists(int id)
        {
            //return (_context.Genres?.Any(e => e.Id == id)).GetValueOrDefault();
            var Genre = await _unitOfWork.Genres.Get(q => q.Id == id);
            return Genre != null;
        }
    }
}
